﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Post : Text
    {
        public Post(string name1) : base(name1)
        {
        }

        public override string GetColor() { return "Purple"; }

    }
}
