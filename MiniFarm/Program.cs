﻿using System;
using System.Windows.Forms;

namespace MiniFarm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            // Gọi GameManager khởi động game
            GameManager.Instance.Start();
        }
    }
}
