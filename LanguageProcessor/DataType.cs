using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    public class DataType
    {
        private string _name;
        public string Name { 
            get 
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private Dictionary<string, Operator> _operators = new Dictionary<string, Operator>();
        public Dictionary<string, Operator> Operators
        {
            get
            {
                return _operators;
            }
            set
            {
                _operators = value;
            }
        }
        private List<TypeCast> _casts = new List<TypeCast>();
        public List<TypeCast> Casts
        {
            get
            {
                return _casts;
            }
            set
            {
                _casts = value;
            }
        }

        public bool AddOperator(Operator op)
        {
            if (this.Operators.Keys.Contains(op.Name))
                return false;
            this.Operators.Add(op.OperatorString, op);
            return true;
        }
        public bool AddCast(TypeCast cast)
        {
            if (this.Casts.Contains(cast))
                return false;
            this.Casts.Add(cast);
            return true;
        }

        public virtual Variable GetVariable(object s)
        {
            return new Variable(new DataType(), s);
        }
    }
}
