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
        private Parameters _sourceParameters;
        
        [SetUp]
        public void SetSourceParameters()
        {
            _sourceParameters = new Parameters
            {
                Thickness = 17,
                Length = 600,
                Width = 250,
                LeftWallHeight = 175,
                RightWallHeight = 125
            };
        }

        [TestCase(TestName = "Позитивный тест геттера Thickness")]
        public void Thickness_GetCorrectValue()
        {
            //Setup
            var expected = 17;

            //Act
            var actual = _sourceParameters.Thickness;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест сеттера Thickness")]
        public void Thickness_SetCorrectValue()
        {
            //Setup
            var expected = _sourceParameters.Thickness;

            //Act
            _sourceParameters.Thickness = expected;
            var actual = _sourceParameters.Thickness;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, TestName = "Тест сеттера Thickness со значением меньше минимума")]
        [TestCase(30, TestName = "Тест сеттера Thickness со значением больше максимума")]
        public void Thickness_SetOutOfRangeValue(int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { _sourceParameters.Thickness = value; },
                "Исключение: присваиваемое значение вне диапазона");
        }

        [TestCase(TestName = "Позитивный тест геттера Length")]
        public void Length_GetCorrectValue()
        {
            //Setup
            var expected = 600;

            //Act
            var actual = _sourceParameters.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест сеттера Length")]
        public void Length_SetCorrectValue()
        {
            //Setup
            var expected = _sourceParameters.Length;

            //Act
            _sourceParameters.Length = expected;
            var actual = _sourceParameters.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(400, TestName = "Тест сеттера Length со значением меньше минимума")]
        [TestCase(800, TestName = "Тест сеттера Length со значением больше максимума")]
        public void Length_SetOutOfRangeValue(int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { _sourceParameters.Length = value; },
                "Исключение: присваиваемое значение вне диапазона");
        }

        [TestCase(TestName = "Позитивный тест геттера Width")]
        public void Width_GetCorrectValue()
        {
            //Setup
            var expected = 250;

            //Act
            var actual = _sourceParameters.Width;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест сеттера Width")]
        public void Width_SetCorrectValue()
        {
            //Setup
            var expected = _sourceParameters.Width;

            //Act
            _sourceParameters.Width = expected;
            var actual = _sourceParameters.Width;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, TestName = "Тест сеттера Width со значением меньше минимума")]
        [TestCase(400, TestName = "Тест сеттера Width со значением больше максимума")]
        public void Width_SetOutOfRangeValue(int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { _sourceParameters.Width = value; },
                "Исключение: присваиваемое значение вне диапазона");
        }

        [TestCase(TestName = "Позитивный тест геттера LeftWallHeight")]
        public void LeftWallHeight_GetCorrectValue()
        {
            //Setup
            var expected = 175;

            //Act
            var actual = _sourceParameters.LeftWallHeight;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест сеттера LeftWallHeight")]
        public void LeftWallHeight_SetCorrectValue()
        {
            //Setup
            var expected = _sourceParameters.LeftWallHeight;

            //Act
            _sourceParameters.LeftWallHeight = expected;
            var actual = _sourceParameters.LeftWallHeight;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, TestName = "Тест сеттера LeftWallHeight со значением меньше минимума")]
        [TestCase(300, TestName = "Тест сеттера LeftWallHeight со значением больше максимума")]
        public void LeftWallHeight_SetOutOfRangeValue(int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { _sourceParameters.LeftWallHeight = value; },
                "Исключение: присваиваемое значение вне диапазона");
        }

        [TestCase(TestName = "Позитивный тест геттера RightWallHeight")]
        public void RightWallHeight_GetCorrectValue()
        {
            //Setup
            var expected = 125;

            //Act
            var actual = _sourceParameters.RightWallHeight;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест сеттера RightWallHeight")]
        public void RightWallHeight_SetCorrectValue()
        {
            //Setup
            var expected = _sourceParameters.RightWallHeight;

            //Act
            _sourceParameters.RightWallHeight = expected;
            var actual = _sourceParameters.RightWallHeight;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(50, TestName = "Тест сеттера RightWallHeight со значением меньше минимума")]
        [TestCase(200, TestName = "Тест сеттера RightWallHeight со значением больше максимума")]
        public void RightWallHeight_SetOutOfRangeValue(int value)
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () => { _sourceParameters.RightWallHeight = value; },
                "Исключение: присваиваемое значение вне диапазона");
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
                () => { _sourceParameters.RightWallHeight = wrongValue; },
                message);
        }
    }
}
