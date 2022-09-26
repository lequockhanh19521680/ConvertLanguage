using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Variable : Text
    {
        string dataType;
        public Variable(string name1, string dataType) : base(name1)
        {
            dataType.Replace(" ", "");
            this.dataType = dataType;
        }

        public string GetDataType() { return dataType; }
        public override string GetColor() { return "Red"; }
        public string GetColorDataType() { return "Blue"; }

        public void SetDatatype(String datatype) { this.dataType = datatype; }

    }
}
