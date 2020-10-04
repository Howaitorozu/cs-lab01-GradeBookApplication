using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentsTwentyPercent = Students.Count * 0.2;
            int studentsWithHigherGradeCount = 0;
            foreach(var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    studentsWithHigherGradeCount += 1;
                }
            }

            double result = studentsWithHigherGradeCount / studentsTwentyPercent;

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Less than 5 students");
            }
            if (result <= 0)
            {
                return 'A';
            }
            else if (result <= 1)
            {
                return 'B';
            }
            else if (result <= 2)
            {
                return 'C';
            }
            else if (result <= 3)
            {
                return 'D';
            }
            else
                return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            } else
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
