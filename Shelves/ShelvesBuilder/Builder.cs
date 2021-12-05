using APIConnector;
using ShelvesParameters;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace ShelvesBuilder
{
    public class Builder
    {
        /// <summary>
        /// Коннектор для работы с Компас-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Параметры полок
        /// </summary>
        private Parameters _parameters;

        public Builder(Parameters param)
        {
            _parameters = param;
            _connector = new KompasConnector();
            _connector.GetNewPart();

            //Левая крайняя дощечка
            CreateVerticalShelf(1);

            //Задняя дощечка верхней полки
            CreateBackShelf(1);

            //Нижняя дощечка верхней полки
            CreateDownShelf(1);

            //Общая дощечка
            CreateVerticalShelf(2);

            //Задняя дощечка нижней полки
            CreateBackShelf(2);

            //Нижняя дощечка нижней полки
            CreateDownShelf(2);

            //Правая крайняя дощечка
            CreateVerticalShelf(3);
        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="planeType">Выбор плоскости</param>
        /// <returns>ksSketchDefinition</returns>
        public ksSketchDefinition CreateSketch(Obj3dType planeType)
        {
            //Элемент модели по умолчанию
            var plane = (ksEntity)_connector
                .KsPart
                .GetDefaultEntity((short)planeType);

            //Создать новый интерфейс объекта и получить указатель на него
            var sketch = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_sketch);


            //Получить указатель на интерфейс параметров объектов или элементов
            var sketchDef = (ksSketchDefinition)sketch.GetDefinition();

            //Изменить базовую плоскость эскиза
            sketchDef.SetPlane(plane);

            //Создать объект в модели
            sketch.Create();
            return sketchDef;
        }

        /// <summary>
        /// Выдавливание по эскизу
        /// </summary>
        /// <param name="sketchDefinition">Эскиз</param>
        /// <param name="thickness">Толщина</param>
        /// <param name="side">Направление выдавливания</param>
        private void PressOutSketch(
            ksSketchDefinition sketchDefinition,
            double thickness,
            bool side = true)
        {
            const ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossExtrusion;

            //Создать новый интерфейс объекта и получить указатель на него
            var extrusionEntity = (ksEntity)_connector.KsPart.NewEntity((short)type);
            
            //Интерфейс приклеенного элемента выдавливания
            var extrusionDefinition = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

            //Установить параметры выдавливания в одном направлении
            //side - направление
            //тип выдавливания (строго на глубину)
            //глубина выдавливания
            extrusionDefinition.SetSideParam(side, (short)End_Type.etBlind, thickness);
            extrusionDefinition.directionType = side
            //прямое направление (наружу)
                ? (short)Direction_Type.dtNormal
            //обратное направление (внутрь)
                : (short)Direction_Type.dtReverse;

            //Изменить указатель на интерфейс эскиза элемента
            extrusionDefinition.SetSketch(sketchDefinition);
            
            //Создать объект в модели
            extrusionEntity.Create();
        }

        /// <summary>
        /// Создает заднюю дощечку обеих полок
        /// </summary>
        /// <param name="typeShelf">Верхняя или нижняя полка</param>
        public void CreateBackShelf(int typeShelf)
        {
            switch (typeShelf)
            {
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        /// <summary>
        /// Создает нижнюю дощечку обеих полок
        /// </summary>
        /// <param name="typeShelf">Верхняя или нижняя полка</param>
        public void CreateDownShelf(int typeShelf)
        {
            switch (typeShelf)
            {
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        /// <summary>
        /// Создает вертикальные дощечки:
        /// левую крайнюю, правую крайнюю и общую
        /// </summary>
        /// <param name="typeShelf">Тип одной из трех дощечек</param>
        public void CreateVerticalShelf(int typeShelf)
        {
            switch (typeShelf)
            {
                case 1:
                    //
                    //Obj3dType - это тип объекта документа-модели (плоскость XOY)
                    var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOY);
                    
                    //Войти в режим редактирования эскиза
                    var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

                    //Чертим прямоугольник по центру
                    //GetParamStruct - получить указатель на структуру
                    //StructType2DEnum - прямоугольник по центру
                    var rectangleParam = (ksRectangleParam)_connector
                        .Kompas
                        .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);

                    //Координаты базовой точки прямоугольника (одной из вершин)
                    rectangleParam.x = 0;
                    rectangleParam.y = 0;

                    //Угол вектор направление от первой точки ко второй
                    rectangleParam.ang = 0;

                    //Высота и ширина прямоугольника
                    rectangleParam.height = _parameters.LeftWallHeight;
                    rectangleParam.width = _parameters.Width;

                    //Стиль линии - основная
                    rectangleParam.style = 1;

                    //Создать прямоугольник по этим параметрам
                    doc2D.ksRectangle(rectangleParam);

                    //Выйти из режима редактирования эскиза
                    sketchDefinition.EndEdit();

                    //Выдавливание детали
                    PressOutSketch(sketchDefinition, _parameters.Thickness);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

       
    }
}
