﻿using GraphicalProgrammingLanguage.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage.Commands
{
    class Clear : Command
    {
        // Constructors
        public Clear(MainGUI main) : base(main)
        {
            this.main = main;
            this.name = CommandTypes.clear.ToString();
        }

        // Overrides
        public override void execute()
        {
            log(main);
            main.dc.Clear(Color.Gainsboro);
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }
    }
}