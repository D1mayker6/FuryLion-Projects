// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;

namespace Entities
{
    public abstract class Human
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public string Patronomyc { get; set; }

        public DateTime Birthday { get; set; }

        public Human()
        {
            Surname = "Неизвестно";
            Name = "Неизвестно";
            Patronomyc = "Неизвестно";
            Birthday = DateTime.Now;
        }

        public Human(string surname, string name, string patronomyc, DateTime birthday)
        {
            Surname = surname;
            Name = name;
            Patronomyc = patronomyc;
            Birthday = birthday;
        }

        public Human(Human otherHuman)
        {
            Surname = otherHuman.Surname;
            Name = otherHuman.Name;
            Patronomyc = otherHuman.Patronomyc;
            Birthday = otherHuman.Birthday;
            Console.WriteLine("Человек успешно создан!");
        }

        public override string ToString()
        {
            return $"\nФамилия: {Surname};\nИмя: {Name};\nОтчество: {Patronomyc};" +
                   $"\nДата рождения: {Birthday.ToString("dd-MM-yyyy")};";
        }

        public void AgeInfo()
        {
            Console.WriteLine($"Возраст {Surname} {Name} {Patronomyc}" +
                              $" составляет {DateTime.Now.Year - Birthday.Year} полных лет!");
        }

        ~Human()
        {
            Console.WriteLine($"Информация о человеке {Surname} успешна уничтожена!");
        }
    }
}
