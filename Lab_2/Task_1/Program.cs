using System;
using System.Windows.Forms;
using AddressApp; 

namespace Task_1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new AddressApp.Form1()); 
        }
    }
}