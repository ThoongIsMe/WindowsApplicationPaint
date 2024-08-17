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
    internal class ClsGroup : FillDraw
    {
        private List<clsDrawObject> _selectedObjects;

        public ClsGroup(List<clsDrawObject> selectedObjects)
        {
            _selectedObjects = selectedObjects;

        }

        public override void Draw(Graphics graphics)
        {
            foreach (clsDrawObject obj in _selectedObjects)
            {
                obj.Draw(graphics);
            }
        }

        public override bool HitTest(Point point)
        {
            foreach (clsDrawObject obj in _selectedObjects)
            {
                if (obj.HitTest(point))
                {
                    return true;
                }
            }
            return false;
        }
        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                foreach (clsDrawObject obj in _selectedObjects)
                {
                    path.AddPath(obj.GraphicsPath, false);
                }
                return path;
            }
        }
       
        

        public override void Move(int deltaX, int deltaY)
        {
            foreach (clsDrawObject obj in _selectedObjects)
            {
                obj.Move(deltaX, deltaY);
            }
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
            p2 = new Point(p2.X + deltaX, p2.Y + deltaY);
        }


    }
}
