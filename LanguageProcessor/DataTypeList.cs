using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageProcessor.DataTypes;

namespace LanguageProcessor
{
    public class DataTypeList
    {
        private static Dictionary<string, DataType> Types;

        static DataTypeList()
        {
            Console.WriteLine("Static Executed");
            Types = new Dictionary<string, DataType>();
            Float fl = new Float();
            Types.Add(fl.Name, fl);
            Integer integer = new Integer();
            Types.Add(integer.Name, integer);
            Bit bit = new Bit();
            Types.Add(bit.Name, bit);
            Character character = new Character();
            Types.Add(character.Name, character);
            CharacterString str = new CharacterString();
            Types.Add(str.Name, str);
            DataType Object = new DataType() { Name = "Object" };
            Types.Add(Object.Name, Object);
        }

        public static DataType GetDataType(string s)
        {
            if (!Types.Keys.Contains(s))
            {
                return Types["Object"];
            }
            return Types[s];
        }

        public static Variable GetVariable(DataType d, object s)
        {
            return Types[d.Name].GetVariable(s);
        }
    }
}
