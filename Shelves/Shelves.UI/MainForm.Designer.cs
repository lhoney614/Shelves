namespace Shelves.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.defaultPramButton = new System.Windows.Forms.Button();
            this.maxParamButton = new System.Windows.Forms.Button();
            this.minParamButton = new System.Windows.Forms.Button();
            this.checkBoxRounding = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelCornerParameters = new System.Windows.Forms.Label();
            this.labelCorner = new System.Windows.Forms.Label();
            this.textBoxCorner = new System.Windows.Forms.TextBox();
            this.labelTextCorner = new System.Windows.Forms.Label();
            this.labelTextCornerNotes = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxC);
            this.groupBox1.Controls.Add(this.textBoxA);
            this.groupBox1.Controls.Add(this.textBoxB);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(308, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные параметры полок";
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(147, 76);
            this.textBoxC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(46, 20);
            this.textBoxC.TabIndex = 5;
            this.textBoxC.TextChanged += new System.EventHandler(this.textBoxC_TextChanged);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(147, 30);
            this.textBoxA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(46, 20);
            this.textBoxA.TabIndex = 4;
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(147, 53);
            this.textBoxB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(46, 20);
            this.textBoxB.TabIndex = 4;
            this.textBoxB.TextChanged += new System.EventHandler(this.textBoxB_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "от 200 до 300 мм";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "от 500 до 700 мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "от 15 до 20 мм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ширина полок (C):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Длина полок (B):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Толщина досок (A):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxE);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxD);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(9, 129);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(308, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительные параметры полок";
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(147, 53);
            this.textBoxE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(46, 20);
            this.textBoxE.TabIndex = 5;
            this.textBoxE.TextChanged += new System.EventHandler(this.textBoxE_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 85);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(243, 26);
            this.label12.TabIndex = 7;
            this.label12.Text = "Параметр E должен быть на 50 мм меньше D.\r\nУчитывайте это при подборе высоты стен" +
    "ок.";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(147, 30);
            this.textBoxD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(46, 20);
            this.textBoxD.TabIndex = 4;
            this.textBoxD.TextChanged += new System.EventHandler(this.textBoxD_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(4, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "ВАЖНО!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "от 100 до 150 мм";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "от 150 до 200 мм";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Высота правой стенки (E):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Высота левой стенки (D):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(322, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 485);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(126, 471);
            this.buttonBuild.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(75, 24);
            this.buttonBuild.TabIndex = 3;
            this.buttonBuild.Text = "Построить";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.defaultPramButton);
            this.groupBox3.Controls.Add(this.maxParamButton);
            this.groupBox3.Controls.Add(this.minParamButton);
            this.groupBox3.Location = new System.Drawing.Point(9, 344);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(308, 122);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Быстрые настройки";
            // 
            // defaultPramButton
            // 
            this.defaultPramButton.Location = new System.Drawing.Point(45, 84);
            this.defaultPramButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.defaultPramButton.Name = "defaultPramButton";
            this.defaultPramButton.Size = new System.Drawing.Size(213, 24);
            this.defaultPramButton.TabIndex = 2;
            this.defaultPramButton.Text = "Параметры по умолчанию";
            this.defaultPramButton.UseVisualStyleBackColor = true;
            this.defaultPramButton.Click += new System.EventHandler(this.defaultPramButton_Click);
            // 
            // maxParamButton
            // 
            this.maxParamButton.Location = new System.Drawing.Point(45, 54);
            this.maxParamButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maxParamButton.Name = "maxParamButton";
            this.maxParamButton.Size = new System.Drawing.Size(213, 24);
            this.maxParamButton.TabIndex = 1;
            this.maxParamButton.Text = "Максимальные параметры";
            this.maxParamButton.UseVisualStyleBackColor = true;
            this.maxParamButton.Click += new System.EventHandler(this.maxParamButton_Click);
            // 
            // minParamButton
            // 
            this.minParamButton.Location = new System.Drawing.Point(45, 25);
            this.minParamButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minParamButton.Name = "minParamButton";
            this.minParamButton.Size = new System.Drawing.Size(213, 24);
            this.minParamButton.TabIndex = 0;
            this.minParamButton.Text = "Минимальные параметры";
            this.minParamButton.UseVisualStyleBackColor = true;
            this.minParamButton.Click += new System.EventHandler(this.minParamButton_Click);
            // 
            // checkBoxRounding
            // 
            this.checkBoxRounding.AutoSize = true;
            this.checkBoxRounding.Location = new System.Drawing.Point(7, 24);
            this.checkBoxRounding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxRounding.Name = "checkBoxRounding";
            this.checkBoxRounding.Size = new System.Drawing.Size(162, 17);
            this.checkBoxRounding.TabIndex = 10;
            this.checkBoxRounding.Text = "Скругление внешних углов";
            this.checkBoxRounding.UseVisualStyleBackColor = true;
            this.checkBoxRounding.CheckedChanged += new System.EventHandler(this.checkBoxRounding_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelTextCornerNotes);
            this.groupBox4.Controls.Add(this.labelTextCorner);
            this.groupBox4.Controls.Add(this.labelCornerParameters);
            this.groupBox4.Controls.Add(this.labelCorner);
            this.groupBox4.Controls.Add(this.textBoxCorner);
            this.groupBox4.Controls.Add(this.checkBoxRounding);
            this.groupBox4.Location = new System.Drawing.Point(9, 259);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(308, 80);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры на выбор";
            // 
            // labelCornerParameters
            // 
            this.labelCornerParameters.AutoSize = true;
            this.labelCornerParameters.Location = new System.Drawing.Point(196, 55);
            this.labelCornerParameters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCornerParameters.Name = "labelCornerParameters";
            this.labelCornerParameters.Size = new System.Drawing.Size(82, 13);
            this.labelCornerParameters.TabIndex = 13;
            this.labelCornerParameters.Text = "от 30 до 50 мм";
            // 
            // labelCorner
            // 
            this.labelCorner.AutoSize = true;
            this.labelCorner.Location = new System.Drawing.Point(4, 55);
            this.labelCorner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCorner.Name = "labelCorner";
            this.labelCorner.Size = new System.Drawing.Size(141, 13);
            this.labelCorner.TabIndex = 12;
            this.labelCorner.Text = "Радиус скругления углов: ";
            // 
            // textBoxCorner
            // 
            this.textBoxCorner.Location = new System.Drawing.Point(147, 53);
            this.textBoxCorner.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCorner.Name = "textBoxCorner";
            this.textBoxCorner.Size = new System.Drawing.Size(46, 20);
            this.textBoxCorner.TabIndex = 11;
            this.textBoxCorner.TextChanged += new System.EventHandler(this.textBoxCorner_TextChanged);
            // 
            // labelTextCorner
            // 
            this.labelTextCorner.AutoSize = true;
            this.labelTextCorner.Location = new System.Drawing.Point(61, 47);
            this.labelTextCorner.Name = "labelTextCorner";
            this.labelTextCorner.Size = new System.Drawing.Size(224, 26);
            this.labelTextCorner.TabIndex = 14;
            this.labelTextCorner.Text = "Скругление углов придаёт эстетичный вид\r\nи создает более безопасные условия";
            // 
            // labelTextCornerNotes
            // 
            this.labelTextCornerNotes.AutoSize = true;
            this.labelTextCornerNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTextCornerNotes.Location = new System.Drawing.Point(4, 47);
            this.labelTextCornerNotes.Name = "labelTextCornerNotes";
            this.labelTextCornerNotes.Size = new System.Drawing.Size(51, 13);
            this.labelTextCornerNotes.TabIndex = 15;
            this.labelTextCornerNotes.Text = "ПРИМ.:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 506);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shelves3DPlugin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button defaultPramButton;
        private System.Windows.Forms.Button maxParamButton;
        private System.Windows.Forms.Button minParamButton;
        private System.Windows.Forms.CheckBox checkBoxRounding;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelCornerParameters;
        private System.Windows.Forms.Label labelCorner;
        private System.Windows.Forms.TextBox textBoxCorner;
        private System.Windows.Forms.Label labelTextCornerNotes;
        private System.Windows.Forms.Label labelTextCorner;
    }
}

