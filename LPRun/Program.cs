using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using LanguageProcessor;
using LanguageProcessor.DataTypes;

namespace LPRun
{
    class Program
    {
        public static Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
        
        static void Main(string[] args)
        {
            Variable d = new Variable(DataTypeList.GetDataType("Integer"), -10);
            Variable c = Mathematics._("Abs", d);
            Console.WriteLine(c.Value);
            Console.ReadKey();
        }
    }
}
