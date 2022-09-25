using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Variable
    {
        string name;
        string dataType;
        string color;

        public Variable()
        {
            name = "";
            dataType = "";
        }
        public Variable(string name1, string dataType)
        {
            name = name1;
            color = "#6A4C9E";
            this.dataType = dataType;
        }

        public string GetName() { return name; }
        public string GetDataType() { return dataType; }
        public string GetColor() { return color; }

        public void SetName(String name) { this.name = name; }
        public void SetDatatype(String datatype) { this.dataType = datatype; }

    }
}
