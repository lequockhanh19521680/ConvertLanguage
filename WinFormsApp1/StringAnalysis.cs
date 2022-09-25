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
        ListVariable variable;
        NameFunction nameFunction;
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

        public void EncoderInput(string[] temp)
        {
            
        }

    }
}
