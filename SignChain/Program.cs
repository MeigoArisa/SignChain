using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignChain
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            SignChain.ResourceMgr.InitializeResource();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoadForm());
        }
    }
}
