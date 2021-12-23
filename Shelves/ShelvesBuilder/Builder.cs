using APIConnector;
using ShelvesParameters;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace ShelvesBuilder
{
    /// <summary>
    /// Класс для построения полок
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Переменная для работы с Компас-3D
        /// </summary>
        private KompasConnector _connector;
        
        /// <summary>
        /// Функция последовательного построения полок
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="param"></param>
        public void BuildShelves(KompasConnector connector, Parameters param)
        {
            var parameters = param;
            _connector = connector;
            
            //Левая стенка
            CreateShelf(0, 0, parameters.Thickness,
                parameters.LeftWallHeight + parameters.Thickness,
                parameters.Width);

            //Нижняя дощечка верхней полки
            CreateShelf(parameters.Thickness, 0, parameters.Length,
                parameters.Thickness, parameters.Width);

            if (parameters.BackShelf)
            {
                //Задняя дощечка верхней полки
                CreateShelf(parameters.Thickness, parameters.Thickness,
                    parameters.Length, parameters.RightWallHeight,
                    parameters.Thickness);
            }

            //Общая стенка
            CreateShelf(parameters.Length + parameters.Thickness, 
                - parameters.CommonWallHeight + parameters.RightWallHeight, 
                parameters.Thickness,
                parameters.CommonWallHeight + parameters.Thickness,
                parameters.Width);

            if (parameters.BackShelf)
            {
                //Задняя дощечка нижней полки
                CreateShelf(parameters.Length + parameters.Thickness * 2,
                    -parameters.CommonWallHeight + parameters.RightWallHeight,
                    parameters.Length, parameters.Thickness,
                    parameters.Width);
            }

            //Нижняя дощечка нижней полки
            CreateShelf(parameters.Length + parameters.Thickness * 2,
                - parameters.LeftWallHeight, parameters.Length,
                parameters.RightWallHeight, parameters.Thickness);

            //Правая стенка
            CreateShelf(parameters.Length * 2 + parameters.Thickness * 2,
                - param.LeftWallHeight - parameters.Thickness,
                param.Thickness, 
                parameters.RightWallHeight + parameters.Thickness,
                parameters.Width);

            //TODO: сделать все три доп.функциональности
        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="planeType">Выбор плоскости</param>
        /// <returns>ksSketchDefinition</returns>
        public ksSketchDefinition CreateSketch(Obj3dType planeType)
        {
            var plane = (ksEntity)_connector
                .KsPart
                .GetDefaultEntity((short)planeType);
            
            var sketch = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_sketch);
            
            var sketchDefinition = (ksSketchDefinition)sketch
                .GetDefinition();

            //Изменить базовую плоскость эскиза
            sketchDefinition.SetPlane(plane);

            //Создать объект в модели
            sketch.Create();
            return sketchDefinition;
        }

        /// <summary>
        /// Выдавливание по эскизу
        /// </summary>
        /// <param name="sketchDefinition">Эскиз</param>
        /// <param name="thickness">Толщина</param>
        private void PressOutSketch(
            ksSketchDefinition sketchDefinition,
            double thickness)
        {
            var extrusionEntity = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_bossExtrusion);
            
            var extrusionDefinition = 
                (ksBossExtrusionDefinition)extrusionEntity
                .GetDefinition();
            
            //side - направление (true - прямое направление)
            //тип выдавливания (0 - строго на глубину)
            //глубина выдавливания
            extrusionDefinition.SetSideParam(true, 0, thickness);
            
            extrusionDefinition.SetSketch(sketchDefinition);
            
            extrusionEntity.Create();
        }

        /// <summary>
        /// Вырезание по эскизу
        /// </summary>
        /// <param name="sketchDefinition">Эскиз</param>
        /// <param name="thickness">Глубина выреза</param>
        private void CutOutSketch(ksSketchDefinition sketchDefinition,
            double thickness)
        {
            var extrusionEntity = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_cutExtrusion);

            var extrusionDefinition =
                (ksCutExtrusionDefinition)extrusionEntity
                    .GetDefinition();

            //side - направление (true - прямое направление)
            //тип выдавливания (0 - строго на глубину)
            //глубина выдавливания
            extrusionDefinition.SetSideParam(true, 0, thickness);

            extrusionDefinition.SetSketch(sketchDefinition);

            extrusionEntity.Create();
        }

        /// <summary>
        /// Создание дощечки по заданным параметрам
        /// </summary>
        /// <param name="x">Нижний левый угол</param>
        /// <param name="y">Нижний левый угол</param>
        /// <param name="width">Верхний правый угол</param>
        /// <param name="height">Верхний правый угол</param>
        /// <param name="thickness">Толщина выдавливания</param>
        public void CreateShelf(int x, int y, int width, 
            int height, int thickness)
        {
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOY);
            
            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            //Построение прямоугольника
            var rectangleParam = (ksRectangleParam)_connector
                .Kompas
                .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);

            rectangleParam.x = x;
            rectangleParam.y = y;
            rectangleParam.ang = 0;
            rectangleParam.width = width;
            rectangleParam.height = height;
            rectangleParam.style = 1;

            doc2D.ksRectangle(rectangleParam);
            
            sketchDefinition.EndEdit();

            //Выдавливание детали
            PressOutSketch(sketchDefinition, thickness);
        }

        //TODO: узнать о количестве отверстий
        /// <summary>
        /// Создание отверстий по заданным параметрам
        /// </summary>
        /// <param name="x">Х-координата центра окружности</param>
        /// <param name="y">У-координата центра окружности</param>
        /// <param name="thickness">Глубина вырезания</param>
        public void CreateHoles(int x, int y, int thickness)
        {
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOY);

            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            doc2D.ksCircle(x, y, 4, 1);

            sketchDefinition.EndEdit();

            PressOutSketch(sketchDefinition, thickness);
        }

        //TODO: доделать скругление
        /// <summary>
        /// Скругление (фаска) внешних углов
        /// </summary>
        public void Chamfler(ksSketchDefinition sketchDefinition)
        {
            var extrusionEntity = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_fillet);

            var extrusionDefinition =
                (ksFilletDefinition)extrusionEntity
                    .GetDefinition();

            //transref - направление (true - прямое направление)
            //distance1 - первый катет фаски
            //distance2 - второй катет фаски
            extrusionDefinition.radius = 5;
            extrusionDefinition.tangent = false;
            
            extrusionEntity.Create();
        }
    }
}
