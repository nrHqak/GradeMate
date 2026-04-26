using System;
using System.Collections.Generic;

namespace GradeMate
{
    public static class GradeCalculator
    {
        // Default grading scale thresholds (can be made configurable later)
        private static readonly Dictionary<int, Tuple<double, double>> _gradeThresholds = new Dictionary<int, Tuple<double, double>>
        {
            {5, Tuple.Create(90.0, 100.0)},
            {4, Tuple.Create(75.0, 89.9)},
            {3, Tuple.Create(50.0, 74.9)},
            {2, Tuple.Create(25.0, 49.9)},
            {1, Tuple.Create(0.0, 24.9)}
        };

        /// <summary>
        /// Calculates the current grade based on SOR and SOCH scores.
        /// </summary>
        /// <param name="sorScore">Score for SOR.</param>
        /// <param name="sochScore">Score for SOCH.</param>
        /// <param name="maxSorScore">Maximum possible score for SOR.</param>
        /// <param name="maxSochScore">Maximum possible score for SOCH.</param>
        /// <returns>A tuple containing the percentage and the 5-point grade.</returns>
        public static Tuple<double, int> CalculateCurrentGrade(double sorScore, double sochScore, double maxSorScore, double maxSochScore)
        {
            if (maxSorScore <= 0 || maxSochScore <= 0)
            {
                throw new ArgumentException("Maximum scores must be greater than zero.");
            }
            if (sorScore < 0 || sorScore > maxSorScore || sochScore < 0 || sochScore > maxSochScore)
            {
                throw new ArgumentOutOfRangeException("Scores must be within valid range (0 to max score).");
            }

            double sorPercentage = (sorScore / maxSorScore) * 50; // Assuming SOR is 50% of total
            double sochPercentage = (sochScore / maxSochScore) * 50; // Assuming SOCH is 50% of total
            double totalPercentage = sorPercentage + sochPercentage;

            int grade = ConvertPercentageToFivePointScale(totalPercentage);

            return Tuple.Create(totalPercentage, grade);
        }

        /// <summary>
        /// Converts a percentage to a 5-point grade.
        /// </summary>
        /// <param name="percentage">The percentage score.</param>
        /// <returns>The 5-point grade.</returns>
        public static int ConvertPercentageToFivePointScale(double percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentOutOfRangeException("Percentage must be between 0 and 100.");
            }

            foreach (var entry in _gradeThresholds)
            {
                if (percentage >= entry.Value.Item1 && percentage <= entry.Value.Item2)
                {
                    return entry.Key;
                }
            }
            return 2; // Default to 2 if no match (e.g., for very low scores not explicitly in thresholds)
        }

        /// <summary>
        /// Calculates the minimum SOCH score needed for a desired quarter grade.
        /// </summary>
        /// <param name="sorScore">Current SOR score.</param>
        /// <param name="maxSorScore">Maximum possible SOR score.</param>
        /// <param name="maxSochScore">Maximum possible SOCH score.</param>
        /// <param name="desiredGrade">Desired 5-point quarter grade.</param>
        /// <returns>Minimum SOCH score needed.</returns>
        public static double CalculateMinSochForDesiredGrade(double sorScore, double maxSorScore, double maxSochScore, int desiredGrade)
        {
            if (maxSorScore <= 0 || maxSochScore <= 0)
            {
                throw new ArgumentException("Maximum scores must be greater than zero.");
            }
            if (sorScore < 0 || sorScore > maxSorScore)
            {
                throw new ArgumentOutOfRangeException("SOR score must be within valid range (0 to max SOR score).");
            }
            if (!_gradeThresholds.ContainsKey(desiredGrade))
            {
                throw new ArgumentException("Desired grade is not valid.");
            }

            double minDesiredPercentage = _gradeThresholds[desiredGrade].Item1;

            // Calculate the percentage contributed by SOR
            double sorContributionPercentage = (sorScore / maxSorScore) * 50;

            // Calculate the remaining percentage needed from SOCH
            double remainingPercentageNeeded = minDesiredPercentage - sorContributionPercentage;

            // If remainingPercentageNeeded is negative, it means desired grade is already achieved or exceeded
            if (remainingPercentageNeeded <= 0)
            {
                return 0; // No SOCH score needed, or already achieved
            }

            // Calculate the minimum SOCH score required
            // remainingPercentageNeeded = (sochScore / maxSochScore) * 50
            double minSochScore = (remainingPercentageNeeded / 50) * maxSochScore;

            // Ensure the calculated SOCH score does not exceed maxSochScore
            return Math.Min(minSochScore, maxSochScore);
        }

