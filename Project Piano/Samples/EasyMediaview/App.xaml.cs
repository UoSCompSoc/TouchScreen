﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using PQ.Multitouch;

namespace EasyMediaview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();

            MultiTouch.Init(new ZeroParamHandler(OnConnectedFailed));
        }


        private void OnConnectedFailed()
        {
            if (MessageBox.Show("Warning: PQMultiTouch Server not running. Please start it and then Click Ok to reconnect the server, otherwise the program will run without the support of PQMultiTouch Server.", "Warning", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                MultiTouch.ReConnect();
        }
    }
}
