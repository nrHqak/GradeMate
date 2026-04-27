using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Label lblNextGradeHint;
        private Label lblMeskFormula;
        private Label lblMeskMapping;
        private Button btnAddScenario;
        private ListBox lstMeskScenarios;

        public Form1()
        {
            InitializeComponent();
            this.Text = "GradeMate - Калькулятор оценок";
            ApplyBlueTheme();
            SetupAlignedLayouts();
            SetupCurrentGradeEnhancements();
            SetupMeskTab();
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
                    ApplyRoundedCorners(button, 12);
                    button.Resize += (_, __) => ApplyRoundedCorners(button, 12);
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

        private void ApplyRoundedCorners(Button button, int radius)
        {
            if (button.Width <= 0 || button.Height <= 0)
            {
                return;
            }

            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle bounds = new Rectangle(0, 0, button.Width, button.Height);
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
        }

        private void SetupCurrentGradeEnhancements()
        {
            lblNextGradeHint = new Label
            {
                AutoSize = true,
                Location = new Point(32, 305),
                ForeColor = _primaryTextColor,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point),
                Text = "Подсказка: заполните поля для расчета."
            };

            tabPageCurrentGrade.Controls.Add(lblNextGradeHint);
        }

        private void SetupAlignedLayouts()
        {
            // Текущая оценка
            int leftLabel = 32;
            int leftInput = 210;
            label1.Location = new Point(leftLabel, 30);
            txtSorScore.Location = new Point(leftInput, 27);
            label2.Location = new Point(leftLabel, 68);
            txtMaxSorScore.Location = new Point(leftInput, 65);
            label3.Location = new Point(leftLabel, 106);
            txtSochScore.Location = new Point(leftInput, 103);
            label4.Location = new Point(leftLabel, 144);
            txtMaxSochScore.Location = new Point(leftInput, 141);
            btnCalculateCurrentGrade.Location = new Point(leftLabel, 185);
            btnCalculateCurrentGrade.Size = new Size(160, 36);
            label5.Location = new Point(leftLabel, 248);
            lblCurrentPercentage.Location = new Point(leftInput, 245);
            label6.Location = new Point(leftLabel, 282);
            lblCurrentGrade.Location = new Point(leftInput, 279);

            // Прогноз СОЧ
            label8.Location = new Point(leftLabel, 30);
            txtSorScoreDesired.Location = new Point(leftInput, 27);
            label9.Location = new Point(leftLabel, 68);
            txtMaxSorScoreDesired.Location = new Point(leftInput, 65);
            label10.Location = new Point(leftLabel, 106);
            txtMaxSochScoreDesired.Location = new Point(leftInput, 103);
            label11.Location = new Point(leftLabel, 144);
            txtDesiredGrade.Location = new Point(leftInput, 141);
            btnCalculateDesiredSoch.Location = new Point(leftLabel, 188);
            btnCalculateDesiredSoch.Size = new Size(160, 36);
            label12.Location = new Point(leftLabel, 248);
            lblMinSochNeeded.Location = new Point(leftInput, 245);
        }

        private void SetupMeskTab()
        {
            label13.Text = "Годовая оценка:";
            label14.Text = "Результат МЭСК:";
            label18.Text = "Итоговая оценка:";
            btnCalculateMeskGrade.Text = "Рассчитать итог";

            int leftLabel = 32;
            int leftInput = 250;
            label13.Location = new Point(leftLabel, 36);
            txtQuarter1.Location = new Point(leftInput, 33);
            label14.Location = new Point(leftLabel, 76);
            txtQuarter2.Location = new Point(leftInput, 73);

            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            txtQuarter3.Visible = false;
            txtQuarter4.Visible = false;
            txtDesiredFinalGradeMesk.Visible = false;

            lblMeskMapping = new Label
            {
                AutoSize = true,
                Location = new Point(leftLabel, 108),
                ForeColor = _primaryTextColor,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Шкала: 5=A/A*, 4=B/C, 3=D/E, 2=U"
            };
            tabPageMesk.Controls.Add(lblMeskMapping);

            lblMeskFormula = new Label
            {
                AutoSize = true,
                Location = new Point(leftLabel, 132),
                ForeColor = _primaryTextColor,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point),
                Text = "Формула: итог = годовая × 0.6 + МЭСК × 0.4"
            };
            tabPageMesk.Controls.Add(lblMeskFormula);

            btnCalculateMeskGrade.Location = new Point(leftLabel, 168);
            btnCalculateMeskGrade.Size = new Size(160, 36);

            btnAddScenario = new Button
            {
                Location = new Point(220, 168),
                Size = new Size(160, 36),
                Text = "Добавить сценарий"
            };
            btnAddScenario.Click += AddScenario_Click;
            tabPageMesk.Controls.Add(btnAddScenario);

            label18.Location = new Point(leftLabel, 222);
            lblMeskNeeded.Location = new Point(leftInput, 220);

            lstMeskScenarios = new ListBox
            {
                Location = new Point(leftLabel, 252),
                Size = new Size(400, 64),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
            };
            tabPageMesk.Controls.Add(lstMeskScenarios);

            StyleControls(tabPageMesk.Controls);
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
                lblNextGradeHint.Text = GradeCalculator.CalculatePointsToNextGradeHint(sorScore, sochScore, maxSorScore, maxSochScore);
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
                int annualGrade = int.Parse(txtQuarter1.Text);
                string meskLetter = txtQuarter2.Text;

                var result = GradeCalculator.CalculateFinalGradeFromAnnualAndMesk(annualGrade, meskLetter);
                lblMeskNeeded.Text = $"{result.Item2} ({result.Item1:F2})";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректную годовую оценку (2-5) и буквенную оценку МЭСК (A/A*/B/C/D/E/U).", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddScenario_Click(object sender, EventArgs e)
        {
            try
            {
                int annualGrade = int.Parse(txtQuarter1.Text);
                string meskLetter = txtQuarter2.Text;
                var result = GradeCalculator.CalculateFinalGradeFromAnnualAndMesk(annualGrade, meskLetter);

                string scenarioLine = $"Сценарий: годовая {annualGrade}, МЭСК {meskLetter.ToUpperInvariant()} → итог {result.Item2} ({result.Item1:F2})";
                lstMeskScenarios.Items.Add(scenarioLine);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
            {
                MessageBox.Show("Чтобы добавить сценарий, введите корректные данные для годовой оценки и МЭСК.", "Ошибка сценария", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