        /// <summary>
        /// Calculates the required MESK letter grade based on quarter grades and coefficients.
        /// </summary>
        /// <param name="quarterGrades">List of 5-point quarter grades.</param>
        /// <param name="meskWeight">Weight of the MESK exam (e.g., 0.4 for 40%).</param>
        /// <param name="quarterWeight">Weight of quarter grades (e.g., 0.6 for 60%).</param>
        /// <param name="desiredFinalGrade">Desired final 5-point grade.</param>
        /// <returns>The required MESK letter grade (A, B, C, D, E).</returns>
        public static string CalculateRequiredMeskGrade(List<int> quarterGrades, double meskWeight, double quarterWeight, int desiredFinalGrade)
        {
            if (quarterGrades == null || quarterGrades.Count == 0)
            {
                throw new ArgumentException("Quarter grades list cannot be empty.");
            }
            if (meskWeight <= 0 || quarterWeight <= 0 || (meskWeight + quarterWeight) != 1.0)
            {
                throw new ArgumentException("Weights must be positive and sum to 1.0.");
            }
            if (!_gradeThresholds.ContainsKey(desiredFinalGrade))
            {
                throw new ArgumentException("Desired final grade is not valid.");
            }

            double averageQuarterGrade = 0;
            foreach (int grade in quarterGrades)
            {
                if (grade < 1 || grade > 5)
                {
                    throw new ArgumentOutOfRangeException("Quarter grades must be between 1 and 5.");
                }
                averageQuarterGrade += grade;
            }
            averageQuarterGrade /= quarterGrades.Count;

            // Convert desired final 5-point grade to minimum percentage
            double minDesiredFinalPercentage = _gradeThresholds[desiredFinalGrade].Item1;

            // The 5-point scale is typically 1-5. To convert to a 0-100% scale for calculation,
            // we can assume a linear mapping or use the existing percentage thresholds for 5-point grades.
            // For simplicity, let's assume a linear mapping for quarter grades to a 0-100 scale if needed,
            // but the prompt implies direct use of 5-point grades for averaging.
            // Let's re-evaluate: The prompt states "Выводит, какую буквенную оценку (A, B, C, D, E) нужно получить на МЭСК для достижения желаемой итоговой оценки."
            // This implies we need to work with percentages for the final calculation.
            // We need to convert the average 5-point quarter grade to a percentage to use with the weights.
            // A simple linear conversion for 5-point to 100% scale: (grade / 5) * 100.
            // However, the prompt also mentions "90-100% = 5, 75-89% = 4", so we should use these thresholds.
            // Let's assume the averageQuarterGrade represents a point within the range of its corresponding percentage.
            // For simplicity, we can use the midpoint of the percentage range for each 5-point grade.
            // Or, more accurately, we need to find the percentage equivalent of the average 5-point quarter grade.
            // This is tricky as the mapping is not linear. Let's assume for now that the average 5-point grade
            // can be directly used in a weighted average with a MESK percentage.

            // To get the desired final percentage, we use the lower bound of the desired 5-point grade.
            double targetFinalPercentage = _gradeThresholds[desiredFinalGrade].Item1;

            // The contribution from quarter grades to the final percentage
            // This assumes a direct mapping of 5-point average to a percentage, which is not explicitly defined.
            // Let's make an assumption: 5-point grade can be converted to a percentage by mapping 1 to 0% and 5 to 100%.
            // Or, more realistically, we need to convert the average 5-point grade back to a percentage based on the grading scale.
            // For now, let's use a simplified approach for the average quarter grade's percentage contribution.
            // We need to convert the average 5-point grade to a percentage based on the defined thresholds.
            // This is an approximation. A more robust solution would involve a reverse mapping or more detailed requirements.
            double averageQuarterPercentage = 0;
            if (averageQuarterGrade >= 4.5) averageQuarterPercentage = 90; // Approximating 5
            else if (averageQuarterGrade >= 3.5) averageQuarterPercentage = 75; // Approximating 4
            else if (averageQuarterGrade >= 2.5) averageQuarterPercentage = 50; // Approximating 3
            else if (averageQuarterGrade >= 1.5) averageQuarterPercentage = 25; // Approximating 2
            else averageQuarterPercentage = 0; // Approximating 1

            double quarterGradesContribution = averageQuarterPercentage * quarterWeight;

            // Calculate the percentage needed from MESK
            double meskPercentageNeeded = (targetFinalPercentage - quarterGradesContribution) / meskWeight;

            // Convert percentage to letter grade (A, B, C, D, E)
            if (meskPercentageNeeded >= 90) return "A";
            else if (meskPercentageNeeded >= 75) return "B";
            else if (meskPercentageNeeded >= 50) return "C";
            else if (meskPercentageNeeded >= 25) return "D";
            else return "E";
        }

