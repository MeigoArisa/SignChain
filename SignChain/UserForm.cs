using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignChain
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            listView1.OwnerDraw = true;
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

        }
        private void UserFormLoad(object sender, EventArgs e)
        {
 
        }

        private void exListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void exListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void RenderBG(Graphics graphics)
        {
            graphics.DrawImage(ResourceMgr.statusBarT, 0 , 0  );
            graphics.DrawImage(ResourceMgr.statusBarB, 0 , 965);
            graphics.DrawImage(ResourceMgr.uploadText, 69, 45 );
            graphics.DrawImage(ResourceMgr.attachProgress2, 370, 21);
        }

        void RenderUser(Graphics graphics)
        {
            Image nameicon = Image.FromFile("./Vector.png");
            Image phoneicon = Image.FromFile("./phone.png");
            Image mail = Image.FromFile("./mail.png");
            Pen previewP = new Pen(Color.FromArgb(196, 196, 196), 2);
            Brush previewB = new SolidBrush(Color.FromArgb(196, 196, 196));
            Font previewF = new Font("10X10", 25, GraphicsUnit.Pixel);
            graphics.DrawRectangle(previewP,
                    337,
                    223,
                    800,
                    250);
            graphics.DrawImage(ResourceMgr.Me,new Point(1031,241));
            graphics.DrawImage(nameicon,new Rectangle(426,250,32,30));
            graphics.DrawImage(phoneicon, new Rectangle(426, 315,25,40));
            graphics.DrawImage(mail, new Rectangle(426, 392,32,30));
            graphics.DrawLine(previewP,new Point(413,290), new Point(713,290));
            graphics.DrawLine(previewP, new Point(413, 363), new Point(853, 363));
            graphics.DrawLine(previewP, new Point(413, 436), new Point(853, 436));


            graphics.DrawRectangle(previewP,
                    337,
                    511,
                    800,
                    250);
            graphics.DrawImage(ResourceMgr.You, new Point(971,521));
            graphics.DrawImage(nameicon, new Rectangle(426, 538, 32, 30));
            graphics.DrawImage(phoneicon, new Rectangle(426, 603, 25, 40));
            graphics.DrawImage(mail, new Rectangle(426, 680, 32, 30));
            graphics.DrawLine(previewP, new Point(413, 578), new Point(713, 578));
            graphics.DrawLine(previewP, new Point(413, 651), new Point(853, 651));
            graphics.DrawLine(previewP, new Point(413, 724), new Point(853, 724));
        }

        void RenderButtons(Graphics graphics)
        {
            graphics.DrawImage(ResourceMgr.privButton, 310, 910);
            graphics.DrawImage(ResourceMgr.nextButton, 790, 910);

        }

        private void UserFormPaint(object sender, PaintEventArgs e)
        {
            using (Image tmpImage = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(tmpImage))
                {
                    RenderUser(graphics);
                    RenderBG(graphics);
                    RenderButtons(graphics);
                }
                
                e.Graphics.DrawImage(tmpImage, 0, 0);
            }
        }
    }
}
