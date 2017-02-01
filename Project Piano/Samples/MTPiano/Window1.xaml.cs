using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media.Animation;

using System.Diagnostics;

using PQ.Multitouch;
using PQ.Multitouch.Controls;

namespace MTPiano
{
    /// <summary>
    /// Main Window
    /// </summary>
    public partial class Window1:ITableWindow
    {

        #region Initialization
        public Window1()
        {
            this.InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MultiTouch.EnableGesture(keyboard, new ZoomGesture(), new ZoomHandler(OnZoom));
            this.AddHandler(TouchEvent.TouchDoubleClickEvent, new TouchHandler(OnTouchDoubleClick));
        }

        private void OnZoom(object sender, ZoomEventArgs e)
        {
            Matrix m = keyboard.RenderTransform.Value;
            m.Scale(e.DeltaScale, e.DeltaScale);
            keyboard.RenderTransform = new MatrixTransform(m);
        }

        private void OnTouchDoubleClick(object sender, TouchEventArgs e)
        {
            keyboard.RenderTransform = new MatrixTransform(new Matrix());
        }

        #endregion
    }
}