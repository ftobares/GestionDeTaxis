using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop
{
   
    static class Program
    {
        //public static Login.Login log;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Form1 form = new Form1();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //log = new GestorDeFlotasDesktop.Login.Login();
            Application.Run(new GestorDeFlotasDesktop.Login.Login());
        }
    }
}
