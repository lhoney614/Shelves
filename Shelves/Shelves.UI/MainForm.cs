using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shelves.UI
{
    public partial class MainForm : Form
    {
        //переменная, хранящая информацию о наличии ошибок
        private bool _checkParameters;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Толщина досок, из которых будут сделаны полки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            if (textBoxA.Text == @"")
            {
                textBoxA.BackColor = Color.White;
                return;
            }

            var value = Convert.ToInt32(textBoxA.Text);
            if (value < 15 || value > 20)
            {
                textBoxA.BackColor = Color.DarkSalmon;
            }
            else
            {
                textBoxA.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Длина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            if (textBoxB.Text == @"")
            {
                textBoxB.BackColor = Color.White;
                return;
            }

            var value = Convert.ToInt32(textBoxB.Text);
            if (value < 500 || value > 700)
            {
                textBoxB.BackColor = Color.DarkSalmon;
            }
            else
            {
                textBoxB.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Ширина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxC_TextChanged(object sender, EventArgs e)
        {
            if (textBoxC.Text == @"")
            {
                textBoxC.BackColor = Color.White;
                return;
            }

            var value = Convert.ToInt32(textBoxC.Text);
            if (value < 200 || value > 300)
            {
                textBoxC.BackColor = Color.DarkSalmon;
            }
            else
            {
                textBoxC.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Высота левой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxD_TextChanged(object sender, EventArgs e)
        {
            if (textBoxD.Text == @"")
            {
                textBoxD.BackColor = Color.White;
                return;
            }

            var value = Convert.ToInt32(textBoxD.Text);
            if (value < 150 || value > 200)
            {
                textBoxD.BackColor = Color.DarkSalmon;
            }
            else
            {
                textBoxD.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Высота правой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxE_TextChanged(object sender, EventArgs e)
        {
            if (textBoxE.Text == @"")
            {
                textBoxE.BackColor = Color.White;
                return;
            }

            var value = Convert.ToInt32(textBoxE.Text);
            if (value < 100 || value > 150 || (Convert.ToInt32(textBoxD.Text) - value) != 50)
            {
                textBoxE.BackColor = Color.DarkSalmon;
            }
            else
            {
                textBoxE.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Построение 3D-модели подвесных полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            _checkParameters = false;

            if (textBoxA.Text == @""
                || Convert.ToInt32(textBoxA.Text) < 15 
                || Convert.ToInt32(textBoxA.Text) > 20)
            {
                textBoxA.BackColor = Color.DarkSalmon;
                _checkParameters = true;
            }
            else
            {
                textBoxA.BackColor = Color.White;
            }

            if (textBoxB.Text == @""
                || Convert.ToInt32(textBoxB.Text) < 500 
                || Convert.ToInt32(textBoxB.Text) > 700)
            {
                textBoxB.BackColor = Color.DarkSalmon;
                _checkParameters = true;
            }
            else
            {
                textBoxB.BackColor = Color.White;
            }

            if (textBoxC.Text == @""
                || Convert.ToInt32(textBoxC.Text) < 200 
                || Convert.ToInt32(textBoxC.Text) > 300)
            {
                textBoxC.BackColor = Color.DarkSalmon;
                _checkParameters = true;
            }
            else
            {
                textBoxC.BackColor = Color.White;
            }

            if (textBoxD.Text == @""
                || Convert.ToInt32(textBoxD.Text) < 150 
                || Convert.ToInt32(textBoxD.Text) > 200)
            {
                textBoxD.BackColor = Color.DarkSalmon;
                _checkParameters = true;
            }
            else
            {
                textBoxD.BackColor = Color.White;
            }

            if (textBoxE.Text == @""
                || Convert.ToInt32(textBoxE.Text) < 100 
                || Convert.ToInt32(textBoxE.Text) > 150 
                || (Convert.ToInt32(textBoxD.Text) - Convert.ToInt32(textBoxE.Text)) != 50)
            {
                textBoxE.BackColor = Color.DarkSalmon;
                _checkParameters = true;
            }
            else
            {
                textBoxE.BackColor = Color.White;
            }

            //если ошибки найдены хотя бы в одном параметре, то
            //показывается окно с соответствующим сообщением
            if (_checkParameters)
            {
                MessageBox.Show(@"Проверьте правильность введенных значений на соответствие с допустимыми границами", 
                    @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
