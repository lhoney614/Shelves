using System;
using System.Drawing;
using System.Windows.Forms;
using ShelvesParameters;
using ShelvesBuilder;
using APIConnector;

namespace Shelves.UI
{
    /// <summary>
    /// Главная форма для ввода параметров
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Хранит вводимые в форме параметры
        /// </summary>
        private Parameters _shelvesParameters;

        /// <summary>
        /// Переменная класса для подключения к Компас-3D
        /// </summary>
        private KompasConnector _kompasConnector;

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
        /// Налиличе скругленных внешних углов
        /// </summary>
        private bool _rounding;

        /// <summary>
        /// Радиус скругления внешних углов
        /// </summary>
        private int _radius;

        /// <summary>
        /// Загрузка главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _shelvesParameters = new Parameters();
            _kompasConnector = new KompasConnector();
        }


        /// <summary>
        /// Проверка на соответствие вводимых данных типу int
        /// </summary>
        /// <param name="textBox">Соответствующий TextBox</param>
        /// <returns></returns>
        private int CheckValueType(Control textBox)
        {
            try
            {
                var value = Convert.ToInt32(textBox.Text);
                toolTip.SetToolTip(textBox, "");
                buttonBuild.Enabled = true;
                return value;
            }
            catch (Exception)
            {
                toolTip.SetToolTip(textBox, "Недопустимые символы");
                textBox.BackColor = Color.DarkSalmon;
                buttonBuild.Enabled = false;
                return 0;
            }
        }

        /*
        /// <summary>
        /// Проверка корректного присвоения значения параметра
        /// </summary>
        /// <param name="textBox">Соотвествующий TextBox</param>
        /// <param name="param">Парамет</param>
        /// <param name="value"></param>
        private void TryToSetParameterValue(Control textBox, int param, int value)
        {
            //TODO: ну короче разобраться с передачей свойства
            try
            {
                param = value;
                textBox.BackColor = Color.White;
                toolTip.SetToolTip(textBox, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBox.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBox, exception.Message);
                buttonBuild.Enabled = false;
            }
        }
        */

        /// <summary>
        /// Присвоение в поля ввода значений по умолчанию
        /// </summary>
        /// <param name="parameters"></param>
        private void ParameterSettings(Parameters parameters)
        {
            textBoxA.Text = parameters.Thickness.ToString();
            textBoxB.Text = parameters.Length.ToString();
            textBoxC.Text = parameters.Width.ToString();
            textBoxD.Text = parameters.LeftWallHeight.ToString();
            textBoxE.Text = parameters.RightWallHeight.ToString();
            checkBoxRounding.Checked = parameters.Rounding;
            textBoxCorner.Text = parameters.Radius.ToString();
        }

        /// <summary>
        /// Толщина досок, из которых будут сделаны полки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            _thickness = CheckValueType(textBoxA);
            if (_thickness == 0) return;

            try
            {
                _shelvesParameters.Thickness = _thickness;
                textBoxA.BackColor = Color.White;
                toolTip.SetToolTip(textBoxA, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBoxA.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBoxA, exception.Message);
                buttonBuild.Enabled = false;
            }
        }

        /// <summary>
        /// Длина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            _length = CheckValueType(textBoxB);
            if (_length == 0) return;

            try
            {
                _shelvesParameters.Length = _length;
                textBoxB.BackColor = Color.White;
                toolTip.SetToolTip(textBoxB, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBoxB.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBoxB, exception.Message);
                buttonBuild.Enabled = false;
            }
        }

        /// <summary>
        /// Ширина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxC_TextChanged(object sender, EventArgs e)
        {
            _width = CheckValueType(textBoxC);
            if (_width == 0) return;

            try
            {
                _shelvesParameters.Width = _width;
                textBoxC.BackColor = Color.White;
                toolTip.SetToolTip(textBoxC, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBoxC.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBoxC, exception.Message);
                buttonBuild.Enabled = false;
            }
        }

        /// <summary>
        /// Высота левой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxD_TextChanged(object sender, EventArgs e)
        {
            _leftWallHeight = CheckValueType(textBoxD);
            if (_leftWallHeight == 0) return;

            try
            {
                _shelvesParameters.LeftWallHeight = _leftWallHeight;
                textBoxD.BackColor = Color.White;
                toolTip.SetToolTip(textBoxD, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBoxD.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBoxD, exception.Message);
                buttonBuild.Enabled = false;
            }
        }

        /// <summary>
        /// Высота правой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxE_TextChanged(object sender, EventArgs e)
        {
            _rightWallHeight = CheckValueType(textBoxE);
            if (_rightWallHeight == 0) return;

            try
            {
                _shelvesParameters.RightWallHeight = _rightWallHeight;
                textBoxE.BackColor = Color.White;
                toolTip.SetToolTip(textBoxE, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBoxE.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBoxE, exception.Message);
                buttonBuild.Enabled = false;
            }
        }

        /// <summary>
        /// Минимальные параметры полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minParamButton_Click(object sender, EventArgs e)
        {
            _shelvesParameters = new Parameters(1);
            ParameterSettings(_shelvesParameters);
        }

        /// <summary>
        /// Максимальные параметры полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxParamButton_Click(object sender, EventArgs e)
        {
            _shelvesParameters = new Parameters(2);
            ParameterSettings(_shelvesParameters);
        }

        /// <summary>
        /// Параметры полок по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultPramButton_Click(object sender, EventArgs e)
        {
            _shelvesParameters = new Parameters(0);
            ParameterSettings(_shelvesParameters);
        }

        /// <summary>
        /// Наличие скругленных внешних углов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxRounding_CheckedChanged(object sender, EventArgs e)
        {
            _rounding = checkBoxRounding.Checked;
        }

        /// <summary>
        /// Радиус скругленных углов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCorner_TextChanged(object sender, EventArgs e)
        {
            _radius = CheckValueType(textBoxCorner);
            if (_radius == 0) return;

            try
            {
                _shelvesParameters.Radius = _radius;
                textBoxCorner.BackColor = Color.White;
                toolTip.SetToolTip(textBoxCorner, "");
                buttonBuild.Enabled = true;
            }
            catch (Exception exception)
            {
                textBoxCorner.BackColor = Color.DarkSalmon;
                toolTip.SetToolTip(textBoxCorner, exception.Message);
                buttonBuild.Enabled = false;
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
                _shelvesParameters = new Parameters(_thickness, _length, 
                    _width, _leftWallHeight, _rightWallHeight, _rounding,
                    _radius);
                buttonBuild.Enabled = true;
            }
            catch
            {
                buttonBuild.Enabled = false;
            }

            try
            {
                _kompasConnector.OpenKompas();
                var builder = new Builder();
                builder.BuildShelves(_kompasConnector, _shelvesParameters);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

    }
}
