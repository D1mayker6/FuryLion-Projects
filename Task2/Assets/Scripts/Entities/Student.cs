// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;

namespace Entities
{
    public class Student : Human
    {
        public string Faculty;

        public int Course;

        public int Group;

        public Student() : base()
        {
            Faculty = "Неизвестно";
            Course = 0;
            Group = 0;
        }

        public Student(string surname, string name, string patronomyc, DateTime birthday,
            string faculty, int course, int group) : base(surname, name, patronomyc, birthday)
        {
            Faculty = faculty;
            Course = course;
            Group = group;
        }

        public Student(Student otherStudent)
        {
            Surname = otherStudent.Surname;
            Name = otherStudent.Name;
            Patronomyc = otherStudent.Patronomyc;
            Birthday = otherStudent.Birthday;
            Faculty = otherStudent.Faculty;
            Course = otherStudent.Course;
            Group = otherStudent.Group;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n Факультет: {Faculty};\nКурс: {Course};\nГруппа: {Group};";
        }

        public new void AgeInfo()
        {
            base.AgeInfo();
        }

        ~Student()
        {
            Console.WriteLine($"Информация о студенте {Surname} успешна уничтожена!");
        }
    }
}