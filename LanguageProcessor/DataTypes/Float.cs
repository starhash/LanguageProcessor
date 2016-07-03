using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor.DataTypes
{
    public class Float : DataType
    {
        public Float()
        {
            Name = "Float";
            Operator add = new Operator("plus", "+", Operator.OperatorType.Binary, this);
            Operator subtract = new Operator("minus", "-", Operator.OperatorType.Binary, this);
            Operator multiply = new Operator("multipliedby", "*", Operator.OperatorType.Binary, this);
            Operator divide = new Operator("dividedby", "/", Operator.OperatorType.Binary, this);
            Operator exponent = new Operator("raisedto", "^", Operator.OperatorType.Binary, this);
            Operator modulus = new Operator("moduluswith", "%", Operator.OperatorType.Binary, this);
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

        Variable modulus_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((double)variables[0].Value % (double)variables[1].Value));
        }
        Variable exponent_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((double)(System.Math.Pow((double)variables[0].Value, (double)variables[1].Value))));
        }
        Variable divide_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((double)variables[0].Value / (double)variables[1].Value));
        }
        Variable multiply_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((double)variables[0].Value * (double)variables[1].Value));
        }
        Variable subtract_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((double)variables[0].Value - (double)variables[1].Value));
        }
        Variable add_EvaluateOperator(Operator op, params Variable[] variables)
        {
            return new Variable(this, ((double)variables[0].Value + (double)variables[1].Value));
        }

        public override Variable GetVariable(object s)
        {
            return new Variable(DataTypeList.GetDataType("Float"), (double)s);
        }
    }
}
