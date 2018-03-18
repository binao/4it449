using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JC_HomeWork5
{
    static class Program
    {
        /// <summary>
        /// Main point for start of the program (Form1.Designer.cs unchange -> czech generate comments)
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
