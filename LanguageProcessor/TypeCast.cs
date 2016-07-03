using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    public class TypeCast
    {
        public DataType From { get; set; }
        public DataType To { get; set; }

        public delegate Variable CastEvalualtor(Variable variable);
        public event CastEvalualtor CastVariable;
        public event CastEvalualtor ReverseCastvariable;

        public TypeCast(DataType from, DataType to)
        {
            From = from;
            To = to;
        }

        public Variable Cast(Variable variable)
        {
            if (!variable.Type.Name.Equals(From.Name))
            {
                throw new ArgumentException("The variable specified is not supported by the cast requested. Please resolve this problem.");
            }
            return CastVariable(variable);
        }

        public Variable ReverseCast(Variable variable)
        {
            if (!variable.Type.Name.Equals(To.Name))
            {
                throw new ArgumentException("The variable specified is not supported by the cast requested. Please resolve this problem.");
            }
            return ReverseCastvariable(variable);
        }
    }
}
