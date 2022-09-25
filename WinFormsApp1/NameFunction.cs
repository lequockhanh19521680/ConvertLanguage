using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class NameFunction
    {
        string name;
        string color;

        public NameFunction(string name)
        {
            this.name = name;
            color = "#8EC63D";
        }

        public string GetName() { return name; }
        public string GetColor() { return color; }
        public void SetName(String name) { this.name = name; }

    }
}
