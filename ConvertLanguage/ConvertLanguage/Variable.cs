using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertLanguage
{
    internal class Variable : Text
    {
        string dataType;
        string dataTypeInArray;
        bool isArray;
        public Variable(string name1, string dataType) : base(name1)
        {
            dataTypeInArray = "";
            SetDatatype(dataType);
            this.dataType = dataType;
            isArray = false;
            if(dataType.Contains('*')) { 
                isArray = true;
                dataTypeInArray = dataType.Split('*')[0];
            }
        }
        public string GetDataTypeInArray() { return dataTypeInArray; }
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
                    dataTypeInArray = "float";
                    return "float[]";
                case "char*":
                    dataTypeInArray = "char";
                    return "string";
                case "N*":
                    dataTypeInArray = "uint";
                    return "uint";
                case "Z*":
                    dataTypeInArray = "int";
                    return "int";
                default:
                    return "";
            }
        }

        public string InitVariable(string type)
        {
            switch (type)
            {
                case "R":
                    return " = 0";
                case "N":
                    return " = 0";
                case "Z":
                    return " = 0";
                case "B":
                    return " = false";
                case "char*":
                    return " = \"\"";
                
                default: return "";
            }
        }

        public bool GetIsArray() { return isArray; }
        public string GetDataType() { return dataType.Trim(); }
        public override string GetColor() { return "Red"; }
        public string GetColorDataType() { return "Blue"; }

        public void SetIsArray(bool b) { isArray = b; }

        public void SetDatatype(String datatype1)
        {

            this.dataType = datatype1.Trim();

        }

    }
}
