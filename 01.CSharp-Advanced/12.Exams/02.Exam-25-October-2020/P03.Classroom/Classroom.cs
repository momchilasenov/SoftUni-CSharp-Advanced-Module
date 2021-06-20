using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.students.Count; }
        }

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            foreach(var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    students.Remove(student);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }

            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.Any(student=>student.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var student in students.Where(s => s.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            else
            {
                return $"No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students
                .FirstOrDefault(student => 
                student.FirstName == firstName && 
                student.LastName == lastName);
        }
    }
}
