using System;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace SignChain
{
    public class ResourceMgr
    {
        // Resource Context Keys
        // those are keys for contract on SignChain.Resource to get
        // resources from it.
        static private readonly string resAttachText     = "file_attach_text";     // File Attach Text 
        static private readonly string resAttachIcon     = "file_attach_icon";     // File Attach Icon
        static private readonly String resAttachProgress = "file_attach_progress"; // File Attach Progress
        static private readonly string resUploadText     = "file_upload_text";     // File Upload Text
        static private readonly string resStatusBarT     = "status_bar_t";         // Global Status Bar Top
        static private readonly string resStatusBarB     = "status_bar_b";         // Global Status Bar Bottom
        static private readonly string resButtonNext     = "next_button";          // Global Next Button
        static private readonly string resButtonPriv     = "priv_button";          // Global Priv Button

        
        static public Image statusBarT;
        static public Image statusBarB;
        static public Image attachIcon;
        static public Image attachText;
        static public Image attachProgress;
        static public Image uploadText;
        static public Image nextButton;
        static public Image privButton;

        public static Image LoadImageFrom(string key)
        {
            Image resourceImage;

            ResourceManager resManager = SignChain.Resource.Properties.Resources.ResourceManager;
            using (var stream = new MemoryStream((byte[])resManager.GetObject(key)))
            {
                resourceImage = Image.FromStream(stream);
            }

            return resourceImage;
        }

        public static void InitializeResource()
        {
            try
            {
                attachIcon = new Bitmap(ResourceMgr.LoadImageFrom(resAttachIcon));
                attachText = new Bitmap(ResourceMgr.LoadImageFrom(resAttachText));
                attachProgress = new Bitmap(ResourceMgr.LoadImageFrom(resAttachProgress));
                uploadText = new Bitmap(ResourceMgr.LoadImageFrom(resUploadText));


                statusBarT = new Bitmap(ResourceMgr.LoadImageFrom(resStatusBarT));
                statusBarB = new Bitmap(ResourceMgr.LoadImageFrom(resStatusBarB));

                nextButton = new Bitmap(ResourceMgr.LoadImageFrom(resButtonNext));
                privButton = new Bitmap(ResourceMgr.LoadImageFrom(resButtonPriv));
            }
            catch (Exception)
            {
                MessageBox.Show(@"리소스를 로드하는 동안 오류가 발생하였습니다!", "@오류!", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
    }
}
