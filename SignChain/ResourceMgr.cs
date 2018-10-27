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
        static private readonly string resMe = "me";     // Me
        static private readonly string resYou = "you";     // You
        static private readonly string resAttachText      = "file_attach_text";     // File Attach Text 
        static private readonly string resAttachIcon      = "file_attach_icon";     // File Attach Icon
        static private readonly string resAttachProgress  = "file_attach_progress"; // File Attach Progress
        static private readonly string resAttachProgress2 = "file_attach_progress2";          // File Attach Progress
        static private readonly string resUploadText      = "file_upload_text";     // File Upload Text
        static private readonly string resStatusBarT      = "status_bar_t";         // Global Status Bar Top
        static private readonly string resStatusBarB      = "status_bar_b";         // Global Status Bar Bottom
        static private readonly string resButtonNext      = "next_button";          // Global Next Button
        static private readonly string resButtonPriv      = "priv_button";          // Global Priv Button

        static public Image Me;
        static public Image You;
        static public Image statusBarT;
        static public Image statusBarB;
        static public Image attachIcon;
        static public Image attachText;
        static public Image attachProgress;
        static public Image attachProgress2;
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
                Me = new Bitmap(ResourceMgr.LoadImageFrom(resMe));
                You = new Bitmap(ResourceMgr.LoadImageFrom(resYou));
                attachIcon = new Bitmap(ResourceMgr.LoadImageFrom(resAttachIcon));
                attachText = new Bitmap(ResourceMgr.LoadImageFrom(resAttachText));
                attachProgress = new Bitmap(ResourceMgr.LoadImageFrom(resAttachProgress));
                attachProgress2 = new Bitmap(ResourceMgr.LoadImageFrom(resAttachProgress2));
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
