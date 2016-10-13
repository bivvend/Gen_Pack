﻿namespace Gen_Pack
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonPack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSheetX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSheetY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMaxX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMaxY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMinX = new System.Windows.Forms.TextBox();
            this.textBoxMinY = new System.Windows.Forms.TextBox();
            this.buttonShowN = new System.Windows.Forms.Button();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelHighestScore = new System.Windows.Forms.Label();
            this.labelAverageScore = new System.Windows.Forms.Label();
            this.labelBestEverScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(525, 22);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(105, 39);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonPack
            // 
            this.buttonPack.Location = new System.Drawing.Point(525, 67);
            this.buttonPack.Name = "buttonPack";
            this.buttonPack.Size = new System.Drawing.Size(105, 39);
            this.buttonPack.TabIndex = 2;
            this.buttonPack.Text = "Pack";
            this.buttonPack.UseVisualStyleBackColor = true;
            this.buttonPack.Click += new System.EventHandler(this.buttonPack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "No Boxes";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(525, 140);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sheet x (mm)";
            // 
            // textBoxSheetX
            // 
            this.textBoxSheetX.Location = new System.Drawing.Point(525, 384);
            this.textBoxSheetX.Name = "textBoxSheetX";
            this.textBoxSheetX.Size = new System.Drawing.Size(100, 20);
            this.textBoxSheetX.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sheet y (mm)";
            // 
            // textBoxSheetY
            // 
            this.textBoxSheetY.Location = new System.Drawing.Point(524, 434);
            this.textBoxSheetY.Name = "textBoxSheetY";
            this.textBoxSheetY.Size = new System.Drawing.Size(100, 20);
            this.textBoxSheetY.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max X (mm)";
            // 
            // textBoxMaxX
            // 
            this.textBoxMaxX.Location = new System.Drawing.Point(524, 191);
            this.textBoxMaxX.Name = "textBoxMaxX";
            this.textBoxMaxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxX.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max Y (mm)";
            // 
            // textBoxMaxY
            // 
            this.textBoxMaxY.Location = new System.Drawing.Point(525, 237);
            this.textBoxMaxY.Name = "textBoxMaxY";
            this.textBoxMaxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxY.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Min X (mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Min Y (mm)";
            // 
            // textBoxMinX
            // 
            this.textBoxMinX.Location = new System.Drawing.Point(524, 287);
            this.textBoxMinX.Name = "textBoxMinX";
            this.textBoxMinX.Size = new System.Drawing.Size(100, 20);
            this.textBoxMinX.TabIndex = 4;
            // 
            // textBoxMinY
            // 
            this.textBoxMinY.Location = new System.Drawing.Point(524, 335);
            this.textBoxMinY.Name = "textBoxMinY";
            this.textBoxMinY.Size = new System.Drawing.Size(100, 20);
            this.textBoxMinY.TabIndex = 4;
            // 
            // buttonShowN
            // 
            this.buttonShowN.Location = new System.Drawing.Point(525, 499);
            this.buttonShowN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonShowN.Name = "buttonShowN";
            this.buttonShowN.Size = new System.Drawing.Size(97, 27);
            this.buttonShowN.TabIndex = 5;
            this.buttonShowN.Text = "Show N";
            this.buttonShowN.UseVisualStyleBackColor = true;
            this.buttonShowN.Click += new System.EventHandler(this.buttonShowN_Click);
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(556, 473);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(68, 20);
            this.textBoxN.TabIndex = 6;
            this.textBoxN.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(529, 474);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "N";
            // 
            // labelHighestScore
            // 
            this.labelHighestScore.AutoSize = true;
            this.labelHighestScore.Location = new System.Drawing.Point(18, 545);
            this.labelHighestScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHighestScore.Name = "labelHighestScore";
            this.labelHighestScore.Size = new System.Drawing.Size(78, 13);
            this.labelHighestScore.TabIndex = 8;
            this.labelHighestScore.Text = "Highest score: ";
            // 
            // labelAverageScore
            // 
            this.labelAverageScore.AutoSize = true;
            this.labelAverageScore.Location = new System.Drawing.Point(205, 545);
            this.labelAverageScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAverageScore.Name = "labelAverageScore";
            this.labelAverageScore.Size = new System.Drawing.Size(82, 13);
            this.labelAverageScore.TabIndex = 8;
            this.labelAverageScore.Text = "Average score: ";
            // 
            // labelBestEverScore
            // 
            this.labelBestEverScore.AutoSize = true;
            this.labelBestEverScore.Location = new System.Drawing.Point(384, 545);
            this.labelBestEverScore.Name = "labelBestEverScore";
            this.labelBestEverScore.Size = new System.Drawing.Size(84, 13);
            this.labelBestEverScore.TabIndex = 9;
            this.labelBestEverScore.Text = "Best ever score:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 614);
            this.Controls.Add(this.labelBestEverScore);
            this.Controls.Add(this.labelAverageScore);
            this.Controls.Add(this.labelHighestScore);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.buttonShowN);
            this.Controls.Add(this.textBoxSheetY);
            this.Controls.Add(this.textBoxSheetX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMinY);
            this.Controls.Add(this.textBoxMaxY);
            this.Controls.Add(this.textBoxMinX);
            this.Controls.Add(this.textBoxMaxX);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPack);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonPack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSheetX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSheetY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaxX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMaxY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMinX;
        private System.Windows.Forms.TextBox textBoxMinY;
        private System.Windows.Forms.Button buttonShowN;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelHighestScore;
        private System.Windows.Forms.Label labelAverageScore;
        private System.Windows.Forms.Label labelBestEverScore;
    }
}

