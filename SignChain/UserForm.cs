using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Controls.Add(textBox1);
        }

        private void UserFormLoad(object sender, EventArgs e)
        {

        }

        void RenderBG(Graphics graphics)
        {
            // draw background.
            graphics.DrawImage(ResourceMgr.statusBarT, 0 , 0  );
            graphics.DrawImage(ResourceMgr.statusBarB, 0 , 965);
            graphics.DrawImage(ResourceMgr.uploadText, 69, 45 );
            graphics.DrawImage(ResourceMgr.attachProgress, 370, 21);
        }

        void RenderUser(Graphics graphics)
        {
            Pen previewP = new Pen(Color.FromArgb(196, 196, 196), 2);
            Brush previewB = new SolidBrush(Color.FromArgb(196, 196, 196));
            Font previewF = new Font("10X10", 25, GraphicsUnit.Pixel);

            graphics.FillRectangle(previewB ,new Rectangle(337, 223, 800, 250));
            graphics.FillRectangle(previewB, new Rectangle(337, 511, 800, 250));
            graphics.FillRectangle(previewB, new Rectangle(337, 799, 800, 250));
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
