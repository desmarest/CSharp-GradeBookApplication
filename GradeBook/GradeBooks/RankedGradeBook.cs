using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students");
            }
            else
            {
                int studentsPerGrade = Students.Count / 5;
                //List<double> sortedAvgGrades = new List<double>();
                List<double> sortedAvgGrades = Students.Select(s => s.AverageGrade).OrderByDescending(AverageGrade => AverageGrade).ToList();

                if (!sortedAvgGrades.Contains(averageGrade))
                {
                    throw new InvalidOperationException("Grade not found in Students list");
                }
                else
                {
                    int grade = sortedAvgGrades.IndexOf(averageGrade) / studentsPerGrade;
                    switch (grade)
                    {
                        case 0:
                            return 'A';
                        case 1:
                            return 'B';
                        case 2:
                            return 'C';
                        case 3:
                            return 'D';
                        default:
                            return 'F';
                    }
                }
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
