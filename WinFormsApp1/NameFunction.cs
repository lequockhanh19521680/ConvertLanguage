﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class NameFunction : Text
    {

        public NameFunction(string name) : base(name)
        {
        }

        public override string GetColor() { return "Green"; }
    }
}
