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

        public ListVariable()
        {
            this.listVariable = new List<Variable>();
            this.result = new Variable("","");
        }
        public ListVariable(List<Variable> listVariable, Variable result)
        {
            this.listVariable = listVariable;
            this.result = result;
        }
        public List<Variable> GetVariables() { return listVariable; }

        public String DebugVariables()
        {
            String result = "";
            foreach(Variable item in listVariable)
            {
                result = result + item.GetName() + ":";
                result = result + item.GetDataType() ;
            }
            return result;
        }
        public void PushNewVariable(Variable x)
        {
            listVariable.Add(x);
        }
        public Variable GetResult() { return result; }

        public void SetResult(string name,string dataType)
        {
            result.SetName(name);
            result.SetDatatype(dataType);
        }

        public int GetCountVariable() { return this.listVariable.Count; }

       

    }
}
