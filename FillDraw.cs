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
    internal abstract class FillDraw : clsDrawObject
    {
        public Color ColorFill; 
       

        public override void DrawFillBrush(Graphics graphics, GraphicsPath path)
        {
            using (SolidBrush brush = new SolidBrush(ColorFill))
            {
                graphics.FillPath(brush, path);
            }

        }
        public virtual void OnPaint(PaintEventArgs e) { } /// hàm tìm ra vi tri của các hình để vẽ hình chữ nhât bao quanh
        public Point Location { get; set; }
        public Size Size { get; set; }

      


    }
}
