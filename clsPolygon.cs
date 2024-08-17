using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_21110929
{
    
    internal class clsPolygon : FillDraw
    {
        public List<Point> ListPoint { get; set; } = new List<Point>();
        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (ListPoint.Count <= 2)
                    path.AddLine(ListPoint[0], ListPoint[1]);
                else
                    path.AddPolygon(ListPoint.ToArray());
                return path;
            }
        }
        public override void OnPaint(PaintEventArgs e)
        {
            
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            foreach (Point p in ListPoint)
            {
                if (p.X < minX)
                    minX = p.X;
                if (p.Y < minY)
                    minY = p.Y;
                if (p.X > maxX)
                    maxX = p.X;
                if (p.Y > maxY)
                    maxY = p.Y;
            }
            Location = new Point(minX, minY);
            Size = new Size(maxX - minX, maxY - minY);
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
            for (int i = 0; i < ListPoint.Count; i++)
            {
                Point newPoint = new Point(ListPoint[i].X + deltaX, ListPoint[i].Y + deltaY);
                ListPoint[i] = newPoint;
            }
        }
    }
}
