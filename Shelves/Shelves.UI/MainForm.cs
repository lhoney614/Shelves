using System;
using System.Collections.Generic;
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
        private Parameters _shelvesParameters = new Parameters();

        /// <summary>
        /// Переменная класса для подключения к Компас-3D
        /// </summary>
        private readonly KompasConnector _kompasConnector = 
            new KompasConnector();

        /// <summary>
        /// Словарь ключ-значение для привязки
        /// TextBox соответствующему параметру
        /// </summary>
        private readonly Dictionary<TextBox, 
            KeyValuePair<Parameter, bool>> _dictionaryTextBox;
        
        /// <summary>
        /// Цвет по умолчанию (белый)
        /// </summary>
        private readonly Color _defaultColor = Color.White;

        /// <summary>
        /// Цвет ошибки (темно-лососевый)
        /// </summary>
        private readonly Color _errorColor = Color.DarkSalmon;

        /// <summary>
        /// Загрузка главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            labelCorner.Visible = false;
            labelCornerParameters.Visible = false;
            buttonBuild.Enabled = false;

            _dictionaryTextBox = 
                new Dictionary<TextBox, KeyValuePair<Parameter, bool>>
            {
                {textBoxThickness, new KeyValuePair<Parameter, bool>
                        (Parameter.Thickness, false)},

                {textBoxLength, new KeyValuePair<Parameter, bool>
                        (Parameter.Length, false)},

                {textBoxWidth, new KeyValuePair<Parameter, bool>
                        (Parameter.Width, false)},

                {textBoxLeftWallHeight, new KeyValuePair<Parameter, bool>
                        (Parameter.LeftWallHeight, false)},

                {textBoxRightWallHeight, new KeyValuePair<Parameter, bool>
                        (Parameter.RightWallHeight, false)},

                {textBoxCorner, new KeyValuePair<Parameter, bool>
                        (Parameter.Radius, true)}
            };
        }


        /// <summary>
        /// Изменение формы, если НЕ отмечено скругление углов
        /// </summary>
        public void RoundingNotChecked()
        {
            textBoxCorner.ReadOnly = true;
            labelCorner.Visible = false;
            labelCornerParameters.Visible = false;

            labelTextCorner.Visible = true;
            labelTextCornerNotes.Visible = true;

            _dictionaryTextBox.Remove(textBoxCorner);
            _dictionaryTextBox.Add(textBoxCorner,
                new KeyValuePair<Parameter, bool>(Parameter.Radius, true));
            _shelvesParameters.Rounding = false;
        }

        /// <summary>
        /// Изменение формы, если отмечено скругление углов
        /// </summary>
        public void RoundingChecked()
        {
            textBoxCorner.ReadOnly = false;
            labelTextCorner.Visible = false;
            labelTextCornerNotes.Visible = false;

            labelCorner.Visible = true;
            labelCornerParameters.Visible = true;

            _dictionaryTextBox.Remove(textBoxCorner);
            _dictionaryTextBox.Add(textBoxCorner,
                new KeyValuePair<Parameter, bool>(Parameter.Radius, false));
            _shelvesParameters.Rounding = true;
        }

        /// <summary>
        /// Наличие скругленных внешних углов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxRounding_CheckedChanged(object sender,
            EventArgs e)
        {
            if (checkBoxRounding.Checked)
            {
                RoundingChecked();
            }
            else
            {
                RoundingNotChecked();
            }
            BuildButtonEnabled();
        }

        /// <summary>
        /// Проверка на соответствие вводимых данных типу int
        /// </summary>
        /// <param name="textBox">Соответствующий TextBox</param>
        /// <returns></returns>
        private int CheckValueType(TextBox textBox)
        {
            try
            {
                var value = Convert.ToInt32(textBox.Text);
                toolTip.SetToolTip(textBox, "");
                BuildButtonEnabled();
                return value;
            }
            catch (Exception)
            {
                toolTip.SetToolTip(textBox, "Недопустимые символы");
                textBox.BackColor = _errorColor;
                BuildButtonEnabled();
                return 0;
            }
        }
        
        /// <summary>
        /// Проверка корректного присвоения значения параметра
        /// </summary>
        /// <param name="textBox">Соотвествующий TextBox</param>
        private void SetParameterValue(TextBox textBox)
        {
            //Значение из TextBox
            var value = CheckValueType(textBox);

            if (value == 0)
            {
                return;
            }

            //Присвоение значения соответствующему параметру
            var parameter = _dictionaryTextBox[textBox].Key;

            try
            {
                _shelvesParameters.SetValue(parameter, value);
                textBox.BackColor = _defaultColor;
                toolTip.SetToolTip(textBox, "");
                _dictionaryTextBox.Remove(textBox);
                _dictionaryTextBox.Add(textBox, 
                    new KeyValuePair<Parameter, bool>(parameter, true));
            }
            catch (Exception exception)
            {
                textBox.BackColor = _errorColor;
                toolTip.SetToolTip(textBox, exception.Message);
                _dictionaryTextBox.Remove(textBox);
                _dictionaryTextBox.Add(textBox,
                    new KeyValuePair<Parameter, bool>(parameter, false));
            }
            BuildButtonEnabled();
        }

        /// <summary>
        /// Блокирование кнопки "Построить"
        /// </summary>
        public void BuildButtonEnabled()
        {
            foreach (var textbox in _dictionaryTextBox)
            {
                var value = textbox.Value.Value;
                if (value == false)
                {
                    buttonBuild.Enabled = false;
                    return;
                }
            }
            buttonBuild.Enabled = true;
        }
        
        /// <summary>
        /// Присвоение в поля ввода значений по умолчанию
        /// </summary>
        /// <param name="parameters"></param>
        private void ParameterSettings(Parameters parameters)
        {
            textBoxThickness.Text = parameters.Thickness.ToString();
            textBoxLength.Text = parameters.Length.ToString();
            textBoxWidth.Text = parameters.Width.ToString();
            textBoxLeftWallHeight.Text = 
                parameters.LeftWallHeight.ToString();
            textBoxRightWallHeight.Text = 
                parameters.RightWallHeight.ToString();
            checkBoxRounding.Checked = parameters.Rounding;
            textBoxCorner.Text = parameters.Radius.ToString();
        }

        /// <summary>
        /// Толщина досок, из которых будут сделаны полки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxThickness_TextChanged(object sender, EventArgs e)
        {
            SetParameterValue(textBoxThickness);
        }

        /// <summary>
        /// Длина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            SetParameterValue(textBoxLength);
        }

        /// <summary>
        /// Ширина полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            SetParameterValue(textBoxWidth);
        }

        /// <summary>
        /// Высота левой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLeftWall_TextChanged(object sender, EventArgs e)
        {
            SetParameterValue(textBoxLeftWallHeight);
        }

        /// <summary>
        /// Высота правой стенки полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRightWall_TextChanged(object sender, EventArgs e)
        {
            SetParameterValue(textBoxRightWallHeight);
        }

        /// <summary>
        /// Радиус скругленных углов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCorner_TextChanged(object sender, EventArgs e)
        {
            SetParameterValue(textBoxCorner);
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
        /// Построение 3D-модели подвесных полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            //автоматически вычисляемое поле
            _shelvesParameters.CommonWallHeight = 0;
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
