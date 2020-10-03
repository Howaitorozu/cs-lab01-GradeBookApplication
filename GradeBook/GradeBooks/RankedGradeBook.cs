using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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
            return 'A';

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
