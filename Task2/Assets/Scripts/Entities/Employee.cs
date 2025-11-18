// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;

namespace Entities
{
    public class Employee : Human
    {
        public string Organisation { get; set; }

        public int Salary { get; set; }

        public int Experience { get; set; }

        public Employee() : base()
        {
            Organisation = "Неизвестно";
            Salary = 0;
            Experience = 0;
        }

        public Employee(string surname, string name, string patronomyc, DateTime birthday,
            string organisation, int salary, int experience) : base(surname, name, patronomyc, birthday)
        {
            Organisation = organisation;
            Salary = salary;
            Experience = experience;
        }

        public Employee(Employee otherEmployee)
        {
            Surname = otherEmployee.Surname;
            Name = otherEmployee.Name;
            Patronomyc = otherEmployee.Patronomyc;
            Birthday = otherEmployee.Birthday;
            Organisation = otherEmployee.Organisation;
            Salary = otherEmployee.Salary;
            Experience = otherEmployee.Experience;
            Console.WriteLine("Работник успешно создан!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nОрганизация: {Organisation};\nЗаработная плата: {Salary}$;" +
                   $"\nСтаж: {Experience};";
        }

        public new void AgeInfo()
        {
            base.AgeInfo();
        }

        ~Employee()
        {
            Console.WriteLine($"Информация о работнике {Surname} успешна уничтожена!");
        }
    }
}