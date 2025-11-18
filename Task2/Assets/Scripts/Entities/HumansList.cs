// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;

namespace Entities
{
    public static class HumansList
    {
        static public List<Human> Humans { get; set; } = new List<Human>();
        
        private static int _index = 0;

        static public int Index
        {
            get => _index;
            set
            {
                _index = value;
                OnHumansChanged?.Invoke();
            }
        }
        
        public static event Action OnHumansChanged;
        public static void AddHuman(Human human)
        {
            Humans.Add(human);
            OnHumansChanged?.Invoke();
        }

        public static void RemoveHuman(Human human)
        {
            Humans.Remove(human);
            OnHumansChanged?.Invoke();
        }
        public static string PrintHuman()
        {
            if(Count() == 0)
                return "Список пуст";
            var human = Humans[Index];
            return $"{human.GetType().Name}\n{human.ToString()}";
        }

        public static int Count()
        {
            return Humans.Count;
        }
    }
}
