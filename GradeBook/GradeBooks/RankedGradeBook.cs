using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool IsWeighted) : base(name, IsWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count >= 5)
            {
                var step = (int)Math.Ceiling(Students.Count * 0.2);
                var grades = Students.OrderByDescending(studnet => studnet.AverageGrade).Select(studnet => studnet.AverageGrade).ToList();

                if (grades[step - 1] <= averageGrade)
                    return 'A';
                else if (grades[(step * 2) - 1] <= averageGrade)
                    return 'B';
                else if (grades[(step * 3) - 1] <= averageGrade)
                    return 'C';
                else if (grades[(step * 4) - 1] <= averageGrade)
                    return 'D';
                else
                    return 'F';
               

            }
            else
            {
                throw new InvalidOperationException();
            }
           
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
            
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else {
                base.CalculateStudentStatistics(name);
            }
        }


    }
    
}
