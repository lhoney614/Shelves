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
                _commonWallHeight = value + Thickness
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
        /// <param name="parameter">Имя параметра</param>
        /// <param name="value">Значение</param>
        public void SetValue(Parameter parameter, int value)
        {
            switch (parameter)
            {
                case Parameter.Thickness:
                {
                    Thickness = value;
                    break;
                }
                case Parameter.Length:
                {
                    Length = value;
                    break;
                }
                case Parameter.Width:
                {
                    Width = value;
                    break;
                }
                case Parameter.LeftWallHeight:
                {
                    LeftWallHeight = value;
                    break;
                }
                case Parameter.RightWallHeight:
                {
                    RightWallHeight = value;
                    break;
                }
                case Parameter.CommonWallHeight:
                {
                    CommonWallHeight = value;
                    break;
                }
                case Parameter.Radius:
                {
                    Radius = value;
                    break;
                }
            }
        }

        /// <summary>
        /// Возвращает значение по названию параметра
        /// </summary>
        /// <param name="parameter">Имя параметра</param>
        public int GetValue(Parameter parameter)
        {
            switch (parameter)
            {
                case Parameter.Thickness:
                {
                    return Thickness;
                }
                case Parameter.Length:
                {
                    return Length;
                }
                case Parameter.Width:
                {
                    return Width;
                }
                case Parameter.LeftWallHeight:
                {
                    return LeftWallHeight;
                }
                case Parameter.RightWallHeight:
                {
                    return RightWallHeight;
                }
                case Parameter.CommonWallHeight:
                {
                    return CommonWallHeight;
                }
                case Parameter.Radius:
                {
                    return Radius;
                }
            }

            return 0;
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
            Rounding = true;
            Radius = 40;
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
            Rounding = true;
            Radius = 30;
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
            Rounding = true;
            Radius = 50;
        }

        /// <summary>
        /// Возвращает результат сравнения двух объектов Parameters
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Parameters)obj);
        }

        /// <summary>
        /// Возвращает результат сравнения двух объектов Parameters
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(Parameters other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return _thickness == other._thickness 
                   && _length == other._length 
                   && _width == other._width 
                   && _leftWallHeight == other._leftWallHeight 
                   && _rightWallHeight == other._rightWallHeight 
                   && _commonWallHeight == other._commonWallHeight 
                   && _radius == other._radius && Rounding == other.Rounding;
        }

        /// <summary>
        /// Возвращает некоторое числовое значение,
        /// которое будет соответствовать данному объекту или его хэш-код
        /// С помощью него можно сравнивать объекты
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _thickness;
                hashCode = (hashCode * 397) ^ _length;
                hashCode = (hashCode * 397) ^ _width;
                hashCode = (hashCode * 397) ^ _leftWallHeight;
                hashCode = (hashCode * 397) ^ _rightWallHeight;
                hashCode = (hashCode * 397) ^ _commonWallHeight;
                hashCode = (hashCode * 397) ^ _radius;
                hashCode = (hashCode * 397) ^ Rounding.GetHashCode();
                return hashCode;
            }
        }
    }
}
