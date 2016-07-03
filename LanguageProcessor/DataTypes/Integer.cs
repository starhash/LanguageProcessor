using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor.DataTypes
{
    public sealed class Integer : DataType
    {
        public Integer()
        {
            Name = "Integer";
            Operator add = new Operator("plus", "+", Operator.OperatorType.Binary, this);
            Operator subtract = new Operator("minus", "-", Operator.OperatorType.Binary, this);
            Operator multiply = new Operator("multipliedby", "*", Operator.OperatorType.Binary, this);
            Operator divide = new Operator("dividedby", "/", Operator.OperatorType.Binary, this);
            Operator exponent = new Operator("raisedto", "^", Operator.OperatorType.Binary, this);
            Operator modulus = new Operator("moduluswith", "%", Operator.OperatorType.Binary, this);
            TypeCast todouble = new TypeCast(DataTypeList.GetDataType("Integer"), DataTypeList.GetDataType("Double"));

            todouble.CastVariable += todouble_CastVariable;
            todouble.ReverseCastvariable += todouble_ReverseCastvariable;
            add.EvaluateOperator += add_EvaluateOperator;
            subtract.EvaluateOperator += subtract_EvaluateOperator;
            multiply.EvaluateOperator += multiply_EvaluateOperator;
            divide.EvaluateOperator += divide_EvaluateOperator;
            exponent.EvaluateOperator += exponent_EvaluateOperator;
            modulus.EvaluateOperator += modulus_EvaluateOperator;

            AddOperator(add);
            AddOperator(subtract);
            AddOperator(multiply);
            AddOperator(divide);
            AddOperator(exponent);
            AddOperator(modulus);
        }

        Variable todouble_ReverseCastvariable(Variable variable)
        {
            Variable casted = null;
            try
            {
                casted = new Variable(DataTypeList.GetDataType("Integer"), (int)variable.Value);
            }
            catch (InvalidCastException e)
            {
                throw new InvalidCastException("Cannot cast from Double to Integer");
            }
            return casted;
        }
        Variable todouble_CastVariable(Variable variable)
        {
            Variable casted = null;
            try
            {
                casted = new Variable(DataTypeList.GetDataType("Double"), (double)variable.Value);
            }
            catch (InvalidCastException e)
            {
                throw new InvalidCastException("Cannot cast from Integer to Double");
            }
            return casted;
        }
        Variable modulus_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((int)variables[0].Value % (int)variables[1].Value));
        }
        Variable exponent_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((int)(System.Math.Pow((int)variables[0].Value,(int)variables[1].Value))));
        }
        Variable divide_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((int)variables[0].Value / (int)variables[1].Value));
        }
        Variable multiply_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((int)variables[0].Value * (int)variables[1].Value));
        }
        Variable subtract_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((int)variables[0].Value - (int)variables[1].Value));
        }
        Variable add_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((int)variables[0].Value + (int)variables[1].Value));
        }

        public override Variable GetVariable(object s)
        {
            return new Variable(DataTypeList.GetDataType("Integer"), (int)s);
        }
    }
}
