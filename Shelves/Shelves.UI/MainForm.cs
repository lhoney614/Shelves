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
            KeyValuePair<ParameterName, bool>> _dictionaryTextBox;
        
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
                new Dictionary<TextBox, KeyValuePair<ParameterName, bool>>
            {
                {textBoxThickness, new KeyValuePair<ParameterName, bool>
                        (ParameterName.Thickness, false)},

                {textBoxLength, new KeyValuePair<ParameterName, bool>
                        (ParameterName.Length, false)},

                {textBoxWidth, new KeyValuePair<ParameterName, bool>
                        (ParameterName.Width, false)},

                {textBoxLeftWallHeight, new KeyValuePair<ParameterName, bool>
                        (ParameterName.LeftWallHeight, false)},

                {textBoxRightWallHeight, new KeyValuePair<ParameterName, bool>
                        (ParameterName.RightWallHeight, false)},

                {textBoxCorner, new KeyValuePair<ParameterName, bool>
                        (ParameterName.Radius, true)}
            };
        }

        //TODO: объединить две функции с входным параметром от checkbox
        /// <summary>
        /// Изменение формы, если НЕ отмечено скругление углов
        /// </summary>
        private void RoundingChecked(bool check)
        {
            textBoxCorner.ReadOnly = !check;
            labelCorner.Visible = check;
            labelCornerParameters.Visible = check;

            labelTextCorner.Visible = !check;
            labelTextCornerNotes.Visible = !check;

            _dictionaryTextBox.Remove(textBoxCorner);
            _dictionaryTextBox.Add(textBoxCorner,
                new KeyValuePair<ParameterName, bool>(ParameterName.Radius, !check));
            _shelvesParameters.Rounding = check;
        }
        
        /// <summary>
        /// Наличие скругленных внешних углов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxRounding_CheckedChanged(object sender,
            EventArgs e)
        {
            RoundingChecked(checkBoxRounding.Checked);
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
                    new KeyValuePair<ParameterName, bool>(parameter, true));
            }
            catch (Exception exception)
            {
                textBox.BackColor = _errorColor;
                toolTip.SetToolTip(textBox, exception.Message);
                _dictionaryTextBox.Remove(textBox);
                _dictionaryTextBox.Add(textBox,
                    new KeyValuePair<ParameterName, bool>(parameter, false));
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

        //TODO: объединить событие для всех textbox
        /// <summary>
        /// Событие на изменение текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            SetParameterValue(textBox);
        }
        
        //TODO: RSDN
        /// <summary>
        /// Минимальные параметры полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinParamButton_Click(object sender, EventArgs e)
        {
            _shelvesParameters.MinParameters();
            ParameterSettings(_shelvesParameters);
        }

        /// <summary>
        /// Максимальные параметры полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxParamButton_Click(object sender, EventArgs e)
        {
            _shelvesParameters.MaxParameters();
            ParameterSettings(_shelvesParameters);
        }

        /// <summary>
        /// Параметры полок по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultParamButton_Click(object sender, EventArgs e)
        {
            _shelvesParameters = new Parameters();
            ParameterSettings(_shelvesParameters);
        }
        
        /// <summary>
        /// Построение 3D-модели подвесных полок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuild_Click(object sender, EventArgs e)
        {
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
