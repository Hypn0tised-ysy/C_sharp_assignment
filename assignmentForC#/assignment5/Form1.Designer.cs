﻿namespace calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(107, 90);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_Click;
            // 
            // button2
            // 
            button2.Location = new Point(247, 90);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_Click;
            // 
            // button3
            // 
            button3.Location = new Point(392, 90);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button_Click;
            // 
            // button4
            // 
            button4.Location = new Point(107, 155);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button_Click;
            // 
            // button5
            // 
            button5.Location = new Point(247, 155);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button_Click;
            // 
            // button6
            // 
            button6.Location = new Point(392, 155);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button_Click;
            // 
            // button7
            // 
            button7.Location = new Point(107, 226);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 6;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button_Click;
            // 
            // button8
            // 
            button8.Location = new Point(247, 226);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button_Click;
            // 
            // button9
            // 
            button9.Location = new Point(392, 226);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 8;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button_Click;
            // 
            // button10
            // 
            button10.Location = new Point(247, 297);
            button10.Name = "button10";
            button10.Size = new Size(94, 29);
            button10.TabIndex = 9;
            button10.Text = "+";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button_Click;
            // 
            // button11
            // 
            button11.Location = new Point(392, 297);
            button11.Name = "button11";
            button11.Size = new Size(94, 29);
            button11.TabIndex = 10;
            button11.Text = "-";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button_Click;
            // 
            // button12
            // 
            button12.Location = new Point(247, 366);
            button12.Name = "button12";
            button12.Size = new Size(94, 29);
            button12.TabIndex = 11;
            button12.Text = "*";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button_Click;
            // 
            // button13
            // 
            button13.Location = new Point(392, 366);
            button13.Name = "button13";
            button13.Size = new Size(94, 29);
            button13.TabIndex = 12;
            button13.Text = "/";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button_Click;
            // 
            // button14
            // 
            button14.Location = new Point(559, 297);
            button14.Name = "button14";
            button14.Size = new Size(94, 29);
            button14.TabIndex = 13;
            button14.Text = "=";
            button14.UseVisualStyleBackColor = true;
            button14.Click += equal_Click;
            // 
            // button15
            // 
            button15.Location = new Point(559, 366);
            button15.Name = "button15";
            button15.Size = new Size(94, 29);
            button15.TabIndex = 14;
            button15.Text = "clear";
            button15.UseVisualStyleBackColor = true;
            button15.Click += clear_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(559, 92);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "输入";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(559, 156);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "输出";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 18;
            // 
            // button16
            // 
            button16.Location = new Point(559, 226);
            button16.Name = "button16";
            button16.Size = new Size(94, 29);
            button16.TabIndex = 19;
            button16.Text = "backspace";
            button16.UseVisualStyleBackColor = true;
            button16.Click += backspace_Click;
            // 
            // button17
            // 
            button17.Location = new Point(107, 297);
            button17.Name = "button17";
            button17.Size = new Size(94, 29);
            button17.TabIndex = 20;
            button17.Text = "(";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button_Click;
            // 
            // button18
            // 
            button18.Location = new Point(107, 366);
            button18.Name = "button18";
            button18.Size = new Size(94, 29);
            button18.TabIndex = 21;
            button18.Text = ")";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button_Click;
            // 
            // button19
            // 
            button19.Location = new Point(482, 262);
            button19.Name = "button19";
            button19.Size = new Size(94, 29);
            button19.TabIndex = 22;
            button19.Text = ".";
            button19.UseVisualStyleBackColor = true;
            button19.Click += dot_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button19);
            Controls.Add(button18);
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
    }
}
