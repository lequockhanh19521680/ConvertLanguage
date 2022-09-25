using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ListVariable
    {
        List<Variable> listVariable;
        Variable result;
        public ListVariable(List<Variable> listVariable, Variable result)
        {
            this.listVariable = listVariable;
            this.result = result;
        }
        public List<Variable> GetVariables() { return listVariable; }

        public void PushNewVariable(Variable x)
        {
            listVariable.Add(x);
        }
        public Variable GetResult() { return result; }

    }
}
