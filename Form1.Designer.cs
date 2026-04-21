namespace GradeMate
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCurrentGrade = new System.Windows.Forms.TabPage();
            this.btnCalculateCurrentGrade = new System.Windows.Forms.Button();
            this.lblCurrentGrade = new System.Windows.Forms.Label();
            this.lblCurrentPercentage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxSochScore = new System.Windows.Forms.TextBox();
            this.txtSochScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxSorScore = new System.Windows.Forms.TextBox();
            this.txtSorScore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageDesiredSoch = new System.Windows.Forms.TabPage();
            this.btnCalculateDesiredSoch = new System.Windows.Forms.Button();
            this.lblMinSochNeeded = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDesiredGrade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaxSochScoreDesired = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaxSorScoreDesired = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSorScoreDesired = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageMesk = new System.Windows.Forms.TabPage();
            this.btnCalculateMeskGrade = new System.Windows.Forms.Button();
            this.lblMeskNeeded = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDesiredFinalGradeMesk = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQuarter4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtQuarter3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQuarter2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQuarter1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageCurrentGrade.SuspendLayout();
            this.tabPageDesiredSoch.SuspendLayout();
            this.tabPageMesk.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCurrentGrade);
            this.tabControl1.Controls.Add(this.tabPageDesiredSoch);
            this.tabControl1.Controls.Add(this.tabPageMesk);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCurrentGrade
            // 
            this.tabPageCurrentGrade.Controls.Add(this.btnCalculateCurrentGrade);
            this.tabPageCurrentGrade.Controls.Add(this.lblCurrentGrade);
            this.tabPageCurrentGrade.Controls.Add(this.lblCurrentPercentage);
            this.tabPageCurrentGrade.Controls.Add(this.label6);
            this.tabPageCurrentGrade.Controls.Add(this.label5);
            this.tabPageCurrentGrade.Controls.Add(this.txtMaxSochScore);
            this.tabPageCurrentGrade.Controls.Add(this.txtSochScore);
            this.tabPageCurrentGrade.Controls.Add(this.label4);
            this.tabPageCurrentGrade.Controls.Add(this.label3);
            this.tabPageCurrentGrade.Controls.Add(this.txtMaxSorScore);
            this.tabPageCurrentGrade.Controls.Add(this.txtSorScore);
            this.tabPageCurrentGrade.Controls.Add(this.label2);
            this.tabPageCurrentGrade.Controls.Add(this.label1);
            this.tabPageCurrentGrade.Location = new System.Drawing.Point(4, 24);
            this.tabPageCurrentGrade.Name = "tabPageCurrentGrade";
            this.tabPageCurrentGrade.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrentGrade.Size = new System.Drawing.Size(476, 333);
            this.tabPageCurrentGrade.TabIndex = 0;
            this.tabPageCurrentGrade.Text = "Текущая оценка";
            this.tabPageCurrentGrade.UseVisualStyleBackColor = true;
            // 
            // btnCalculateCurrentGrade
            // 
            this.btnCalculateCurrentGrade.Location = new System.Drawing.Point(20, 180);
            this.btnCalculateCurrentGrade.Name = "btnCalculateCurrentGrade";
            this.btnCalculateCurrentGrade.Size = new System.Drawing.Size(150, 30);
            this.btnCalculateCurrentGrade.TabIndex = 12;
            this.btnCalculateCurrentGrade.Text = "Рассчитать";
            this.btnCalculateCurrentGrade.UseVisualStyleBackColor = true;
            this.btnCalculateCurrentGrade.Click += new System.EventHandler(this.CalculateCurrentGrade_Click);
            // 
            // lblCurrentGrade
            // 
            this.lblCurrentGrade.AutoSize = true;
            this.lblCurrentGrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentGrade.Location = new System.Drawing.Point(150, 260);
            this.lblCurrentGrade.Name = "lblCurrentGrade";
            this.lblCurrentGrade.Size = new System.Drawing.Size(19, 21);
            this.lblCurrentGrade.TabIndex = 11;
            this.lblCurrentGrade.Text = "-";
            // 
            // lblCurrentPercentage
            // 
            this.lblCurrentPercentage.AutoSize = true;
            this.lblCurrentPercentage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentPercentage.Location = new System.Drawing.Point(150, 230);
            this.lblCurrentPercentage.Name = "lblCurrentPercentage";
            this.lblCurrentPercentage.Size = new System.Drawing.Size(19, 21);
            this.lblCurrentPercentage.TabIndex = 10;
            this.lblCurrentPercentage.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Итоговая оценка:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Процентное содерж.:";
            // 
            // txtMaxSochScore
            // 
            this.txtMaxSochScore.Location = new System.Drawing.Point(150, 137);
            this.txtMaxSochScore.Name = "txtMaxSochScore";
            this.txtMaxSochScore.Size = new System.Drawing.Size(100, 23);
            this.txtMaxSochScore.TabIndex = 7;
            // 
            // txtSochScore
            // 
            this.txtSochScore.Location = new System.Drawing.Point(150, 107);
            this.txtSochScore.Name = "txtSochScore";
            this.txtSochScore.Size = new System.Drawing.Size(100, 23);
            this.txtSochScore.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Макс. балл СОЧ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Балл СОЧ:";
            // 
            // txtMaxSorScore
            // 
            this.txtMaxSorScore.Location = new System.Drawing.Point(150, 47);
            this.txtMaxSorScore.Name = "txtMaxSorScore";
            this.txtMaxSorScore.Size = new System.Drawing.Size(100, 23);
            this.txtMaxSorScore.TabIndex = 3;
            // 
            // txtSorScore
            // 
            this.txtSorScore.Location = new System.Drawing.Point(150, 17);
            this.txtSorScore.Name = "txtSorScore";
            this.txtSorScore.Size = new System.Drawing.Size(100, 23);
            this.txtSorScore.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Макс. балл СОР:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Балл СОР:";
            // 
            // tabPageDesiredSoch
            // 
            this.tabPageDesiredSoch.Controls.Add(this.btnCalculateDesiredSoch);
            this.tabPageDesiredSoch.Controls.Add(this.lblMinSochNeeded);
            this.tabPageDesiredSoch.Controls.Add(this.label12);
            this.tabPageDesiredSoch.Controls.Add(this.txtDesiredGrade);
            this.tabPageDesiredSoch.Controls.Add(this.label11);
            this.tabPageDesiredSoch.Controls.Add(this.txtMaxSochScoreDesired);
            this.tabPageDesiredSoch.Controls.Add(this.label10);
            this.tabPageDesiredSoch.Controls.Add(this.txtMaxSorScoreDesired);
            this.tabPageDesiredSoch.Controls.Add(this.label9);
            this.tabPageDesiredSoch.Controls.Add(this.txtSorScoreDesired);
            this.tabPageDesiredSoch.Controls.Add(this.label8);
            this.tabPageDesiredSoch.Location = new System.Drawing.Point(4, 24);
            this.tabPageDesiredSoch.Name = "tabPageDesiredSoch";
            this.tabPageDesiredSoch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDesiredSoch.Size = new System.Drawing.Size(476, 333);
            this.tabPageDesiredSoch.TabIndex = 1;
            this.tabPageDesiredSoch.Text = "Прогноз СОЧ";
            this.tabPageDesiredSoch.UseVisualStyleBackColor = true;
            // 
            // btnCalculateDesiredSoch
            // 
            this.btnCalculateDesiredSoch.Location = new System.Drawing.Point(20, 180);
            this.btnCalculateDesiredSoch.Name = "btnCalculateDesiredSoch";
            this.btnCalculateDesiredSoch.Size = new System.Drawing.Size(150, 30);
            this.btnCalculateDesiredSoch.TabIndex = 10;
            this.btnCalculateDesiredSoch.Text = "Рассчитать";
            this.btnCalculateDesiredSoch.UseVisualStyleBackColor = true;
            this.btnCalculateDesiredSoch.Click += new System.EventHandler(this.CalculateDesiredSoch_Click);
            // 
            // lblMinSochNeeded
            // 
            this.lblMinSochNeeded.AutoSize = true;
            this.lblMinSochNeeded.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMinSochNeeded.Location = new System.Drawing.Point(180, 230);
            this.lblMinSochNeeded.Name = "lblMinSochNeeded";
            this.lblMinSochNeeded.Size = new System.Drawing.Size(19, 21);
            this.lblMinSochNeeded.TabIndex = 9;
            this.lblMinSochNeeded.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Мин. балл СОЧ для цели:";
            // 
            // txtDesiredGrade
            // 
            this.txtDesiredGrade.Location = new System.Drawing.Point(180, 137);
            this.txtDesiredGrade.Name = "txtDesiredGrade";
            this.txtDesiredGrade.Size = new System.Drawing.Size(100, 23);
            this.txtDesiredGrade.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Желаемая оценка:";
            // 
            // txtMaxSochScoreDesired
            // 
            this.txtMaxSochScoreDesired.Location = new System.Drawing.Point(180, 107);
            this.txtMaxSochScoreDesired.Name = "txtMaxSochScoreDesired";
            this.txtMaxSochScoreDesired.Size = new System.Drawing.Size(100, 23);
            this.txtMaxSochScoreDesired.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Макс. балл СОЧ:";
            // 
            // txtMaxSorScoreDesired
            // 
            this.txtMaxSorScoreDesired.Location = new System.Drawing.Point(180, 47);
            this.txtMaxSorScoreDesired.Name = "txtMaxSorScoreDesired";
            this.txtMaxSorScoreDesired.Size = new System.Drawing.Size(100, 23);
            this.txtMaxSorScoreDesired.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Макс. балл СОР:";
            // 
            // txtSorScoreDesired
            // 
            this.txtSorScoreDesired.Location = new System.Drawing.Point(180, 17);
            this.txtSorScoreDesired.Name = "txtSorScoreDesired";
            this.txtSorScoreDesired.Size = new System.Drawing.Size(100, 23);
            this.txtSorScoreDesired.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Текущий балл СОР:";
            // 
            // tabPageMesk
            // 
            this.tabPageMesk.Controls.Add(this.btnCalculateMeskGrade);
            this.tabPageMesk.Controls.Add(this.lblMeskNeeded);
            this.tabPageMesk.Controls.Add(this.label18);
            this.tabPageMesk.Controls.Add(this.txtDesiredFinalGradeMesk);
            this.tabPageMesk.Controls.Add(this.label17);
            this.tabPageMesk.Controls.Add(this.txtQuarter4);
            this.tabPageMesk.Controls.Add(this.label16);
            this.tabPageMesk.Controls.Add(this.txtQuarter3);
            this.tabPageMesk.Controls.Add(this.label15);
            this.tabPageMesk.Controls.Add(this.txtQuarter2);
            this.tabPageMesk.Controls.Add(this.label14);
            this.tabPageMesk.Controls.Add(this.txtQuarter1);
            this.tabPageMesk.Controls.Add(this.label13);
            this.tabPageMesk.Location = new System.Drawing.Point(4, 24);
            this.tabPageMesk.Name = "tabPageMesk";
            this.tabPageMesk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMesk.Size = new System.Drawing.Size(476, 333);
            this.tabPageMesk.TabIndex = 2;
            this.tabPageMesk.Text = "МЭСК (ВСО)";
            this.tabPageMesk.UseVisualStyleBackColor = true;
            // 
            // btnCalculateMeskGrade
            // 
            this.btnCalculateMeskGrade.Location = new System.Drawing.Point(20, 200);
            this.btnCalculateMeskGrade.Name = "btnCalculateMeskGrade";
            this.btnCalculateMeskGrade.Size = new System.Drawing.Size(150, 30);
            this.btnCalculateMeskGrade.TabIndex = 12;
            this.btnCalculateMeskGrade.Text = "Рассчитать";
            this.btnCalculateMeskGrade.UseVisualStyleBackColor = true;
            this.btnCalculateMeskGrade.Click += new System.EventHandler(this.CalculateMeskGrade_Click);
            // 
            // lblMeskNeeded
            // 
            this.lblMeskNeeded.AutoSize = true;
            this.lblMeskNeeded.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMeskNeeded.Location = new System.Drawing.Point(180, 250);
            this.lblMeskNeeded.Name = "lblMeskNeeded";
            this.lblMeskNeeded.Size = new System.Drawing.Size(19, 21);
            this.lblMeskNeeded.TabIndex = 11;
            this.lblMeskNeeded.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 255);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 15);
            this.label18.TabIndex = 10;
            this.label18.Text = "Нужная оценка на МЭСК:";
            // 
            // txtDesiredFinalGradeMesk
            // 
            this.txtDesiredFinalGradeMesk.Location = new System.Drawing.Point(180, 157);
            this.txtDesiredFinalGradeMesk.Name = "txtDesiredFinalGradeMesk";
            this.txtDesiredFinalGradeMesk.Size = new System.Drawing.Size(100, 23);
            this.txtDesiredFinalGradeMesk.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(155, 15);
            this.label17.TabIndex = 8;
            this.label17.Text = "Желаемая итоговая (год):";
            // 
            // txtQuarter4
            // 
            this.txtQuarter4.Location = new System.Drawing.Point(180, 107);
            this.txtQuarter4.Name = "txtQuarter4";
            this.txtQuarter4.Size = new System.Drawing.Size(100, 23);
            this.txtQuarter4.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 15);
            this.label16.TabIndex = 6;
            this.label16.Text = "Оценка за 4 четв.:";
            // 
            // txtQuarter3
            // 
            this.txtQuarter3.Location = new System.Drawing.Point(180, 77);
            this.txtQuarter3.Name = "txtQuarter3";
            this.txtQuarter3.Size = new System.Drawing.Size(100, 23);
            this.txtQuarter3.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "Оценка за 3 четв.:";
            // 
            // txtQuarter2
            // 
            this.txtQuarter2.Location = new System.Drawing.Point(180, 47);
            this.txtQuarter2.Name = "txtQuarter2";
            this.txtQuarter2.Size = new System.Drawing.Size(100, 23);
            this.txtQuarter2.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Оценка за 2 четв.:";
            // 
            // txtQuarter1
            // 
            this.txtQuarter1.Location = new System.Drawing.Point(180, 17);
            this.txtQuarter1.Name = "txtQuarter1";
            this.txtQuarter1.Size = new System.Drawing.Size(100, 23);
            this.txtQuarter1.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Оценка за 1 четв.:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "GradeMate";
            this.tabControl1.ResumeLayout(false);
            this.tabPageCurrentGrade.ResumeLayout(false);
            this.tabPageCurrentGrade.PerformLayout();
            this.tabPageDesiredSoch.ResumeLayout(false);
            this.tabPageDesiredSoch.PerformLayout();
            this.tabPageMesk.ResumeLayout(false);
            this.tabPageMesk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCurrentGrade;
        private System.Windows.Forms.TabPage tabPageDesiredSoch;
        private System.Windows.Forms.TabPage tabPageMesk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxSorScore;
        private System.Windows.Forms.TextBox txtSorScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxSochScore;
        private System.Windows.Forms.TextBox txtSochScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentGrade;
        private System.Windows.Forms.Label lblCurrentPercentage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCalculateCurrentGrade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSorScoreDesired;
        private System.Windows.Forms.TextBox txtMaxSorScoreDesired;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxSochScoreDesired;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDesiredGrade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMinSochNeeded;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCalculateDesiredSoch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQuarter1;
        private System.Windows.Forms.TextBox txtQuarter4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtQuarter3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtQuarter2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDesiredFinalGradeMesk;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblMeskNeeded;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCalculateMeskGrade;
    }
}
