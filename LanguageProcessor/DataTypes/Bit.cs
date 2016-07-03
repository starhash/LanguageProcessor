using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor.DataTypes
{
    public sealed class Bit : DataType
    {
        private int _bit;

        private static Bit _low = new Bit() { _bit = 0 };
        private static Bit _high = new Bit() { _bit = 1 };
        private static Bit _indeterminate = new Bit() { _bit = -1 };
        public static Bit Low
        {
            get
            {
                return _low.Copy();
            }
        }
        public static Bit High
        {
            get
            {
                return _high.Copy();
            }
        }
        public static Bit Indeterminate
        {
            get
            {
                return _indeterminate.Copy();
            }
        }

        public Bit()
        {
            Name = "Bit";
            Operator not = new Operator("complement", "!", Operator.OperatorType.Unary, this);
            Operator and = new Operator("and", ".", Operator.OperatorType.Binary, this);
            Operator or = new Operator("or", "+", Operator.OperatorType.Binary, this);
            Operator nand = new Operator("nand", "!.", Operator.OperatorType.Binary, this);
            Operator nor = new Operator("nor", "!+", Operator.OperatorType.Binary, this);
            Operator xor = new Operator("xor", "^", Operator.OperatorType.Binary, this);
            Operator xnor = new Operator("xnor", "!^", Operator.OperatorType.Binary, this);
            not.EvaluateOperator += not_EvaluateOperator;
            and.EvaluateOperator += and_EvaluateOperator;
            or.EvaluateOperator += or_EvaluateOperator;
            nand.EvaluateOperator += nand_EvaluateOperator;
            nor.EvaluateOperator += nor_EvaluateOperator;
            xor.EvaluateOperator += xor_EvaluateOperator;
            xnor.EvaluateOperator += xnor_EvaluateOperator;
            AddOperator(not);
            AddOperator(and);
            AddOperator(or);
            AddOperator(nand);
            AddOperator(nor);
            AddOperator(xor);
            AddOperator(xnor);
        }

        Variable xnor_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit var1 = (Bit)variables[0].Value;
            Bit var2 = (Bit)variables[1].Value;
            if (var1 == Bit.Low || var2 == Bit.Low)
                return new Variable(this, Bit.High);
            else if (var1 == Bit.Indeterminate || var2 == Bit.Indeterminate)
                return new Variable(this, Bit.Indeterminate);
            else
                return new Variable(this, Bit.Low);
        }
        Variable xor_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit var1 = (Bit)variables[0].Value;
            Bit var2 = (Bit)variables[1].Value;
            if (var1 == var2)
                return new Variable(this, Bit.Low);
            else if (var1 == Bit.Indeterminate || var2 == Bit.Indeterminate)
                return new Variable(this, Bit.Indeterminate);
            else
                return new Variable(this, Bit.High);
        }
        Variable nor_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit var1 = (Bit)variables[0].Value;
            Bit var2 = (Bit)variables[1].Value;
            if (var1 == Bit.Low && var2 == Bit.Low)
                return new Variable(this, Bit.High);
            else if (var1 == Bit.Indeterminate || var2 == Bit.Indeterminate)
                return new Variable(this, Bit.Indeterminate);
            else
                return new Variable(this, Bit.Low);
        }
        Variable nand_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit var1 = (Bit)variables[0].Value;
            Bit var2 = (Bit)variables[1].Value;
            if (var1 == Bit.Low || var2 == Bit.Low)
                return new Variable(this, Bit.High);
            else if (var1 == Bit.Indeterminate || var2 == Bit.Indeterminate)
                return new Variable(this, Bit.Indeterminate);
            else
                return new Variable(this, Bit.Low);
        }
        Variable or_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit var1 = (Bit)variables[0].Value;
            Bit var2 = (Bit)variables[1].Value;
            if (var1 == Bit.High || var2 == Bit.High)
                return new Variable(this, Bit.High);
            else if (var1 == Bit.Indeterminate || var2 == Bit.Indeterminate)
                return new Variable(this, Bit.Indeterminate);
            else
                return new Variable(this, Bit.Low);
        }
        Variable and_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit var1 = (Bit)variables[0].Value;
            Bit var2 = (Bit)variables[1].Value;
            if (var1 == var2)
                return new Variable(this, var1.Copy());
            else if (var1 == Bit.Indeterminate || var2 == Bit.Indeterminate)
                return new Variable(this, Bit.Indeterminate);
            else
                return new Variable(this, Bit.Low);
        }
        Variable not_EvaluateOperator(Operator op, params Variable[] variables)
        {
            Bit result = (Bit)variables[0].Value;
            if(result == Bit.Low)
                result = Bit.High;
            else if(result == Bit.High)
                result = Bit.Low;
            else
                result = Bit.Indeterminate;
            return new Variable(this, result);
        }

        public bool Equals(Bit obj)
        {
            return obj._bit == this._bit;
        }
        public static bool operator == (Bit bit1, Bit bit2) 
        {
            return bit1.Equals(bit2);
        }
        public static bool operator !=(Bit bit1, Bit bit2)
        {
            return !bit1.Equals(bit2);
        }
        public override string ToString()
        {
            return _bit + "";
        }
        public Bit Copy()
        {
            return new Bit() { _bit = this._bit };
        }
        public static Bit FromInteger(int i)
        {
            if (i < 0)
                return Bit.Indeterminate;
            else if (i == 0)
                return Bit.Low;
            return Bit.High;
        }
        public Variable ToVariable()
        {
            return new Variable(this, this);
        }

        public override Variable GetVariable(object s)
        {
            return new Variable(DataTypeList.GetDataType("Bit"), FromInteger((int)s));
        }
    }
}
