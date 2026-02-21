using System;
using System.Windows.Forms;
using ShapesApp; 

namespace Task_1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new ShapesApp.Form1()); 
        }
    }
}