// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UI;
using Action = System.Action;

namespace Entities
{
    public class DataMember
    {
        public string Surname { get; set; }
        
        public Operation Operation {get; set;}
        
        public Action OkButtonAction { get; set; }
        
        public HumanType HumanType { get; set; }
        
        public int HumanNumber {get; set;}

        public DataMember(string surname, Operation operation, Action okButtonAction)
        {
            Surname = surname;
            Operation = operation;
            OkButtonAction = okButtonAction;
        }

        public DataMember(Operation operation)
        {
            Operation = operation;
        }

        public DataMember(Operation operation, Action okButtonAction)
        {
            Operation = operation;
            OkButtonAction = okButtonAction;
        }

        public DataMember(Operation operation, HumanType humanType)
        {
            Operation = operation;
            HumanType = humanType;
        }

        public DataMember(Operation operation, int humanNumber)
        {
            Operation = operation;
            HumanNumber = humanNumber;
        }
    }
}