using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using PQ.Multitouch;

namespace MTPiano
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void AppStartup(object sender, StartupEventArgs args)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();

            MultiTouch.Init(new ZeroParamHandler(ConnectFailed));
        }

        private void ConnectFailed()
        {
            if (MessageBox.Show("Warning: PQMultiTouch Server not running. Please start it and then Click Ok to reconnect the server, otherwise the program will run without the support of PQMultiTouch Server.", "Warning", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                MultiTouch.ReConnect();
        }
    }
}
