using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeMate
{
    public partial class Form1 : Form
    {
        private readonly Color _backgroundColor = Color.FromArgb(235, 244, 255);
        private readonly Color _panelColor = Color.FromArgb(223, 236, 252);
        private readonly Color _primaryColor = Color.FromArgb(33, 110, 196);
        private readonly Color _primaryTextColor = Color.FromArgb(25, 63, 110);

        public Form1()
        {
            InitializeComponent();
            this.Text = "GradeMate - Калькулятор оценок";
            ApplyBlueTheme();
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            UpdateAcceptButton();
        }

        private void ApplyBlueTheme()
        {
            BackColor = _backgroundColor;
            ForeColor = _primaryTextColor;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(560, 440);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            tabControl1.Padding = new Point(16, 8);
            tabControl1.Appearance = TabAppearance.Normal;
            tabControl1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabPage.BackColor = _panelColor;
                tabPage.ForeColor = _primaryTextColor;
                tabPage.Padding = new Padding(16);
                StyleControls(tabPage.Controls);
            }

            tabPageCurrentGrade.Text = "Текущая оценка";
            tabPageDesiredSoch.Text = "Прогноз СОЧ";
            tabPageMesk.Text = "МЭСК (ВСО)";

            lblCurrentPercentage.ForeColor = _primaryColor;
            lblCurrentGrade.ForeColor = _primaryColor;
            lblMinSochNeeded.ForeColor = _primaryColor;
            lblMeskNeeded.ForeColor = _primaryColor;
        }

        private void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    button.BackColor = _primaryColor;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
                    button.Cursor = Cursors.Hand;
                    button.Height = 36;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = _primaryTextColor;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                }
                else if (control is Label label)
                {
                    label.ForeColor = _primaryTextColor;
                }

                if (control.HasChildren)
                {
                    StyleControls(control.Controls);
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAcceptButton();
        }

        private void UpdateAcceptButton()
        {
            if (tabControl1.SelectedTab == tabPageCurrentGrade)
            {
                AcceptButton = btnCalculateCurrentGrade;
            }
            else if (tabControl1.SelectedTab == tabPageDesiredSoch)
            {
                AcceptButton = btnCalculateDesiredSoch;
            }
            else
            {
                AcceptButton = btnCalculateMeskGrade;
            }
        }

        private void CalculateCurrentGrade_Click(object sender, EventArgs e)
        {
            try
            {
                double sorScore = double.Parse(txtSorScore.Text);
                double maxSorScore = double.Parse(txtMaxSorScore.Text);
                double sochScore = double.Parse(txtSochScore.Text);
                double maxSochScore = double.Parse(txtMaxSochScore.Text);

                var result = GradeCalculator.CalculateCurrentGrade(sorScore, sochScore, maxSorScore, maxSochScore);
                lblCurrentPercentage.Text = $"{result.Item1:F2}%";
                lblCurrentGrade.Text = result.Item2.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для баллов.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDesiredSoch_Click(object sender, EventArgs e)
        {
            try
            {
                double sorScore = double.Parse(txtSorScoreDesired.Text);
                double maxSorScore = double.Parse(txtMaxSorScoreDesired.Text);
                double maxSochScore = double.Parse(txtMaxSochScoreDesired.Text);
                int desiredGrade = int.Parse(txtDesiredGrade.Text);

                double minSoch = GradeCalculator.CalculateMinSochForDesiredGrade(sorScore, maxSorScore, maxSochScore, desiredGrade);
                lblMinSochNeeded.Text = $"{minSoch:F2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateMeskGrade_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> quarterGrades = new List<int>();
                if (!string.IsNullOrWhiteSpace(txtQuarter1.Text)) quarterGrades.Add(int.Parse(txtQuarter1.Text));
                if (!string.IsNullOrWhiteSpace(txtQuarter2.Text)) quarterGrades.Add(int.Parse(txtQuarter2.Text));
                if (!string.IsNullOrWhiteSpace(txtQuarter3.Text)) quarterGrades.Add(int.Parse(txtQuarter3.Text));
                if (!string.IsNullOrWhiteSpace(txtQuarter4.Text)) quarterGrades.Add(int.Parse(txtQuarter4.Text));

                int desiredFinalGrade = int.Parse(txtDesiredFinalGradeMesk.Text);

                // Assuming fixed weights for now as per prompt: 60% for quarter, 40% for exam
                double quarterWeight = 0.6;
                double meskWeight = 0.4;

                string meskLetter = GradeCalculator.CalculateRequiredMeskGrade(quarterGrades, meskWeight, quarterWeight, desiredFinalGrade);
                lblMeskNeeded.Text = meskLetter;
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для четвертных оценок и желаемой итоговой оценки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
