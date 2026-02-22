using System;
using System.Windows.Forms;
using FigureCalculator; 

namespace Lab_3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}