using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
{
    internal class Variable : Text
    {
        string dataType;
        bool isArray;
        public Variable(string name1, string dataType) : base(name1)
        {
            SetDatatype(dataType);
            this.dataType = dataType;
            isArray = false;
        }

        public string GetRealDataType(string type)
        {
            switch (type)
            {
                case "R":
                    return "float";
                case "N":
                    return "uint";
                case "Z":
                    return "int";
                case "B":
                    return "bool";
                case "R*":
                    SetIsArray(true);
                    return "float[]";
                default:
                    return "";
            }
        }

        public bool GetIsArray() { return isArray; }
        public string GetDataType() { return dataType.Trim(); }
        public override string GetColor() { return "Red"; }
        public string GetColorDataType() { return "Blue"; }

        public void SetIsArray(bool b) { isArray = b; }

        public void SetDatatype(String datatype1) {

            this.dataType = datatype1.Trim();

        }

    }
}
