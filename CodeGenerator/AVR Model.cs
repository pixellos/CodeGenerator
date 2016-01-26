using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace CodeGenerator
{
    [Serializable]
    public class AVRModel
    {
        public string Model { get; set; } //Example Atmega16a
        public string PortsLetters { get; set; } // "ABCD"
        public int BitAtPortCount { get; set; } // 8
        public CodeOfFunction FunctionsCode { get; set; } //Reserved words(You must implement it, if not it's default): PIN <- Action default to PINs, eg Set, Clear, Toggle, Check, AsOutput, AsInput 
        /* {0} is Pin Letter, {1} is Pin bit
                StringStart>>
                /************************************
        @"
        new { "OutputPin","
        class OutputPin{{
        public:
            void static AsOutput()
            {{
                DDR{0} |= (1>>{1});
            }}
        }};
        "
            */
        public ItemsToItems PinToFunctions { get; set; } 
        /*
        new {"A1", new List<string>(){"OutputPin"}
        */

        public ItemsToItems FunctionToFunctions { get; set; }
        /*
        new {"TIMER1", new List<string>(){"Timer1Clock"}
        */
    }

    [Serializable]
    public class CodeOfFunction
    {
        public static CodeOfFunction Get(List<string> Function, List<string> Code )
        {
            return new CodeOfFunction() {Function = Function, Code = Code};
        }

        public List<string> Function { get; set; }
        public List<string> Code { get; set; } 
    }

    //Dict isnt supported with XML :/
    [Serializable]
    public class ItemsToItems // Indexes of list are equal
    {
        public static ItemsToItems Get(List<string> Id, List<List<string>> Values)
        {
            return new ItemsToItems()
            {
                Id = Id,
                Values = Values
            };
        }
        public List<string> Id { get; set; }
        public List<List<string>> Values { get; set; }
    }
}

