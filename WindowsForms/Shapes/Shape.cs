using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WindowsForms.Shapes
{
    [Serializable]
    public abstract class Shape
    {
        public Color LineColor { get; set; }
        public Color MainColor { get; set; }
        

        protected Shape()
        {
            LineColor = Color.Red;
            MainColor = Color.Orange;
        }

        protected Shape(Color lineColor, Color mainColor)
        {
            LineColor = lineColor;
            MainColor = mainColor;
        }

        public abstract GraphicsPath GetPath();

        public abstract void Draw(Graphics graphics);

        public abstract void Move(Point point);
    }
}
