using System;
using NUnit.Framework;
using ShelvesParameters;

namespace Shelves.UnitTests
{
    [TestFixture]
    class ParametersTest
    {
        //TODO: 
        private static readonly Parameters SourceParameters = new Parameters();

        [TestCase(ParameterName.Thickness, 17,
            TestName = "Позитивный тест геттера Thickness")]
        [TestCase(ParameterName.Length, 600,
            TestName = "Позитивный тест геттера Length")]
        [TestCase(ParameterName.Width, 250,
            TestName = "Позитивный тест геттера Width")]
        [TestCase(ParameterName.LeftWallHeight, 175,
            TestName = "Позитивный тест геттера LeftWallHeight")]
        [TestCase(ParameterName.RightWallHeight, 125,
            TestName = "Позитивный тест геттера RightWallHeight")]
        [TestCase(ParameterName.CommonWallHeight, 317,
            TestName = "Позитивный тест геттера CommonWallHeight")]
        [TestCase(ParameterName.Radius, 40,
            TestName = "Позитивный тест геттера Radius")]
        public void GetParameter_GetCorrectValue(ParameterName parameterName, int expected)
        {
            //Act
            var actual = SourceParameters.GetValue(parameterName);

            //Assert
            Assert.AreEqual(expected, actual, "Возвращенное значение" +
                                              $"параметра: {parameterName} " +
                                              "не соответствует ожидаемому");
        }

        [TestCase(true, TestName = "Позитивный тест геттера Rounding")]
        public void Rounding_GetCorrectValue(bool expected)
        {
            //Act
            var actual = SourceParameters.Rounding;

            //Assert
            Assert.AreEqual(expected, actual,
                "Возвращенное значение не соответствует ожидаемому");
        }

        [TestCase(10,
            TestName = "Негативный тест геттера неправильного switch")]
        public void GetParameter_GetIncorrectSwitch(ParameterName parameterName)
        {
            //Set
            var expected = 0;

            //Act
            var actual = SourceParameters.GetValue(parameterName);

            //Assert
            Assert.AreEqual(expected, actual, "Возвращенное значение" +
                                              "при неправильном switch" +
                                              "не соответствует ожидаемому");
        }

        [TestCase(ParameterName.Thickness, 17,
            TestName = "Позитивный тест сеттера Thickness")]
        [TestCase(ParameterName.Length, 600,
            TestName = "Позитивный тест сеттера Length")]
        [TestCase(ParameterName.Width, 250,
            TestName = "Позитивный тест сеттера Width")]
        [TestCase(ParameterName.LeftWallHeight, 175,
            TestName = "Позитивный тест сеттера LeftWallHeight")]
        [TestCase(ParameterName.RightWallHeight, 125,
            TestName = "Позитивный тест сеттера RightWallHeight")]
        [TestCase(ParameterName.CommonWallHeight, 0,
            TestName = "Позитивный тест сеттера Radius")]
        [TestCase(ParameterName.Radius, 40,
            TestName = "Позитивный тест сеттера Radius")]
        public void SetParameter_SetCorrectValue(ParameterName parameterName, int value)
        {
            //Assert
            Assert.DoesNotThrow(
                () => { SourceParameters.SetValue(parameterName, value); },
                "Установленное значение не вошло в допустимый диапазон значений"
                + $"параметра: {parameterName} ");
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
        public void SetParameter_SetIncorrectSwitch(ParameterName parameterName, int value)
        {
            //Assert
            Assert.DoesNotThrow(
                () => { SourceParameters.SetValue(parameterName, value); },
                "При некорректном switch ничего не произошло");
        }

        [TestCase(ParameterName.Thickness, 10,
            TestName = "Тест сеттера Thickness со значением меньше минимума")]
        [TestCase(ParameterName.Thickness, 30,
            TestName = "Тест сеттера Thickness со значением больше максимума")]
        [TestCase(ParameterName.Length, 400,
            TestName = "Тест сеттера Length со значением меньше минимума")]
        [TestCase(ParameterName.Length, 800,
            TestName = "Тест сеттера Length со значением больше максимума")]
        [TestCase(ParameterName.Width, 100,
            TestName = "Тест сеттера Width со значением меньше минимума")]
        [TestCase(ParameterName.Width, 400,
            TestName = "Тест сеттера Width со значением больше максимума")]
        [TestCase(ParameterName.LeftWallHeight, 100,
            TestName = "Тест сеттера LeftWallHeight со значением меньше минимума")]
        [TestCase(ParameterName.LeftWallHeight, 300,
            TestName = "Тест сеттера LeftWallHeight со значением больше максимума")]
        [TestCase(ParameterName.RightWallHeight, 50,
            TestName = "Тест сеттера RightWallHeight со значением меньше минимума")]
        [TestCase(ParameterName.RightWallHeight, 200,
            TestName = "Тест сеттера RightWallHeight со значением больше максимума")]
        [TestCase(ParameterName.CommonWallHeight, 100,
            TestName = "Тест сеттера CommonWallHeight со значением, не равным нулю")]
        [TestCase(ParameterName.Radius, 20,
            TestName = "Тест сеттера Radius со значением меньше минимума")]
        [TestCase(ParameterName.Radius, 60,
            TestName = "Тест сеттера Radius со значением больше максимума")]
        public void SetParameter_SetOutOfRangeValue(ParameterName parameterName, int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { SourceParameters.SetValue(parameterName, value); },
                "Не входящее в диапазон значение не выбросило исключение для "
                + $"параметра: {parameterName} ");
        }
        
        [TestCase(130, "Исключение из-за неправильной зависимости" +
                       " параметров: разница меньше 50",
            TestName = "Тест сеттера RightWallHeight " +
                            "с меньшей разницей зависимости от LeftWallHeight")]
        [TestCase(120, "Исключение из-за неправильной зависимости" +
                       "параметров: разница больше 50",
            TestName = "Тест сеттера RightWallHeight " +
                       "с большей разницей зависимости от LeftWallHeight")]
        public void RightWallHeight_SetWrongValue(int wrongValue, string message)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { SourceParameters.RightWallHeight = wrongValue; },
                message);
        }

        [TestCase(17, 600, 250, 175, 125,
            0, true, 40, "по умолчанию", -1,
            TestName = "Позитивный тест на конструктор по умолчанию")]
        [TestCase(15, 500, 200, 150, 100,
            0, true, 30, "минимума", 0,
            TestName = "Позитивный тест на конструктор минимальных значений")]
        [TestCase(20, 700, 300, 200, 150,
            0, true, 50, "максимума", 1,
            TestName = "Позитивный тест на конструктор максимальных значений")]
        public void ParametersSettings_SetCorrectValue(int thickness,
            int length, int width, int leftwall, int rightwall, int commonwall,
            bool rounding, int radius, string name, int count)
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
            var actual = new Parameters();
            switch (count)
            {
                case 0:
                    actual.MinParameters();
                    break;
                case 1:
                    actual.MaxParameters();
                    break;
            }

            bool check = expected.Thickness == actual.Thickness
                         && expected.Length == actual.Length
                         && expected.Width == actual.Width
                         && expected.LeftWallHeight == actual.LeftWallHeight
                         && expected.RightWallHeight == actual.RightWallHeight
                         && expected.CommonWallHeight == actual.CommonWallHeight
                         && expected.Radius == actual.Radius
                         && expected.Rounding == actual.Rounding;

            //Assert
            Assert.IsTrue(check, "Параметры " + $"{name} не совпали");
        }
    }
}