        public static int ConvertMeskLetterToGrade(string meskLetter)
        {
            if (string.IsNullOrWhiteSpace(meskLetter))
            {
                throw new ArgumentException("MESC letter cannot be empty.");
            }

            string normalizedLetter = meskLetter.Trim().ToUpperInvariant();
            return normalizedLetter switch
            {
                "A" => 5,
                "A*" => 5,
                "B" => 4,
                "C" => 4,
                "D" => 3,
                "E" => 3,
                "U" => 2,
                _ => throw new ArgumentException("MESC letter must be one of: A, A*, B, C, D, E, U.")
            };
        }

        public static Tuple<double, int> CalculateFinalGradeFromAnnualAndMesk(int annualGrade, string meskLetter)
        {
            if (annualGrade < 2 || annualGrade > 5)
            {
                throw new ArgumentOutOfRangeException("Annual grade must be in range from 2 to 5.");
            }

            int meskNumericGrade = ConvertMeskLetterToGrade(meskLetter);
            double weightedResult = annualGrade * 0.6 + meskNumericGrade * 0.4;
            int finalGrade = (int)Math.Round(weightedResult, MidpointRounding.AwayFromZero);

            return Tuple.Create(weightedResult, Math.Min(5, Math.Max(2, finalGrade)));
        }

        public static string CalculatePointsToNextGradeHint(double sorScore, double sochScore, double maxSorScore, double maxSochScore)
        {
            var current = CalculateCurrentGrade(sorScore, sochScore, maxSorScore, maxSochScore);
            int currentGrade = current.Item2;
            double currentPercentage = current.Item1;

            if (currentGrade >= 5)
            {
                return "Отлично! У вас уже максимальная оценка (5).";
            }

            int nextGrade = currentGrade + 1;
            double targetPercentage = _gradeThresholds[nextGrade].Item1;
            double percentageNeeded = targetPercentage - currentPercentage;
            double additionalSochPoints = (percentageNeeded / 50.0) * maxSochScore;
            double remainingSochCapacity = maxSochScore - sochScore;

            if (additionalSochPoints <= 0)
            {
                return $"До следующей оценки ({nextGrade}) осталось 0 баллов.";
            }

            if (additionalSochPoints > remainingSochCapacity)
            {
                return $"До оценки {nextGrade} не хватает {additionalSochPoints:F2} балла(ов) СОЧ, но максимум можно добрать только {remainingSochCapacity:F2}.";
            }

            return $"До оценки {nextGrade} осталось {additionalSochPoints:F2} балла(ов) по СОЧ.";
        }
    }
}
