using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Paint_21110929.clsDrawObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Paint_21110929
{
    public partial class Form1 : Form
    {

        private List<clsDrawObject> lstObject = new List<clsDrawObject>();
        List<clsDrawObject> groupShase = new List<clsDrawObject>();

        private clsDrawObject selectedObject;

        bool bLine = false;
        bool bRect = false;
        bool bSqua = false;
        bool bEcllipse = false;
        bool bCircle = false;
        bool bPoly = false;
        bool isPress = false;
        bool bfSqua = false;

        bool bPoly1 = false;
        bool bArc = false;
        bool isMD = false;
        bool IsSelected = false;
        bool isMove = false;
        bool isCtr = false;
        bool nohit = false;
        bool bfhcn = false;
        bool bftron = false;
        bool bfelip = false;
        bool bfpoly = false;

        private bool ctrlKeyPressed = false;
        private bool mouseDown = false;

        bool isSLGroup = false;

        int isMaxMin = 0;

        private bool isDragging = false;
        private Point startPoint;
        private PointF minD;
        private PointF maxD;


        public Form1()
        {
            InitializeComponent();
            cmbOutline.SelectedIndex = 0;
        }


        private void BtnLine_Click(object sender, EventArgs e)
        {
            this.bLine = true;
            this.bRect = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrlKeyPressed = true;
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrlKeyPressed = false;
            }
        }

        private void __btnGr()
        {
            List<clsDrawObject> selectedShapes = new List<clsDrawObject>(groupShase);
            selectedShapes.ForEach(shape => shape.Selected = false);

            if (selectedShapes.Count > 1)
            {
                ClsGroup groupShape = new ClsGroup(selectedShapes);
                lstObject = lstObject.Where(s => !selectedShapes.Contains(s)).Concat(new[] { groupShape }).ToList();
                pnMain.Invalidate();
            }

            lstObject.ForEach(shape => shape.Selected = false);
        }
        private void pnMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.isPress = true;
            if (ctrlKeyPressed)
                mouseDown = true;
            if (this.bLine == true)
            {
                clsDrawObject myObj = new clsLine();
                myObj.p1 = e.Location;
                myObj.Fill = false;
                myObj.Color = CLChinh.BackColor;
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;

            }
            if (this.bRect == true)
            {
                clsDrawObject myObj;
                myObj = new clsRectangl();
                myObj.p1 = e.Location;
                myObj.Fill = false;
                myObj.Color = CLChinh.BackColor;
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }
            if (this.bSqua == true)
            {
                clsDrawObject myObj;
                myObj = new clsSquare();
                myObj.p1 = e.Location;
                myObj.Fill = false;
                myObj.Color = CLChinh.BackColor;
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }
            if (this.bEcllipse == true)
            {
                clsDrawObject myObj;
                myObj = new clsEllipse();
                myObj.p1 = e.Location;
                myObj.Fill = false;
                myObj.Color = CLChinh.BackColor;
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }
            if (this.bCircle == true)
            {
                clsDrawObject myObj;
                myObj = new clsCircle();
                myObj.p1 = e.Location;
                myObj.Fill = false;
                myObj.Color = CLChinh.BackColor;
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }
            if (this.bPoly == true)
            {
                clsPolygon myObj = new clsPolygon();
                myObj.Color = CLChinh.BackColor;
                myObj.Fill = false;
                myObj.WidthLine = Linewidth.Value;
                myObj.ListPoint.Add(e.Location);
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.ListPoint.Add(e.Location);
                this.lstObject.Add(myObj);
                this.bPoly1 = true;            }
            if (this.bPoly1 == true)
            {
                clsPolygon p = lstObject[lstObject.Count - 1] as clsPolygon;
                p.ListPoint[p.ListPoint.Count - 1] = e.Location;
                p.ListPoint.Add(e.Location);
            }
            if (this.bArc == true)
            {
                clsDrawObject myObj;
                myObj = new clsArc();
                myObj.p1 = e.Location;
                myObj.Fill = false;
                myObj.Color = CLChinh.BackColor;
                myObj.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }

            if (this.bfSqua == true)
            {
                FillDraw myObj;
                myObj = new clsSquare();
                myObj.Fill = true;
                myObj.p1 = e.Location;
                
                myObj.ColorFill = CLChinh.BackColor;
                myObj.Color = CLChinh.BackColor;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }

            if (this.bftron == true)
            {
                FillDraw myObj;
                myObj = new clsCircle();
                myObj.Fill = true;
                myObj.p1 = e.Location;
                myObj.Color = CLChinh.BackColor;
                myObj.ColorFill = CLChinh.BackColor;

                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }
            if (this.bfelip == true)
            {
                FillDraw myObj;
                myObj = new clsEllipse();
                myObj.Fill = true;
                myObj.p1 = e.Location;
                myObj.Color = CLChinh.BackColor;
                myObj.ColorFill = CLChinh.BackColor;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }
            if (this.bfhcn == true)
            {
                FillDraw myObj;
                myObj = new clsRectangl();
                myObj.p1 = e.Location;
                myObj.Fill = true;
                myObj.Color = CLChinh.BackColor;
                myObj.ColorFill = CLChinh.BackColor;
                myObj.WidthLine = Linewidth.Value;
                this.lstObject.Add(myObj);
                isMD = true;
            }

            if (this.bfpoly == true)
            {
                clsPolygon myObj;
                myObj = new clsPolygon();
                myObj.Color = CLChinh.BackColor;
                myObj.Fill = true;
                myObj.WidthLine = Linewidth.Value;
                myObj.ListPoint.Add(e.Location);
                myObj.ColorFill = CLChinh.BackColor;
                myObj.ListPoint.Add(e.Location);
                this.lstObject.Add(myObj);
                myObj.Color = CLChinh.BackColor;
                this.bPoly1 = true;

            }
            if (this.bPoly1 == true)
            {

                clsPolygon p = lstObject[lstObject.Count - 1] as clsPolygon;
                p.ListPoint[p.ListPoint.Count - 1] = e.Location;
                p.ListPoint.Add(e.Location);
            }
            isMove = true;

            


            if (IsSelected == true)
            {
                bool isResizing = false; // cờ để cho biết nếu thay đổi kích thước xảy ra

                // Kiểm tra xem click chuột có xảy ra trong giới hạn của các vòng tròn nhỏ màu xanh không
                RectangleF minEllipseRect = new RectangleF(minD, new SizeF(12, 12));
                RectangleF maxEllipseRect = new RectangleF(new PointF(maxD.X - 12, maxD.Y - 12), new SizeF(12, 12));

                   


                if (minEllipseRect.Contains(e.Location))
                {
                    isResizing = true;
                    isMaxMin = 2; // diem tren
                }
                else if (maxEllipseRect.Contains(e.Location))
                {
                    isResizing = true;
                    isMaxMin = 1; // diem duoi
                }

                if (!isResizing)
                {
                   
                    foreach (clsDrawObject obj in lstObject)
                    {

                        if (obj.HitTest(e.Location))
                        {
                            selectedObject = obj;
                            startPoint = e.Location;
                           
                            if (IsObjectExist(obj) == false)
                            {
                                groupShase.Add(obj);                           
                            }

                            isDragging = true;
                            isMove = true;
                            nohit = false;
                            break;
                        }
                    }
                }
                else
                {
                    // Kích chuột nằm trong vòng tròn nhỏ màu xanh, cập nhật điểm bắt đầu

                    startPoint = e.Location;
                    isDragging = true;
                    isMove = false;
                    nohit = true;
                }
                
            }
            

        }


        //ckeck xem co ton tai tron list khong
        private bool IsObjectExist(clsDrawObject obj)
        {
            foreach (clsDrawObject o in groupShase)
            {
                if (o.Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }

        private void pnMain_MouseMove(object sender, MouseEventArgs e)
        {

      
            if (this.isPress == true && this.isMD==true)
            {
                if (this.lstObject.Count > 0) // Kiểm tra nếu đã chọn hình vẽ
                {
                    this.lstObject[this.lstObject.Count - 1].p2 = e.Location;
                    
                    this.pnMain.Invalidate();
                }
            }

            if (isDragging && selectedObject != null)
            {
                
                if (isMove == true) //di chuyen
                {
                    this.Cursor = Cursors.SizeAll;
                    int deltaX = e.X - startPoint.X;
                    int deltaY = e.Y - startPoint.Y;
                    selectedObject.Move(deltaX, deltaY);
                    startPoint = e.Location;
                    pnMain.Invalidate();
                   
                }
                   
                else if (nohit == true)
                {
                   if(isMaxMin==1)  //lay diem  p1 di chuyen
                    {
                        this.Cursor = Cursors.SizeNESW;
                        selectedObject.p2 = e.Location;
                        this.pnMain.Invalidate();
                    }
                    else if(isMaxMin ==2) //lay diem  p2 di chuyen
                    {
                        this.Cursor = Cursors.SizeNESW;
                        selectedObject.p1 = e.Location;
                        this.pnMain.Invalidate();
                    }
                    
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

        }

        //  Hàm xử lý sự kiện khi nhả chuột lên

        private void pnMain_MouseUp(object sender, MouseEventArgs e)
        {
            this.isPress = false;
            this.bPoly = false;
            this.bArc = false;
            this.bfpoly = false;
            this.isMove = false;
            this.nohit = false;
            this.isMD = false; 
            this.isDragging = false;
            if (mouseDown && ctrlKeyPressed)
            {
                __btnGr();
            }

            mouseDown = false;
            this.pnMain.Invalidate();
        }


        private void pnMain_Paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;
            
            for (int i = 0; i < this.lstObject.Count; i++)
            {   
               this.lstObject[i].Draw(g);
                
            }


            if (selectedObject is FillDraw fillDraw && IsSelected)
            {
                fillDraw.OnPaint(e);
                Rectangle bounds = new Rectangle(fillDraw.Location, fillDraw.Size);

                bounds.Inflate(Linewidth.Value / 2 + 3, Linewidth.Value / 2 + 3); //vien bang do rong livewidth chia 2 + 3
                using (Pen pen = new Pen(SystemColors.Highlight, 2) { DashStyle = DashStyle.Dash })
                {
                    e.Graphics.DrawRectangle(pen, bounds);
                }

                //cham tron xanh  thu nhat diem 1 zoom
                RectangleF minEllipseRect = new RectangleF(bounds.Location, new SizeF(12, 12));
                e.Graphics.FillEllipse(Brushes.Blue, minEllipseRect);

                //cham tron xanh thu2 diem thu 2 de zoom
                RectangleF maxEllipseRect = new RectangleF(new PointF(bounds.Right - 12, bounds.Bottom - 12), new SizeF(12, 12));
                e.Graphics.FillEllipse(Brushes.Blue, maxEllipseRect);
                minD = bounds.Location;
                maxD = new PointF(bounds.Right, bounds.Bottom);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnMain.Focus();
            
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            this.bRect = true;
            this.bLine = false ;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
            this.isSLGroup = false;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = true;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
        }

        private void btnElip_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = true;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = true;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
        }

        private void btnPol_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = true;
            //this.test = true;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
           this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
        }

      
        private void btnArc_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            //this.test = true;
            this.bPoly1 = false;
            this.bArc = true;
            this.bfSqua = false;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
        }
        
        private void btnFillElip_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            //this.test = true;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = true;
            this.bfpoly = false;
        }

        private void btnFillSquare_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            //this.test = true;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = true;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;

        

        }

        private void Linewidth_Scroll(object sender, EventArgs e)
        {
           
            if (IsSelected == true)
            {
                selectedObject.WidthLine = Linewidth.Value;               
                pnMain.Invalidate();
            }
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                CLChinh.BackColor = colorDialog1.Color;
            }
        }

        private void Red_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Red.BackColor;
        }
        private void Gray_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Gray.BackColor;
        }

        private void DarkRed_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = DarkRed.BackColor;
        }

        private void Orange_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Orange.BackColor;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Yellow.BackColor;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Green.BackColor;
        }

        private void Cyan_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Cyan.BackColor;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Blue.BackColor;
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Purple.BackColor;
        }

        private void Gr_Click(object sender, EventArgs e)
        {
            CLChinh.BackColor = Green.BackColor;
        }

        private void LightGray_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = LightGray.BackColor;
        }

        private void LightCoral_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = LightCoral.BackColor;
        }

        private void Gold_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = Gold.BackColor;
        }

        private void Black_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = Black.BackColor;
        }

        private void YellowGreen_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = YellowGreen.BackColor;
        }

        private void LigthBlue_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = LigthBlue.BackColor;
        }

        private void Teal_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = Teal.BackColor;
        }

        private void DarkKhaki_Click(object sender, EventArgs e)
        {

            CLChinh.BackColor = DarkKhaki.BackColor;
        }


        private void cmbOutline_SelectedIndexChanged(object sender, EventArgs e)
        {
                
            foreach (clsDrawObject shape in lstObject)
            {
               
                if (shape.Selected)
                {
                    if (!shape.Fill)
                        shape.DashStyle = (DashStyle)cmbOutline.SelectedIndex;
                }    

            }
            pnMain.Invalidate();
        }

        private void btnFillHcn_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.IsSelected = false;
            this.isSLGroup = false;
            this.bfhcn = true;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
        }
       
        private void btnFillTron_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.isSLGroup = false;
            this.bfhcn = false;
            this.bftron = true;
            this.bfelip = false;
            this.bfpoly = false;
            this.IsSelected = false;
 
        }
        private void btnFillPoLy_Click(object sender, EventArgs e)
        {
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = true;
            this.IsSelected = false;
            this.isSLGroup = false;
        }
        private void bntSel_Click(object sender, EventArgs e)
        {
            this.IsSelected = true;
            this.bRect = false;
            this.bLine = false;
            this.bSqua = false;
            this.bEcllipse = false;
            this.bCircle = false;
            this.bPoly = false;
            this.bPoly1 = false;
            this.bArc = false;
            this.bfSqua = false;
            this.bfhcn = false;
            this.bftron = false;
            this.bfelip = false;
            this.bfpoly = false;
            this.isSLGroup = false;
            groupShase.Clear();

        }

        private void fillColer_Click(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {

                if (selectedObject is FillDraw)
                {
                    FillDraw fillObject = (FillDraw)selectedObject;
                    fillObject.Color = CLChinh.BackColor;
                    fillObject.ColorFill = CLChinh.BackColor;
                }
                else
                {
                    selectedObject.Color = CLChinh.BackColor;
                }
                pnMain.Invalidate();
            }
        }

        private void penci_Click(object sender, EventArgs e)
        {

        }

        private void btnGr_Click(object sender, EventArgs e)
        {
            isSLGroup = true;

            List<clsDrawObject> selectedShapes = new List<clsDrawObject>(groupShase);
            selectedShapes.ForEach(shape => shape.Selected = false);

            if (selectedShapes.Count > 1)
            {
                ClsGroup groupShape = new ClsGroup(selectedShapes);
                lstObject = lstObject.Where(s => !selectedShapes.Contains(s)).Concat(new[] { groupShape }).ToList();
                pnMain.Invalidate();
            }

            lstObject.ForEach(shape => shape.Selected = false);
        }

        private void CLChinh_Click(object sender, EventArgs e)
        {

        }
    }

}

