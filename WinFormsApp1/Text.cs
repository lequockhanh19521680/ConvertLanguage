using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
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
            name1 = name1.Replace(" ", "");

            this.name = name1;
        }
    }
}
