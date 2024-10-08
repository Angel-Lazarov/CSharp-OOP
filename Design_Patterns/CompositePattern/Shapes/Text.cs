﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Shapes
{
    public class Text : Shape
    {
        public Text(Position position, string txt) : base(position)
        {
            Txt = txt;
        }

        public string Txt { get; set; }

        public override void Draw()
        {
            base.Draw();

            SetCursorPosition();

            Console.Write(Txt);
        }
    }
}
