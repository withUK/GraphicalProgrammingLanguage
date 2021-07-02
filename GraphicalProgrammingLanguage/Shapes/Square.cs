﻿using System.Collections.Generic;
using System.Drawing;

namespace GraphicalProgrammingLanguage.Shapes
{
    class Square : Shape
    {
        // Properties
        public int length { get; set; }
        private bool lengthSet { get; set; }

        // Constructors
        public Square() : base()
        {

        }

        public Square(MainGUI main) : base(main)
        {

        }

        public Square(int x, int y, int length, Color lineColor, Color fillColor, float lineWeight) : base(x, y, lineColor, fillColor, lineWeight)
        {
            this.length = length;
        }

        // Methods


        // Abstracts
        public override double calculateArea()
        {
            return length * length;
        }

        public override double calculatePerimeter()
        {
            return length * 4;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(lineColor, lineWeight);
            SolidBrush b = new SolidBrush(fillColor);
            g.FillRectangle(b, x, y, length, length);
            g.DrawRectangle(p, x, y, length, length);
        }

        public override bool hasRequiredVariables()
        {
            return lengthSet;
        }

        // Overrides
        public override void set(Dictionary<string, string> variables)
        {
            this.x = int.Parse(variables.GetValueOrDefault("x"));
            this.y = int.Parse(variables.GetValueOrDefault("y"));
            this.length = int.Parse(variables.GetValueOrDefault("length"));
            this.lineWeight = float.Parse(variables.GetValueOrDefault("lineWeight"));
            this.lineColor = Color.FromName(variables.GetValueOrDefault("lineColor"));
            this.fillColor = Color.FromName(variables.GetValueOrDefault("fillColor"));
        }

        // This overrides the base implemention of ToString() in this case this is now the Shape class.
        // Example output: 'StringRef 1, 2 : 3'
        public override string ToString()
        {
            return base.ToString() + this.length;
        }
    }
}
