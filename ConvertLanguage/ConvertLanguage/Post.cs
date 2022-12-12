using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertLanguage
{
    internal class Post : Text
    {

        public Post(string name1) : base(name1)
        {
        }

        public bool IsPostLoop()
        {
            return !(name.Contains("vmith"));
        }
        public bool IsPostReturn()
        {
            return !(name.Contains("&&"));
        }

        public string AnalysisPostNotReturn(string input,string x)
        {
            string[] save = input.Split(new string[] { "&&" }, StringSplitOptions.None);
            string condition = save[0];
            string process = save[1];
            string maybe = "";
            
            foreach(string a in save)
            {
                if(a==condition) { }
                else if (a==process) { }
                else
                {
                    maybe = maybe +"&&"+ a;
                }
            }
            if (condition.Contains(x))
            {
                string temp = condition;
                condition = process;
                process = temp;
            }
         
            condition = condition.Replace("((", "(");
            condition = condition.Replace("))", ")");
            condition = condition.Replace("=", "==");
            condition = condition.Replace("!==", "!=");
            condition = condition.Replace(">==", ">=");
            condition = condition.Replace("<==", "<=");

            maybe = maybe.Replace("=", "==");
            maybe = maybe.Replace("!==", "!=");
            maybe = maybe.Replace(">==", ">=");
            maybe = maybe.Replace("<==", "<=");

            process = process.Replace("((", "(");
            process = process.Replace("))", ")");
            process = process.Replace("(", "");
            process = process.Replace(")", "");
            string result = "";
            if (maybe != "")
            {
                result = "("+ condition + maybe + "\n" + "                " + process + ";" + "\n";
            }
            else
            {
                result = condition + "\n" + "                " + process + ";" + "\n";

            }

            return result;
        }
        public override string GetColor() { return "Purple"; }

    }
}
