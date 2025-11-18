// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;

namespace Entities
{
    public sealed class Driver : Employee
    {
        public string Mark { get; set; }

        public string Model { get; set; }

        public Driver(): base()
        {
            Mark = "Неизвестно";
            Model = "Неизвестно";
        }

        public Driver(string surname, string name, string patronomyc, DateTime birthday,
        string organisation, int salary, int experience, string mark, string model) : base
        (surname, name, patronomyc, birthday, organisation, salary, experience)
        {
            Mark = mark;
            Model = model;
        }

        public Driver(Driver otherDriver)
        {
            Surname = otherDriver.Surname;
            Name = otherDriver.Name;
            Patronomyc = otherDriver.Patronomyc;
            Birthday = otherDriver.Birthday;
            Organisation = otherDriver.Organisation;
            Salary = otherDriver.Salary;
            Experience = otherDriver.Experience;
            Mark = otherDriver.Mark;
            Model = otherDriver.Model;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nМарка автомобиля: {Mark};\nМодель автомобиля: {Model};";
        }

        public new void AgeInfo()
        {
            base.AgeInfo();
        }

        ~Driver()
        {
            Console.WriteLine($"Информация о водителе {Surname} успешна уничтожена!");
        }
    }
}