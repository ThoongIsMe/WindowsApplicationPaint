using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Paint_21110929
{
    internal class clsLine: FillDraw
    {

        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(p1, p2);
                return path;
            }
        }
        public override void OnPaint(PaintEventArgs e)
        {
            
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p2.X - p1.X);
            int height = Math.Abs(p2.Y - p1.Y);

            Location = new Point(x, y);
            Size = new Size(width, height);
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
            using (GraphicsPath gr = GraphicsPath)
            {
                if (!Fill)
                {
                    using (Pen pen = new Pen(Color, WidthLine) { DashStyle = DashStyle })
                    {
                        graphics.DrawPath(pen, gr);
                    }
                }
                else
                {
                    DrawFillBrush(graphics, gr);
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
