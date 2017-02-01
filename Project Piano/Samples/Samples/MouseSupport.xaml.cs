using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using PQ.Multitouch;
using PQ.Multitouch.Controls;

namespace Samples
{
    /// <summary>
    /// Interaction logic for MouseSupport.xaml
    /// </summary>
    public partial class MouseSupport : ITableWindow
    {
        Rect rect;

        public MouseSupport()
        {
            InitializeComponent();

            this.Loaded+=new RoutedEventHandler(MouseSupport_Loaded);
        }

        private void MouseSupport_Loaded(object sender, RoutedEventArgs e)
        {
            rect = new Rect(this.Left, this.Top, this.Width, this.Height);

            DragScaleRotate dsr = new DragScaleRotate(true, true, true, true, rect);
            dsr.TranslateDamping = 0.9;
            MultiTouch.EnableGesture(myImage, dsr, null);

            //MultiDragScaleRotate mdsr = MultiTouch.EnableGesture(myImage, new MultiDragScaleRotate(true, true, true, true, rect), null) as MultiDragScaleRotate;
            //mdsr.TranslateDamping = 0.9;
            //mdsr.AngleDamping = 0.95;
            //mdsr.ScaleDamping = 0.99;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }

        private void OnSingleClick(object sender, GestureEventArgs e)
        {
            MessageBox.Show("touch click");
        }

        //it is possible to use system's touch message, but it is better to choose just one, our sdk, or system touch message.
        private void myButton_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            MessageBox.Show("system touch message");
        }

        private void ITableWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            rect = new Rect(this.Left, this.Top, this.Width, this.Height);
        }
    }
}
