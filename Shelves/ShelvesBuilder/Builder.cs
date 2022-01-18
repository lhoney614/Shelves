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

            if (parameters.Rounding)
            {
                var x = parameters.Thickness / 2;
                var y = parameters.LeftWallHeight + parameters.Thickness;
                var z = parameters.Width;

                CreateFillet(parameters.Radius, x, y, z);
            }

            //Нижняя дощечка верхней полки
            CreateShelf(parameters.Thickness, 0, parameters.Length,
                parameters.Thickness, parameters.Width);


            //Задняя дощечка верхней полки
            CreateShelf(parameters.Thickness, parameters.Thickness,
                parameters.Length, parameters.RightWallHeight,
                parameters.Thickness);
            
            //Общая стенка
            CreateShelf(parameters.Length + parameters.Thickness, 
                - parameters.CommonWallHeight + parameters.RightWallHeight, 
                parameters.Thickness,
                parameters.CommonWallHeight + parameters.Thickness,
                parameters.Width);

            if (parameters.Rounding)
            {
                var x = parameters.Length 
                        + parameters.Thickness 
                        + parameters.Thickness / 2;
                var y = parameters.RightWallHeight + parameters.Thickness;
                var z = parameters.Width;

                CreateFillet(parameters.Radius, x, y, z);
            }

            //Задняя дощечка нижней полки
            CreateShelf(parameters.Length + parameters.Thickness * 2,
                -parameters.CommonWallHeight + parameters.RightWallHeight,
                parameters.Length, parameters.Thickness,
                parameters.Width);

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

            if (parameters.Rounding)
            {
                var x = parameters.Length * 2 + 
                        parameters.Thickness * 2 + 
                        parameters.Thickness / 2;
                var y = parameters.RightWallHeight 
                        - parameters.LeftWallHeight;
                var z = parameters.Width;

                CreateFillet(parameters.Radius, x, y, z);
            }


        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="planeType">Выбор плоскости</param>
        /// <returns>ksSketchDefinition</returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType)
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
        /// Создание дощечки по заданным параметрам
        /// </summary>
        /// <param name="x">Нижний левый угол</param>
        /// <param name="y">Нижний левый угол</param>
        /// <param name="width">Верхний правый угол</param>
        /// <param name="height">Верхний правый угол</param>
        /// <param name="thickness">Толщина выдавливания</param>
        private void CreateShelf(int x, int y, int width, 
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
        
        /// <summary>
        /// Скругление (фаска) внешних углов
        /// </summary>
        private void CreateFillet(int radius,
            double x, double y, double z)
        {
            var filletEntity = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_fillet);

            var filletDefinition =
                (ksFilletDefinition)filletEntity
                    .GetDefinition();

            //tangent - продолжать скругление по касательным
            //ребрам
            filletDefinition.radius = radius;
            filletDefinition.tangent = true;

            var iArray = filletDefinition.array();
            var iCollection = _connector
                .KsPart
                .EntityCollection((short)Obj3dType.o3d_edge);

            iCollection.SelectByPoint(x, y, z);
            var iEdge = iCollection.Last();
            
            iArray.Add(iEdge);

            filletEntity.Create();
        }
    }
}
