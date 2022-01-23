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
        /// Радиус скругления углов
        /// </summary>
        private int _radius;
        
        /// <summary>
        /// Валидация значений параметров
        /// </summary>
        /// <param name="value">Присваиваемое значение</param>
        /// <param name="minValue">Минимальное значение параметра</param>
        /// <param name="maxValue">Максимальное значение параметра</param>
        private static int ValidationValue(int value, 
            int minValue, int maxValue)
        {
            if (value < minValue || value > maxValue)
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
            set
            {
                if (value != 0)
                {
                    throw new ArgumentException("Присваиваемое значение должно " +
                                                "равняться нулю, так как это поле " +
                                                "вычисляется из суммы трех других");
                }
                _commonWallHeight = Thickness
                                    + LeftWallHeight
                                    + RightWallHeight;
            } 
        }

        /// <summary>
        /// Возвращает или задает значение
        /// наличия скругления внешних углов
        /// </summary>
        public bool Rounding { get; set; }

        /// <summary>
        /// Возвращает или задает значение
        /// радиуса скругления внешних углов
        /// </summary>
        public int Radius
        {
            get => _radius;
            set => _radius = ValidationValue(value, 30, 50);
        }

        /// <summary>
        /// Устанавливает значение параметра по названию
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
        /// <param name="value">Значение</param>
        public void SetValue(ParameterName parameterName, int value)
        {
            switch (parameterName)
            {
                case ParameterName.Thickness:
                {
                    Thickness = value;
                    break;
                }
                case ParameterName.Length:
                {
                    Length = value;
                    break;
                }
                case ParameterName.Width:
                {
                    Width = value;
                    break;
                }
                case ParameterName.LeftWallHeight:
                {
                    LeftWallHeight = value;
                    break;
                }
                case ParameterName.RightWallHeight:
                {
                    RightWallHeight = value;
                    break;
                }
                case ParameterName.CommonWallHeight:
                {
                    CommonWallHeight = value;
                    break;
                }
                case ParameterName.Radius:
                {
                    Radius = value;
                    break;
                }
            }
        }

        /// <summary>
        /// Возвращает значение по названию параметра
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
        public int GetValue(ParameterName parameterName)
        {
            switch (parameterName)
            {
                case ParameterName.Thickness:
                {
                    return Thickness;
                }
                case ParameterName.Length:
                {
                    return Length;
                }
                case ParameterName.Width:
                {
                    return Width;
                }
                case ParameterName.LeftWallHeight:
                {
                    return LeftWallHeight;
                }
                case ParameterName.RightWallHeight:
                {
                    return RightWallHeight;
                }
                case ParameterName.CommonWallHeight:
                {
                    return CommonWallHeight;
                }
                case ParameterName.Radius:
                {
                    return Radius;
                }
            }

            return 0;
        }
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Parameters()
        {
            Thickness = 17;
            Length = 600;
            Width = 250;
            LeftWallHeight = 175;
            RightWallHeight = 125;
            CommonWallHeight = 0;
            Rounding = true;
            Radius = 40;
        }
        
        /// <summary>
        /// Присвоение минимальных значений
        /// </summary>
        public void MinParameters()
        {
            Thickness = 15;
            Length = 500;
            Width = 200;
            LeftWallHeight = 150;
            RightWallHeight = 100;
            CommonWallHeight = 0;
            Rounding = true;
            Radius = 30;
        }

        /// <summary>
        /// Присвоение максимальных значений
        /// </summary>
        public void MaxParameters()
        {
            Thickness = 20;
            Length = 700;
            Width = 300;
            LeftWallHeight = 200;
            RightWallHeight = 150;
            CommonWallHeight = 0;
            Rounding = true;
            Radius = 50;
        }
    }
}
