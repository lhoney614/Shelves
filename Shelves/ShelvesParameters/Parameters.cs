using System;

namespace ShelvesParameters
{
    /// <summary>
    /// Класс логики, хранящий значения параметров полок
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Толщина досок
        /// </summary>
        private int _thickness;

        /// <summary>
        /// Длина полок
        /// </summary>
        private int _length;

        /// <summary>
        /// Ширина полок
        /// </summary>
        private int _width;

        /// <summary>
        /// Высота левой стенки
        /// </summary>
        private int _leftWallHeight;

        /// <summary>
        /// Высота правой стенки
        /// </summary>
        private int _rightWallHeight;

        /// <summary>
        /// Высота общей стенки
        /// </summary>
        private int _commonWallHeight;

        /// <summary>
        /// Валидация значений параметров
        /// </summary>
        /// <param name="value">Значение, которое должно быть присвоено</param>
        /// <param name="min">Минимальное значение параметра</param>
        /// <param name="max">Максимальное значение параметра</param>
        private static int ValidationValue(int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Значение вне диапазона");
            }

            return value;
        }

        /// <summary>
        /// Возвращает или задает значение толщины досок
        /// </summary>
        public int Thickness
        {
            get => _thickness;
            set => _thickness = ValidationValue(value, 15, 20);
        }

        /// <summary>
        /// Возвращает или задает значение длины полок
        /// </summary>
        public int Length
        {
            get => _length;
            set => _length = ValidationValue(value, 500, 700);
        }

        /// <summary>
        /// Возвращает или задает значение ширины полок
        /// </summary>
        public int Width
        {
            get => _width;
            set => _width = ValidationValue(value, 200, 300);
        }

        /// <summary>
        /// Возвращает или задает значение высоты левой стенки
        /// </summary>
        public int LeftWallHeight
        {
            get => _leftWallHeight;
            set => _leftWallHeight = ValidationValue(value, 150, 200);
        }

        /// <summary>
        /// Возвращает или задает значение высоты правой стенки
        /// </summary>
        public int RightWallHeight
        {
            get => _rightWallHeight;
            set
            {
                if (LeftWallHeight - value != 50)
                {
                    throw new ArgumentException("Разность между левой и правой стенкой не равна 50");
                }

                _rightWallHeight = ValidationValue(value, 100, 150);
            }
        }

        /// <summary>
        /// Возвращает или задает значение общей стенки
        /// </summary>
        public int CommonWallHeight
        {
            get => _commonWallHeight;
            private set => _commonWallHeight = value + Thickness + LeftWallHeight + RightWallHeight;
        }

        //TODO: default params
        /// <summary>
        /// Пустой конструктор класса Parameters
        /// </summary>
        public Parameters()
        {

        }

        /// <summary>
        /// Конструктор класса Parameters
        /// </summary>
        /// <param name="thickness">толщина досок</param>
        /// <param name="length">длина полок</param>
        /// <param name="width">ширина полок</param>
        /// <param name="leftWallHeight">высота левой стенки</param>
        /// <param name="rightWallHeight">высота правой стенки</param>
        public Parameters(int thickness, int length, int width, int leftWallHeight, int rightWallHeight)
        {
            Thickness = thickness;
            Length = length;
            Width = width;
            LeftWallHeight = leftWallHeight;
            RightWallHeight = rightWallHeight;
            CommonWallHeight = 0;
        }
    }
}
