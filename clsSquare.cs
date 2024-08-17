using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_21110929
{
    internal class clsSquare : FillDraw
    {

        public override GraphicsPath GraphicsPath
        {
            get
            {
                int squareSize = Math.Abs(Math.Min(p1.X, p1.Y) - Math.Min(p2.X, p2.Y));
                int squareX = Math.Min(p1.X, p2.X);
                int squareY = Math.Min(p1.Y, p2.Y);

                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(squareX, squareY, squareSize, squareSize));

                return path;
            }
        }
        public override void OnPaint(PaintEventArgs e)
        {
            Location = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            Size = new Size(Math.Abs(Math.Min(p1.X, p1.Y) - Math.Min(p2.X, p2.Y)), Math.Abs(Math.Min(p1.X, p1.Y) - Math.Min(p2.X, p2.Y)));

        }
        public override bool HitTest(Point point)
        {
            GraphicsPath path = GraphicsPath;
            if (Fill)
            {
                using (Region region = new Region(path))
                {
                    if (region.IsVisible(point))
                        return true;
                }
            }
            else
            {
                using (Pen pen = new Pen(Color, WidthLine + 2))
                {
                    if (path.IsOutlineVisible(point, pen))
                        return true;
                }
            }

            int left = Location.X;
            int top = Location.Y;
            int right = left + Size.Width;
            int bottom = top + Size.Height;

            // Check if the point is within those coordinates
            if (point.X >= left && point.X <= right && point.Y >= top && point.Y <= bottom)
                return true;

            return false;
            
        }
        public override void Draw(Graphics graphics)
        {
            using (GraphicsPath path = GraphicsPath)

            {
                if (!Fill)
                {
                    using (Pen pen = new Pen(Color, WidthLine) { DashStyle = DashStyle })
                    {
                        graphics.DrawPath(pen, path);
                    }

                }
                else
                {
                    DrawFillBrush(graphics, path);
                }

            }
        }
        public override void Move(int deltaX, int deltaY)
        {
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
            p2 = new Point(p2.X + deltaX, p2.Y + deltaY);
        }
    }
}
