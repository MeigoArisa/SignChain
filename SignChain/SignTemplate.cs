using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SignChain
{
    public class SignTemplate
    {
        public enum eFileExts
        {
            JPG, PNG, PDF
        };

        public static readonly string[] sFileExts =
        {
            ".jpg", ".png", ".pdf"
        };

        public string          signImageName;
        public Image           signImage;
        public Image           signImagePreview;
        public List<Rectangle> signArea = new List<Rectangle>();

        public SignTemplate(string filename, eFileExts ext)
        {
            try
            {
                if (ext == eFileExts.JPG || ext == eFileExts.PNG)
                {
                    // Get image file from bitmap.
                    signImage = Image.FromFile(filename);
                }
                else // ext == eFileExts.PDF
                {
                    // TODO : implements for PDFs
                }
            }
            catch (Exception e)
            {
                // something is wrong with us!!
                // Try again?
            }

            signImageName    = Path.GetFileName(filename);
            signImagePreview = new Bitmap(signImage, new Size(350, 300));
        }

        void AddArea(Rectangle area)
        {
            signArea.Add(area);
        }

        static public List<SignTemplate> globTemplate = new List<SignTemplate>();
    }
}
