using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

namespace tfinal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>C:\Users\Paulo Carvalho\documents\visual studio 2010\Projects\trabalhofinal\trabalhofinal\Program.cs
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception)
            {
                Main();
            }
        }
    }
}
