using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    public class Variable : Token
    {
        private DataType _type;
        private object _value;

        public DataType Type {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public Variable(DataType type, object value)
        {
            _type = type;
            _value = value;
        }

        public Variable this[string oper, params Variable[] variables]
        {
            get
            {
                List<Variable> list = variables.ToList();
                list.Insert(0, this);
                variables = list.ToArray();
                Operator op = null;
                foreach (Operator o in _type.Operators.Values)
                {
                    bool all = true;
                    if (o.Operands.Length != variables.Length)
                        continue;
                    for (int i = 0; i < o.Operands.Length; i++)
                    {
                        if(!variables[i].Type.Name.Equals(o.Operands[i].Name))
                        {
                            all = false;
                            break;
                        }
                    }
                    if (all && o.OperatorString.Equals(oper))
                    {
                        op = o;
                        break;
                    }
                }
                if (op == null)
                {
                    return null;
                }
                return op.Evaluate(variables);
            }
        }

        public static Variable GetVariable(string d, object s)
        {
            return DataTypeList.GetDataType(d).GetVariable(s);
        }
    }
}
