﻿namespace Shelves.UI
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
            this.checkBoxBackShelf = new System.Windows.Forms.CheckBox();
            this.checkBoxHoles = new System.Windows.Forms.CheckBox();
            this.checkBoxRounding = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные параметры полок";
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(196, 93);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(60, 22);
            this.textBoxC.TabIndex = 5;
            this.textBoxC.TextChanged += new System.EventHandler(this.textBoxC_TextChanged);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(196, 37);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(60, 22);
            this.textBoxA.TabIndex = 4;
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(196, 65);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(60, 22);
            this.textBoxB.TabIndex = 4;
            this.textBoxB.TextChanged += new System.EventHandler(this.textBoxB_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "от 200 до 300 мм";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "от 500 до 700 мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "от 15 до 20 мм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ширина полок (C):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Длина полок (B):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 154);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительные параметры полок";
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(196, 65);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(60, 22);
            this.textBoxE.TabIndex = 5;
            this.textBoxE.TextChanged += new System.EventHandler(this.textBoxE_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(81, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(311, 34);
            this.label12.TabIndex = 7;
            this.label12.Text = "Параметр E должен быть на 50 мм меньше D.\r\nУчитывайте это при подборе высоты стен" +
    "ок.";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(196, 37);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(60, 22);
            this.textBoxD.TabIndex = 4;
            this.textBoxD.TextChanged += new System.EventHandler(this.textBoxD_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "ВАЖНО!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "от 100 до 150 мм";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(262, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "от 150 до 200 мм";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Высота правой стенки (E):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Высота левой стенки (D):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(429, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(786, 579);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(168, 610);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(100, 30);
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
            this.groupBox3.Location = new System.Drawing.Point(13, 443);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 149);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Быстрые настройки";
            // 
            // defaultPramButton
            // 
            this.defaultPramButton.Location = new System.Drawing.Point(60, 103);
            this.defaultPramButton.Name = "defaultPramButton";
            this.defaultPramButton.Size = new System.Drawing.Size(284, 30);
            this.defaultPramButton.TabIndex = 2;
            this.defaultPramButton.Text = "Параметры по умолчанию";
            this.defaultPramButton.UseVisualStyleBackColor = true;
            this.defaultPramButton.Click += new System.EventHandler(this.defaultPramButton_Click);
            // 
            // maxParamButton
            // 
            this.maxParamButton.Location = new System.Drawing.Point(60, 67);
            this.maxParamButton.Name = "maxParamButton";
            this.maxParamButton.Size = new System.Drawing.Size(284, 30);
            this.maxParamButton.TabIndex = 1;
            this.maxParamButton.Text = "Максимальные параметры";
            this.maxParamButton.UseVisualStyleBackColor = true;
            this.maxParamButton.Click += new System.EventHandler(this.maxParamButton_Click);
            // 
            // minParamButton
            // 
            this.minParamButton.Location = new System.Drawing.Point(60, 31);
            this.minParamButton.Name = "minParamButton";
            this.minParamButton.Size = new System.Drawing.Size(284, 30);
            this.minParamButton.TabIndex = 0;
            this.minParamButton.Text = "Минимальные параметры";
            this.minParamButton.UseVisualStyleBackColor = true;
            this.minParamButton.Click += new System.EventHandler(this.minParamButton_Click);
            // 
            // checkBoxBackShelf
            // 
            this.checkBoxBackShelf.AutoSize = true;
            this.checkBoxBackShelf.Location = new System.Drawing.Point(9, 37);
            this.checkBoxBackShelf.Name = "checkBoxBackShelf";
            this.checkBoxBackShelf.Size = new System.Drawing.Size(188, 21);
            this.checkBoxBackShelf.TabIndex = 8;
            this.checkBoxBackShelf.Text = "Наличие задней стенки";
            this.checkBoxBackShelf.UseVisualStyleBackColor = true;
            this.checkBoxBackShelf.CheckedChanged += new System.EventHandler(this.checkBoxBackShelf_CheckedChanged);
            // 
            // checkBoxHoles
            // 
            this.checkBoxHoles.AutoSize = true;
            this.checkBoxHoles.Location = new System.Drawing.Point(9, 64);
            this.checkBoxHoles.Name = "checkBoxHoles";
            this.checkBoxHoles.Size = new System.Drawing.Size(187, 21);
            this.checkBoxHoles.TabIndex = 9;
            this.checkBoxHoles.Text = "Отверстия для подвеса";
            this.checkBoxHoles.UseVisualStyleBackColor = true;
            this.checkBoxHoles.CheckedChanged += new System.EventHandler(this.checkBoxHoles_CheckedChanged);
            // 
            // checkBoxRounding
            // 
            this.checkBoxRounding.AutoSize = true;
            this.checkBoxRounding.Location = new System.Drawing.Point(9, 91);
            this.checkBoxRounding.Name = "checkBoxRounding";
            this.checkBoxRounding.Size = new System.Drawing.Size(205, 21);
            this.checkBoxRounding.TabIndex = 10;
            this.checkBoxRounding.Text = "Скругление внешних углов";
            this.checkBoxRounding.UseVisualStyleBackColor = true;
            this.checkBoxRounding.CheckedChanged += new System.EventHandler(this.checkBoxRounding_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxRounding);
            this.groupBox4.Controls.Add(this.checkBoxBackShelf);
            this.groupBox4.Controls.Add(this.checkBoxHoles);
            this.groupBox4.Location = new System.Drawing.Point(12, 319);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(411, 118);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры на выбор";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 653);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
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
        private System.Windows.Forms.CheckBox checkBoxBackShelf;
        private System.Windows.Forms.CheckBox checkBoxHoles;
        private System.Windows.Forms.CheckBox checkBoxRounding;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

