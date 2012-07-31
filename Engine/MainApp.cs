using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Engine
{
    static class MainApp
    {
        [MTAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
