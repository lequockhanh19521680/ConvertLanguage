using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertLanguage
{
    abstract class Text
    {
        protected string name;

        public Text(string name1)
        {

            name1 = name1.Replace(" ", "");

            this.name = name1;
        }

        public string GetName() { return name; }
        public virtual string GetColor() { return ""; }
        public void SetName(String name1)
        {
            while (isThereSpace(name1))
            {
                name1 = name1.Replace(" ", "");
            }
            string name2 = name1.Trim();
            this.name = name2;
        }

        protected bool isThereSpace(String s)
        {
            return s.Contains(" ");
        }
    }
}
