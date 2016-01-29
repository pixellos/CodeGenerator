using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PixelloTools.XmlObject;

namespace CodeGenerator
{
    public class AvrModelGenerator
    {
        AVRModel model;
        private ObjectSerializer<AVRModel> objectSerializer;

        private AVRModel prepareAvrModel()
        {
            model = new AVRModel
            {
                PinToFunctions = new ItemsToItems
                {
                    Id = new List<string>(),
                    Values = new List<List<string>>()
                },
                FunctionToFunctions = new ItemsToItems
                {
                    Id = new List<string>(),
                    Values = new List<List<string>>()
                },
                FunctionsCode = new CodeOfFunction
                {
                    Function = new List<string>(),
                    Code = new List<string>()
                }
            };
            return model;
        }

        public AvrModelGenerator()
        {
            model = prepareAvrModel();
        }

        public void AddNewFunctionCode()
        {
            

        }

    }
}
