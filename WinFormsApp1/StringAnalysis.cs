using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class StringAnalysis
    {
        String[] lst;
        ListVariable variables = new ListVariable();
        NameFunction nameFunction = new NameFunction("");


        public NameFunction GetNameFunction()
        {
            return nameFunction;
        }

        public ListVariable GetVariables()
        {
            return variables;
        }
        public String[] GetString()
        {
            return lst;
        }

        public StringAnalysis(String[] lst1)
        {
            lst = new String[lst1.Length];
            lst1.CopyTo(lst,0);
        }

        public void SetStringLST(String[] result) 
        {
            lst.CopyTo(result,0);
        }

        public void EncoderInputFirst(string temp)
        {
            string[] split = temp.Split('(');
            nameFunction.SetName(split[0]);
            string[] split2 = split[1].Split(')');
            string[] split3 = split2[0].Split(',');
            foreach(string s in split3)
            {
                string[] split4 = s.Split(':');
                Variable newTemp = new Variable(split4[0], split4[1]);
                variables.PushNewVariable(newTemp);
            }

            string[] splitResult = split2[1].Split(':');
            Variable newResult = new Variable(splitResult[0], splitResult[1]);
            
        }

    }
}
