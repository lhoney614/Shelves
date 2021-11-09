using System;

namespace ShelvesParameters
{
    public class Parameters
    {
        private int _thickness;
        private int _length;
        private int _width;
        private int _leftWallHeight;
        private int _rightWallHeight;
        private int _commonWallHeight;

        /// <summary>
        /// Возвращает или задает значение толщины досок
        /// </summary>
        public int Thickness
        {
            get => _thickness;
            set
            {
                if (value < 15 || value > 20)
                {
                    throw new ArgumentException("Значение толщины вне диапазона");
                }

                _thickness = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение длины полок
        /// </summary>
        public int Length
        {
            get => _length;
            set
            {
                if (value < 500 || value > 700)
                {
                    throw new ArgumentException("Значение длины полок вне диапазона");
                }

                _length = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение ширины полок
        /// </summary>
        public int Width
        {
            get => _width;
            set
            {
                if (value < 200 || value > 300)
                {
                    throw new ArgumentException("Значение ширины полок вне диапазона");
                }

                _width = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение высоты левой стенки
        /// </summary>
        public int LeftWallHeight
        {
            get => _leftWallHeight;
            set
            {
                if (value < 150 || value > 200)
                {
                    throw new ArgumentException("Значение длины полок вне диапазона");
                }

                _leftWallHeight = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение высоты правой стенки
        /// </summary>
        public int RightWallHeight
        {
            get => _rightWallHeight;
            set
            {
                if (value < 100 || value > 150)
                {
                    throw new ArgumentException("Значение длины полок вне диапазона");
                }

                if (LeftWallHeight - value != 50)
                {
                    throw new ArgumentException("Разность между левой и правой стенкой не равна 50");
                }

                _rightWallHeight = value;
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

        /// <summary>
        /// Пустой конструктор класса Parameters
        /// </summary>
        public Parameters() { }

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
