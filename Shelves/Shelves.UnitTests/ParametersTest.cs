using System;
using NUnit.Framework;
using ShelvesParameters;

namespace Shelves.UnitTests
{
    /// <summary>
    /// Определение класса юнит-тестирования
    /// </summary>
    [TestFixture]
    public class ParametersTest
    {
        private static readonly Parameters SourceParameters = new Parameters(0);

        [TestCase(Parameter.Thickness, 17, 
            TestName = "Позитивный тест геттера Thickness")]
        [TestCase(Parameter.Length, 600,
            TestName = "Позитивный тест геттера Length")]
        [TestCase(Parameter.Width, 250,
            TestName = "Позитивный тест геттера Width")]
        [TestCase(Parameter.LeftWallHeight, 175,
            TestName = "Позитивный тест геттера LeftWallHeight")]
        [TestCase(Parameter.RightWallHeight, 125,
            TestName = "Позитивный тест геттера RightWallHeight")]
        [TestCase(Parameter.CommonWallHeight, 317,
            TestName = "Позитивный тест геттера CommonWallHeight")]
        [TestCase(Parameter.Radius, 40,
            TestName = "Позитивный тест геттера Radius")]
        public void GetParameter_GetCorrectValue(Parameter parameter, int expected)
        {
            //Act
            var actual = SourceParameters.GetValue(parameter);

            //Assert
            Assert.AreEqual(expected, actual, "Возвращенное значение" +
                                              $"параметра: {parameter} "+
                                              "не соответствует ожидаемому");
        }

        [TestCase(TestName = "Позитивный тест геттера Rounding")]
        public void Rounding_GetCorrectValue()
        {
            //Act
            var actual = SourceParameters.Rounding;

            //Assert
            Assert.AreEqual(true, actual, 
                "Возвращенное значение не соответствует ожидаемому");
        }

        [TestCase(10,
            TestName = "Негативный тест геттера неправильного switch")]
        public void GetParameter_GetIncorrectSwitch(Parameter parameter)
        {
            //Set
            var expected = 0;

            //Act
            var actual = SourceParameters.GetValue(parameter);

            //Assert
            Assert.AreEqual(expected, actual, "Возвращенное значение" +
                                              "при неправильном switch" +
                                              "не соответствует ожидаемому");
        }
        
        [TestCase(Parameter.Thickness, 17,
            TestName = "Позитивный тест сеттера Thickness")]
        [TestCase(Parameter.Length, 600,
            TestName = "Позитивный тест сеттера Length")]
        [TestCase(Parameter.Width, 250,
            TestName = "Позитивный тест сеттера Width")]
        [TestCase(Parameter.LeftWallHeight, 175,
            TestName = "Позитивный тест сеттера LeftWallHeight")]
        [TestCase(Parameter.RightWallHeight, 125,
            TestName = "Позитивный тест сеттера RightWallHeight")]
        [TestCase(Parameter.CommonWallHeight, 0,
            TestName = "Позитивный тест сеттера Radius")]
        [TestCase(Parameter.Radius, 40,
            TestName = "Позитивный тест сеттера Radius")]
        public void SetParameter_SetCorrectValue(Parameter parameter, int value)
        {
            //Assert
            Assert.DoesNotThrow(
                () => {SourceParameters.SetValue(parameter, value); },
                "Установленное значение не вошло в допустимый диапазон значений" 
                + $"параметра: {parameter} ");
        }

        [TestCase(true, TestName = "Позитивный тест сеттера Rounding")]
        public void Rounding_SetCorrectValue(bool value)
        {
            //Act
            SourceParameters.Rounding = value;
            var actual = SourceParameters.Rounding;

            //Assert
            Assert.AreEqual(value, actual, "Ожидаемое и актуальное значение не совпали");
        }

        [TestCase(10, 100,
            TestName = "Негативный тест сеттера с неправильным switch")]
        public void SetParameter_SetIncorrectSwitch(Parameter parameter, int value)
        {
            //Assert
            Assert.DoesNotThrow(
                () => { SourceParameters.SetValue(parameter, value); },
                "При некорректном switch ничего не произошло");
        }

