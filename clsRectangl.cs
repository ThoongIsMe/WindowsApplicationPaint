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
    internal class clsRectangl : FillDraw
    {

        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(
                    Math.Min(p1.X, p2.X),
                    Math.Min(p1.Y, p2.Y),
                    Math.Abs(p1.X - p2.X),
                    Math.Abs(p1.Y - p2.Y));
                path.AddRectangle(rect);
                return path;

            }
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
            Rectangle rect = new Rectangle(Location, Size);
            if (rect.Contains(point))
                return true;

            return false;
        }
        public override void OnPaint(PaintEventArgs e)
        {
            Location = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            Size = new Size(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));

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
