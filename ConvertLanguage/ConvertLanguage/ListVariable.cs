using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertLanguage
{
    internal class ListVariable
    {
        List<Variable> listVariable;
        Variable variableArray;
        Variable result;

        public ListVariable()
        {
            this.listVariable = new List<Variable>();
            this.variableArray = new Variable("","");

            this.result = new Variable("","");
        }
        public ListVariable(List<Variable> listVariable, Variable result, Variable variableArray)
        {
            this.listVariable = listVariable;
            this.result = result;
            this.variableArray = variableArray;
        }
        public List<Variable> GetVariables() { return listVariable; }
        public Variable GetVariableArray() { return variableArray; }
        public String DebugVariables()
        {
            String result = "";
            foreach (Variable item in listVariable)
            {
                result = result + item.GetName() + ":";
                result = result + item.GetDataType();
            }
            return result;
        }
        public void PushNewVariable(Variable x)
        {
            listVariable.Add(x);
        }
        public Variable GetResult() { return result; }

        public void SetResult(string name, string dataType)
        {
            result.SetName(name);
            result.SetDatatype(dataType);
        }

        public void SetVariableArray(string name, string dataType)
        {
            variableArray.SetName(name);
            variableArray.SetDatatype(dataType);
        }
        public bool ConTainArray()
        {
            return !((variableArray.GetDataType() == ""));
        }
        public int GetCountVariable() { return this.listVariable.Count; }



    }
}
