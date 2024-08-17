using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Paint_21110929
{
    internal abstract class clsDrawObject
    {
  
        public Point p1 { get; set; } ///Diem dau tien
        public Point p2 { get; set; }  //Diem thứ hai
        public int WidthLine { get; set; }   // Độ rông nét vẽ của pen
        public bool Selected { get; set; }  // cờ vật được chon
        public Color Color { get; set; } // màu
      
        public bool Fill { get; set; }  // cờ xem vật được  tô màu hay khôn

        public DashStyle DashStyle { get; set; } = DashStyle.Solid; // các kiểu vẽ paint

        public abstract void Draw(Graphics graphics); // hàm vẽ


        public abstract bool HitTest(Point point); // hàm kiem tra xem vật có được chọn hay khong

        public abstract GraphicsPath GraphicsPath { get; } // hàm thuộc tính truy cập vào đối tượng GraphicsPath

        public virtual void DrawFillBrush(Graphics graphics, GraphicsPath path) { }  // hàm tô màu
       
        public abstract void Move(int deltaX, int deltaY); // hàm để di chuyển

    }
}
