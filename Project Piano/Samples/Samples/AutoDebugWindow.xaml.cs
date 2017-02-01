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
    /// Interaction logic for AutoDebugWindow.xaml
    /// </summary>
    public partial class AutoDebugWindow : ITableWindow
    {
        public AutoDebugWindow()
        {
            InitializeComponent();            
            testGestureEvents();
        }

        private void testGestureEvents()
        {
            //MultiTouch.EnableGesture(this.image, new SingleDownGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new SingleMoveGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new SingleUpGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new SingleClickGesture(), new GestureHandler(DebugGestureHandler));

            //MultiTouch.EnableGesture(this.image, new SecondDownGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new SecondUpGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new SecondClickGesture(), new GestureHandler(DebugGestureHandler));

            //MultiTouch.EnableGesture(this.image, new DualDownGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new DualMoveGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new OnePauseOneMoveGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new DualUpGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new DualClickGesture(), new GestureHandler(DebugGestureHandler));

            //MultiTouch.EnableGesture(this.image, new MultiDownGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new MultiMoveGesture(), new GestureHandler(DebugGestureHandler));
            //MultiTouch.EnableGesture(this.image, new MultiUpGesture(), new GestureHandler(DebugGestureHandler));

            //MultiTouch.EnableGesture(this.image, new ZoomGesture(), new ZoomHandler(OnZoom));
            //MultiTouch.EnableGesture(this.image, new RotateGesture(), new RotateHandler(OnRotate));
            //MultiTouch.EnableGesture(this.image, new DragMoveGesture(), new DragHandler(OnDrag));

            image.AddHandler(TouchEvent.TouchUpEvent, new TouchHandler(OnTouchUp));
        }


        private void OnTouchUp(object sender, PQ.Multitouch.TouchEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.DownObj);
            BlobInfo[] blobs=MultiTouch.GetLocalBlobs(sender as UIElement);
            System.Diagnostics.Debug.WriteLine(blobs.Count());
            //lb.Items.Add(blobs.Count());
        }
    
        private void DebugGestureHandler(object sender, GestureEventArgs e)
        {
            PrintBaseGestureEventArgs(e);
        }

        private void PrintBaseGestureEventArgs(BaseGestureEventArgs e)
        {
#if DEBUG
            for (int i = 0; i < e.TouchBlobs.Count; i++)
            {
                BlobInfo bi = e.TouchBlobs[i];

                //AutoDebugger.WriteLine(bi.ToString());
            }
            //AutoDebugger.WriteLine("DebugGestureHandler: " + e.ToString());
#endif
        }

        private void OnZoom(object sender, ZoomEventArgs e)
        {
            PrintBaseGestureEventArgs(e);
        }

        private void OnRotate(object sender, RotateEventArgs e)
        {
            PrintBaseGestureEventArgs(e);
        }

        private void OnDrag(object sender, DragMoveEventArgs e)
        {
            PrintBaseGestureEventArgs(e);
        }
    }
}
