using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Shapes
{
    [Serializable]
    public class Triangle :Shape
    {
        public Guid NameGuid { get; }

        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public Point ThirdPoint { get; set; }

        public double Perimeter { get; set; }

        public Triangle()
        {
            NameGuid = new Guid();
            Perimeter = GetLength(FirstPoint, SecondPoint) + GetLength(SecondPoint, ThirdPoint) + GetLength(ThirdPoint, FirstPoint);
        }
        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
        }

        private static double GetLength(Point firstPoint, Point lastPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.X - lastPoint.X, 2) + Math.Pow(firstPoint.Y - lastPoint.Y, 2));
        }


        public override GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddLine(FirstPoint, SecondPoint);
            path.AddLine(SecondPoint, ThirdPoint);
            path.AddLine(ThirdPoint, FirstPoint);
            return path;
        }

        public override void Draw(Graphics graphics)
        {
            using (var path = GetPath())
            {
                using (var brush = new SolidBrush(LineColor))
                {
                    graphics.FillPath(brush, path);
                }
            }
        }

        public override void Move(Point point)
        {
            FirstPoint = new Point(FirstPoint.X + point.X, FirstPoint.Y + point.Y);
            SecondPoint = new Point(SecondPoint.X + point.X, SecondPoint.Y + point.Y);
            ThirdPoint = new Point(ThirdPoint.X + point.X, ThirdPoint.Y + point.Y);
        }
    }
}
