using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor.DataTypes
{
    public sealed class Character : DataType
    {
        public Character()
        {
            Name = "Character";
            Operator add = new Operator("plus", "+", this, DataTypeList.GetDataType("Integer"));
            Operator subtract = new Operator("minus", "-", this, DataTypeList.GetDataType("Integer"));
            Operator multiply = new Operator("into", "*", this, DataTypeList.GetDataType("Integer"));
            Operator divide = new Operator("dividedby", "/", this, DataTypeList.GetDataType("Integer"));
            TypeCast integer = new TypeCast(this,
                                              DataTypeList.GetDataType("Integer"));
            integer.CastVariable += integer_CastVariable;
            integer.ReverseCastvariable += integer_ReverseCastvariable;
            add.EvaluateOperator += add_EvaluateOperator;
            subtract.EvaluateOperator += subtract_EvaluateOperator;
            multiply.EvaluateOperator += multiply_EvaluateOperator;
            divide.EvaluateOperator += divide_EvaluateOperator;

            AddOperator(add);
            AddOperator(subtract);
            AddOperator(multiply);
            AddOperator(divide);
            AddCast(integer);
        }

        Variable integer_ReverseCastvariable(Variable variable)
        {
            Variable casted = null;
            try
            {
                casted = new Variable(DataTypeList.GetDataType("Character"), (int)variable.Value);
            }
            catch (InvalidCastException e)
            {
                throw new InvalidCastException("Cannot cast from Integer to Character");
            }
            return casted;
        }
        Variable integer_CastVariable(Variable variable)
        {
            Variable casted = null;
            try
            {
                casted = new Variable(DataTypeList.GetDataType("Integer"), (int)variable.Value);
            }
            catch (InvalidCastException e)
            {
                throw new InvalidCastException("Cannot cast from Character to Integer");
            }
            return casted;
        }

        Variable divide_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, (char)((char)(variables[0].Value) / (int)(variables[1].Value)));
        }
        Variable multiply_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, (char)((char)(variables[0].Value) * (int)(variables[1].Value)));
        }
        Variable subtract_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, (char)((char)(variables[0].Value) - (int)(variables[1].Value)));
        }
        Variable add_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, (char)((char)(variables[0].Value) + (int)(variables[1].Value)));
        }

        public override Variable GetVariable(object s)
        {
            return new Variable(DataTypeList.GetDataType("Character"), (char)s);
        }
    }
}
