using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SignChain
{
    public partial class LoadForm : Form
    {
        
        private UserForm templateForm;

        private Image formMessage;
        private float formMessageAlpha = 1;

        Point GetCenterPos(Size szBase, Size szOffs, int heightOffs)
        {
            Point newPoint = new Point();

            
            newPoint.X = (szBase.Width  / 2) - (szOffs.Width  / 2);
            newPoint.Y = (szBase.Height / 2) - (szOffs.Height / 2) + heightOffs;
            return newPoint;
        }

        Point GetPreviewPos(int index)
        {
            Point newPos = new Point();

            int hIndex = index / 3;
            int wIndex = index % 3;

            newPos.X = ((wIndex + 1) * 98) + (wIndex * 350);
            newPos.Y = ((hIndex + 1) * 80) + (hIndex * 300) + 120;
            return newPos;
        }
        
        public LoadForm()
        {
            InitializeComponent();
            this.DragDrop  += DragDropFile;
            this.DragEnter += DragEnterFile;
            this.DragLeave += DragLeaveFile;

            formMessage = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(formMessage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    pen.DashPattern = new float[] {2, 3, 2, 3};

                    // constant 200 and 400 is a padding for brush size.
                    g.DrawRectangle(
                        pen, 
                        200, 
                        200, 
                        formMessage.Width  - 400, 
                        formMessage.Height - 400);
                }

                g.DrawImage(ResourceMgr.attachText, GetCenterPos(Size, ResourceMgr.attachText.Size, -30));
                g.DrawImage(ResourceMgr.attachIcon, GetCenterPos(Size, ResourceMgr.attachIcon.Size, 30));
            }

            this.Refresh();
        }

        private void InitSignForm()
        {
            this.Hide();
            templateForm = new UserForm();
            templateForm.Show();
        }

        void RenderPreview(Graphics graphics)
        {
            Pen   previewP = new Pen(Color.FromArgb(196, 196, 196), 2);
            Brush previewB = new SolidBrush(Color.FromArgb(196, 196, 196));
            Font  previewF = new Font("10X10", 25, GraphicsUnit.Pixel);

            for (int i = 0; i < SignTemplate.globTemplate.Count; ++i)
            {
                string previewName     = SignTemplate.globTemplate[i].signImageName;
                Image  previewImage    = SignTemplate.globTemplate[i].signImagePreview;
                Point  previewPosition = GetPreviewPos(i);
                

                graphics.DrawImage(previewImage, previewPosition);

                graphics.DrawRectangle(
                    previewP,
                    previewPosition.X   + 1,
                    previewPosition.Y   + 1,
                    previewImage.Width  - 2,
                    previewImage.Height - 2);

                Rectangle nametagRect = new Rectangle();
                nametagRect.X      = previewPosition.X;
                nametagRect.Y      = previewPosition.Y + previewImage.Height;
                nametagRect.Width  = previewImage.Width;
                nametagRect.Height = 45;

                graphics.FillRectangle(previewB, nametagRect);

                Size nametagSize = TextRenderer.MeasureText(previewName, previewF);
                graphics.DrawString(
                    previewName, 
                    previewF,
                    Brushes.Black, 
                    new PointF(
                        nametagRect.X + (nametagRect.Width  / 2) - (nametagSize.Width  / 2), 
                        nametagRect.Y + (nametagRect.Height / 2) - (nametagSize.Height / 2)
                    ));
            }

            previewF.Dispose();
            previewP.Dispose();
            previewB.Dispose();
        }

        void RenderMessage(Graphics graphics)
        {
            // If its set as invisible.
            // just do not render it.
            if (formMessageAlpha != 0.00f)
            {
                Image message;
                if (formMessageAlpha != 1.00f)
                {
                    message = SetImageOpacity(formMessage, formMessageAlpha);
                }
                else
                {
                    message = new Bitmap(formMessage);
                }
                graphics.DrawImage(message, 0, 0);
                message.Dispose();
            }
        }

        void RenderBG(Graphics graphics)
        {
            // draw background.
            graphics.DrawImage(ResourceMgr.statusBarT, 0 , 0  );
            graphics.DrawImage(ResourceMgr.statusBarB, 0 , 965);
            graphics.DrawImage(ResourceMgr.uploadText, 69, 45 );
            graphics.DrawImage(ResourceMgr.attachProgress, 370, 21);
        }

        void RenderButtons(Graphics graphics)
        {
            graphics.DrawImage(ResourceMgr.privButton, 310, 910);
            graphics.DrawImage(ResourceMgr.nextButton, 790, 910);
        }

        private void LoadFormPaint(object sender, PaintEventArgs e)
        {
            using (Image tmpImage = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(tmpImage))
                {
                    RenderPreview(graphics);
                    RenderMessage(graphics);
                    RenderBG(graphics);
                    RenderButtons(graphics);
                }
                
                e.Graphics.DrawImage(tmpImage, 0, 0);
            }
        }

        SignTemplate.eFileExts? CheckExtension(string filename)
        {
            foreach (SignTemplate.eFileExts ext in Enum.GetValues(typeof(SignTemplate.eFileExts)))
            {
                // check file extensions.
                if (filename.EndsWith(SignTemplate.sFileExts[(UInt32) ext]))
                {
                    return ext;
                }
            }
            return null;
        }

        private void DragDropFile(object sender, DragEventArgs e)
        {
            foreach (string filename in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                SignTemplate.eFileExts? ext = CheckExtension(filename);

                if(ext == null)
                {
                    MessageBox.Show("알 수 없는 포멧의 파일입니다!\n" + filename, "오류!", MessageBoxButtons.OK);
                }

                SignTemplate.globTemplate.Add(new SignTemplate(filename, ext.Value));
            }

            formMessageAlpha = 0.00f;
            this.Refresh();
        }

        public Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap newBitmap = new Bitmap(image.Width, image.Height);

            using (Graphics graphics = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix();
                colorMatrix.Matrix33 = opacity;

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    graphics.DrawImage(
                        image,
                        new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                        0,
                        0,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel,
                        attributes);
                }
            }

            return newBitmap;
        }

        private void DragEnterFile(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Move;

            formMessageAlpha = 0.25f;
            this.Refresh();
        }

        private void DragLeaveFile(object sender, EventArgs e)
        {
            if (SignTemplate.globTemplate.Count == 0)
            {
                formMessageAlpha = 1.00f;
            }
            else
            {
                formMessageAlpha = 0.00f;
            }

            this.Refresh();
        }
    }
}
