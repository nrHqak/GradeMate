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
        public Form1()
        {
            InitializeComponent();
            this.Text = "GradeMate - Калькулятор оценок";
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
