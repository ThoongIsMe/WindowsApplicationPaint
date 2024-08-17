using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace Paint_21110929
{
    internal class clsCircle:FillDraw
    {

        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                Point center = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                int radius = (int)(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2);
                path.AddEllipse(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                return path;

            }
        }
        public override void OnPaint(PaintEventArgs e)
        {
            int diameter = (int)(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2)*2;
            int x = (p1.X + p2.X) / 2 - diameter / 2;
            int y = (p1.Y + p2.Y) / 2 - diameter / 2;
            Location = new Point(x, y);
            Size = new Size(diameter, diameter);
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
            double radius = Size.Width / 2;
            Point center = new Point(Location.X + Size.Width / 2, Location.Y + Size.Height / 2);
            double distance = Math.Sqrt(Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2));
            if (distance <= radius)
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
