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
        /// <param name="value">Присваиваемое значение</param>
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
        /// Возвращает или задает значение
        /// наличия задней стенки
        /// </summary>
        public bool BackShelf { get; set; }

        /// <summary>
        /// Возвращает или задает значение
        /// наличия отверстий для подвеса
        /// </summary>
        public bool Holes { get; set; }

        /// <summary>
        /// Возвращает или задает значение
        /// наличия скругления внешних углов
        /// </summary>
        public bool Rounding { get; set; }

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
                    throw new ArgumentException
                        ("Разность между левой и " +
                         "правой стенкой не равна 50");
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
            private set => _commonWallHeight = value + Thickness 
                                                     + LeftWallHeight 
                                                     + RightWallHeight;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Parameters()
        {

        }

        /// <summary>
        /// Конструктор класса Parameters с установленными
        /// значениями по умолчанию
        /// </summary>
        /// <param name="switchConstr">
        /// 0 - параметры по умолчанию;
        /// 1 - минимальные параметры;
        /// 2 - максимальные параметры
        /// </param>
        public Parameters(int switchConstr)
        {
            switch (switchConstr)
            {
                case 0:
                    DefaulParameters();
                    break;
                case 1:
                    MinParameters();
                    break;
                case 2:
                    MaxParameters();
                    break;
            }
        }

        /// <summary>
        /// Присвоение значений по умолчанию
        /// </summary>
        private void DefaulParameters()
        {
            Thickness = 17;
            Length = 600;
            Width = 250;
            LeftWallHeight = 175;
            RightWallHeight = 125;
            CommonWallHeight = 0;
            BackShelf = true;
            Holes = true;
            Rounding = true;
        }

        /// <summary>
        /// Присвоение минимальных значений
        /// </summary>
        private void MinParameters()
        {
            Thickness = 15;
            Length = 500;
            Width = 200;
            LeftWallHeight = 150;
            RightWallHeight = 100;
            CommonWallHeight = 0;
            BackShelf = true;
            Holes = true;
            Rounding = true;
        }

        /// <summary>
        /// Присвоение максимальных значений
        /// </summary>
        private void MaxParameters()
        {
            Thickness = 20;
            Length = 700;
            Width = 300;
            LeftWallHeight = 200;
            RightWallHeight = 150;
            CommonWallHeight = 0;
            BackShelf = true;
            Holes = true;
            Rounding = true;
        }

        /// <summary>
        /// Конструктор класса Parameters
        /// </summary>
        /// <param name="thickness">Толщина досок</param>
        /// <param name="length">Длина полок</param>
        /// <param name="width">Ширина полок</param>
        /// <param name="leftWallHeight">Высота левой стенки</param>
        /// <param name="rightWallHeight">Высота правой стенки</param>
        /// <param name="backShelf">Наличие задней стенки</param>
        /// <param name="holes">Наличие отверстий для подвеса</param>
        /// <param name="rounding">Скругление внешних углов</param>
        public Parameters(int thickness, int length, int width, 
            int leftWallHeight, int rightWallHeight, bool backShelf,
            bool holes, bool rounding)
        {
            Thickness = thickness;
            Length = length;
            Width = width;
            LeftWallHeight = leftWallHeight;
            RightWallHeight = rightWallHeight;
            CommonWallHeight = 0;
            BackShelf = backShelf;
            Holes = holes;
            Rounding = rounding;
        }
    }
}