        [TestCase(Parameter.Thickness,10, 
            TestName = "Тест сеттера Thickness со значением меньше минимума")]
        [TestCase(Parameter.Thickness, 30, 
            TestName = "Тест сеттера Thickness со значением больше максимума")]
        [TestCase(Parameter.Length, 400, 
            TestName = "Тест сеттера Length со значением меньше минимума")]
        [TestCase(Parameter.Length, 800, 
            TestName = "Тест сеттера Length со значением больше максимума")]
        [TestCase(Parameter.Width, 100, 
            TestName = "Тест сеттера Width со значением меньше минимума")]
        [TestCase(Parameter.Width, 400,
            TestName = "Тест сеттера Width со значением больше максимума")]
        [TestCase(Parameter.LeftWallHeight, 100, 
            TestName = "Тест сеттера LeftWallHeight со значением меньше минимума")]
        [TestCase(Parameter.LeftWallHeight, 300, 
            TestName = "Тест сеттера LeftWallHeight со значением больше максимума")]
        [TestCase(Parameter.RightWallHeight, 50, 
            TestName = "Тест сеттера RightWallHeight со значением меньше минимума")]
        [TestCase(Parameter.RightWallHeight, 200, 
            TestName = "Тест сеттера RightWallHeight со значением больше максимума")]
        [TestCase(Parameter.CommonWallHeight, 100,
            TestName = "Тест сеттера CommonWallHeight со значением, не равным нулю")]
        [TestCase(Parameter.Radius, 20, 
            TestName = "Тест сеттера Radius со значением меньше минимума")]
        [TestCase(Parameter.Radius, 60, 
            TestName = "Тест сеттера Radius со значением больше максимума")]
        public void SetParameter_SetOutOfRangeValue(Parameter parameter, int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { SourceParameters.SetValue(parameter, value); },
                "Не входящее в диапазон значение не выбросило исключение для "
                + $"параметра: {parameter} ");
        }
        

        [TestCase(130, "Исключение из-за неправильной зависимости параметров: разница меньше 50", 
            TestName = "Тест сеттера RightWallHeight " +
                            "с меньшей разницей зависимости от LeftWallHeight")]
        [TestCase(120, "Исключение из-за неправильной зависимости параметров: разница больше 50",
            TestName = "Тест сеттера RightWallHeight " +
                       "с большей разницей зависимости от LeftWallHeight")]
        public void RightWallHeight_SetWrongValue(int wrongValue, string message)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { SourceParameters.RightWallHeight = wrongValue; },
                message);
        }

        [TestCase(0, 17, 600, 250, 175, 125,
            0, true, 40, "по умолчанию",
            TestName = "Позитивный тест на конструктор по умолчанию")]
        [TestCase(1, 15, 500, 200, 150, 100,
            0, true, 30, "по умолчанию",
            TestName = "Позитивный тест на конструктор минимальных значений")]
        [TestCase(2, 20, 700, 300, 200, 150,
            0, true, 50, "по умолчанию",
            TestName = "Позитивный тест на конструктор максимальных значений")]
        public void Constructor_SetCorrectSwitch(int switchCount, int thickness,
            int length, int width, int leftwall, int rightwall, int commonwall,
            bool rounding, int radius, string name)
        {
            //Set
            var expected = new Parameters
            {
                Thickness = thickness,
                Length = length,
                Width = width,
                LeftWallHeight = leftwall,
                RightWallHeight = rightwall,
                CommonWallHeight = commonwall,
                Rounding = rounding,
                Radius = radius
            };

            //Act
            var actual = new Parameters(switchCount);

            //Assert
            Assert.AreEqual(expected, actual, "Параметры " + $"{name} не совпали");
        }

        [TestCase(4, 
            TestName = "Негативный тест на некорректное значение switch")]
        public void Constructor_SetIncorrectSwitch(int switchCount)
        {
            //Set
            var expected = new Parameters();

            //Act
            var actual = new Parameters(switchCount);

            //Assert
            Assert.AreEqual(expected, actual, "При некорректном switch не создался пустой объект");
        }
    }
}
