using System;
using System.Drawing;
using System.Windows.Forms;
using ShelvesParameters;

namespace Shelves.UI
{
    public partial class MainForm : Form
    {
        private Parameters _parameters;

        public MainForm()
        {
            InitializeComponent();
            _parameters = new Parameters();
        }

        /// <summary>
        /// Проверка на соответствие типа данных int
        /// </summary>
        /// <param name="textBox"></param>
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
            var value = CheckValueType(ref textBoxA);
            if (value == 0)
            {
                return;
            }
            
            try
            {
                _parameters.Thickness = value;
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
            var value = CheckValueType(ref textBoxB);
            if (value == 0)
            {
                return;
            }

            try
            {
                _parameters.Length = value;
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
            var value = CheckValueType(ref textBoxC);
            if (value == 0)
            {
                return;
            }

            try
            {
                _parameters.Width = value;
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
            var value = CheckValueType(ref textBoxD);
            if (value == 0)
            {
                return;
            }

            try
            {
                _parameters.LeftWallHeight = value;
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
            var value = CheckValueType(ref textBoxE);
            if (value == 0)
            {
                return;
            }

            try
            {
                _parameters.RightWallHeight = value;
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
            var thickness = Convert.ToInt32(textBoxA.Text);
            var length = Convert.ToInt32(textBoxB.Text);
            var width = Convert.ToInt32(textBoxC.Text);
            var leftWallHeight = Convert.ToInt32(textBoxD.Text);
            var rightWallHeight = Convert.ToInt32(textBoxE.Text);

            try
            {
                _parameters = new Parameters(thickness, length, width, leftWallHeight, rightWallHeight);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Проверьте правильность введенных значений на соответствие с допустимыми границами",
                    @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
