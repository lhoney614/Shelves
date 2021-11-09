using System;
using System.Drawing;
using System.Windows.Forms;
using ShelvesParameters;

namespace Shelves.UI
{
    /// <summary>
    /// Главная форма для ввода параметров
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Создание переменной типа Parameters
        /// Хранит вводимые в форме параметры
        /// </summary>
        private Parameters _parameters;

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
        /// Загрузка главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _parameters = new Parameters();
        }

        /// <summary>
        /// Проверка на соответствие вводимых данных типу int
        /// </summary>
        /// <param name="textBox">ссылка на соответствующий TextBox</param>
        /// <returns></returns>
        public int CheckValueType(ref TextBox textBox)
        {
            try
            {
                var value = Convert.ToInt32(textBox.Text);
                toolTip1.SetToolTip(textBox, "");
                return value;
            }
            catch (Exception)
            {
                toolTip1.SetToolTip(textBox, "Недопустимые символы");
                textBox.BackColor = Color.DarkSalmon;
                return 0;
            }
        }

        /// <summary>
        /// Толщина досок, из которых будут сделаны полки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            _thickness = CheckValueType(ref textBoxA);
            if (_thickness == 0) return;

            try
            {
                _parameters.Thickness = _thickness;
                textBoxA.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBoxA.BackColor = Color.DarkSalmon;
                toolTip1.SetToolTip(textBoxA, exception.Message);
            }
        }

        /// <summary>
        /// Длина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            _length = CheckValueType(ref textBoxB);
            if (_length == 0) return;

            try
            {
                _parameters.Length = _length;
                textBoxB.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBoxB.BackColor = Color.DarkSalmon;
                toolTip1.SetToolTip(textBoxB, exception.Message);
            }
        }

        /// <summary>
        /// Ширина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxC_TextChanged(object sender, EventArgs e)
        {
            _width = CheckValueType(ref textBoxC);
            if (_width == 0) return;

            try
            {
                _parameters.Width = _width;
                textBoxC.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBoxC.BackColor = Color.DarkSalmon;
                toolTip1.SetToolTip(textBoxC, exception.Message);
            }
        }

        /// <summary>
        /// Высота левой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxD_TextChanged(object sender, EventArgs e)
        {
            _leftWallHeight = CheckValueType(ref textBoxD);
            if (_leftWallHeight == 0) return;

            try
            {
                _parameters.LeftWallHeight = _leftWallHeight;
                textBoxD.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBoxD.BackColor = Color.DarkSalmon;
                toolTip1.SetToolTip(textBoxD, exception.Message);
            }
        }

        /// <summary>
        /// Высота правой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxE_TextChanged(object sender, EventArgs e)
        {
            _rightWallHeight = CheckValueType(ref textBoxE);
            if (_rightWallHeight == 0) return;

            try
            {
                _parameters.RightWallHeight = _rightWallHeight;
                textBoxE.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBoxE.BackColor = Color.DarkSalmon;
                toolTip1.SetToolTip(textBoxE, exception.Message);
            }
        }

        /// <summary>
        /// Построение 3D-модели подвесных полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            try
            {
                _parameters = new Parameters(_thickness, _length, _width, _leftWallHeight, _rightWallHeight);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Проверьте правильность введенных значений на соответствие с допустимыми границами",
                    @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
