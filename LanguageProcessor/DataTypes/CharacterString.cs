using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor.DataTypes
{
    public class CharacterString : DataType
    {
        public CharacterString()
        {
            Name = "CharacterString";
            Operator concat = new Operator("concatenate", "+", Operator.OperatorType.Binary, this);
            concat.EvaluateOperator += concat_EvaluateOperator;
            Operator subtract = new Operator("minus", "-", Operator.OperatorType.Binary, this);
            subtract.EvaluateOperator += subtract_EvaluateOperator;
            Operator charat = new Operator("charat", "@", this, DataTypeList.GetDataType("Integer"));
            charat.EvaluateOperator += charat_EvaluateOperator;
            Operator length = new Operator("length", "#", this);
            length.EvaluateOperator += length_EvaluateOperator;
            Operator indexof = new Operator("indexof", "=@", this, DataTypeList.GetDataType("Character"));
            indexof.EvaluateOperator += indexof_EvaluateOperator;

            AddOperator(concat);
            AddOperator(subtract);
            AddOperator(charat);
            AddOperator(length);
            AddOperator(indexof);
        }

        Variable indexof_EvaluateOperator(Operator op, params Variable[] variables)
        {
            string s = (string)variables[0].Value;
            char c = (char)variables[1].Value;
            return DataTypeList.GetDataType("Integer").GetVariable(s.Length);
        }
        Variable length_EvaluateOperator(Operator op, params Variable[] variables)
        {
            string s = (string)variables[0].Value;
            return DataTypeList.GetDataType("Integer").GetVariable(s.Length);
        }
        Variable charat_EvaluateOperator(Operator op, params Variable[] variables)
        {
            string s = (string)variables[0].Value;
            return new Variable(DataTypeList.GetDataType("Character"), s[(int)variables[1].Value]);
        }
        Variable subtract_EvaluateOperator(Operator op, params Variable[] variables)
        {
            string s = (string)(variables[0].Value);
            return new Variable(this,s.Replace((string)variables[1].Value, ""));
        }
        Variable concat_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, (string)variables[0].Value + (string)variables[1].Value);
        }
    }
}
