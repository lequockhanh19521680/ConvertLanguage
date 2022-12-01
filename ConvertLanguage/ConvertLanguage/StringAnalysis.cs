using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertLanguage
{
    internal class StringAnalysis
    {

        private ListVariable variables = new ListVariable();
        private NameFunction nameFunction = new NameFunction("");
        private Pre pre = new Pre("");
        private Post post = new Post("");

        public NameFunction GetNameFunction()
        {
            return nameFunction;
        }

        public ListVariable GetVariables()
        {
            return variables;
        }


        public StringAnalysis()
        {

        }



        public void EncoderInputFirst(string[] temp)
        {
            string[] split = temp[0].Split('(');
            nameFunction.SetName(split[0]);
            string[] split2 = split[1].Split(')');
            string[] split3 = split2[0].Split(',');
            foreach (string s in split3)
            {
                string[] split4 = s.Split(':');
                Variable newTemp = new Variable(split4[0], split4[1]);
                variables.PushNewVariable(newTemp);
            }

            string[] splitResult = split2[1].Split(':');
            variables.SetResult(splitResult[0], splitResult[1]);
            //
            string[] splitPre = temp[1].Split(new string[] { "pre" }, StringSplitOptions.None);

            pre.SetName(splitPre[1]);

            string set = "";
            for (int i = 2; i < temp.Length; i++)
            {
                set += temp[i];
            }

            string[] splitPost = set.Split(new string[] { "post" }, StringSplitOptions.None);
            post.SetName(splitPost[1].ToLower());
        }
        public Pre GetPre() { return pre; }
        public Post GetPost() { return post; }
        public void Clear()
        {
            variables = new ListVariable();
            nameFunction = new NameFunction("");
        }
    }
}
