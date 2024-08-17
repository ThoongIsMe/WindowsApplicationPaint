using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;


namespace Paint_21110929
{
    internal class clsArc: FillDraw
    {
        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                int rectWidth = Math.Abs(p2.X - p1.X);
                int rectHeight = Math.Abs(p2.Y - p1.Y);
                if (rectWidth > 0 && rectHeight > 0)
                {
                    Rectangle rect = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), rectWidth, rectHeight);
                    path.AddArc(rect, 5, 120);
                }
                return path;
            }
        }
        public override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = GraphicsPath;
            RectangleF bounds = path.GetBounds();
            Location = new Point((int)bounds.X, (int)bounds.Y);
            Size = new Size((int)bounds.Width, (int)bounds.Height);
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
