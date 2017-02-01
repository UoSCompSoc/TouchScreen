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

using System.ComponentModel;

using PQ.Multitouch;
using PQ.Multitouch.Controls;

using System.Diagnostics;

namespace Samples
{
    /// <summary>
    /// Interaction logic for DragScaleRotateWindow.xaml
    /// </summary>
    public partial class DragScaleRotateWindow : ITableWindow
    {
        public DragScaleRotateWindow()
        {
            InitializeComponent();

            // Test general gestures.           
            //test1();

            //test2();
            //test4();
            test5();
            //test6();
            //test7();
            //test8();



            // Test the BaseGesture.ResponseObj property
            // Test the BaseGesture.IsActive property
            //test9();


            // Test SingleDragRotate            
            //test10();


            this.Loaded += new RoutedEventHandler(DragScaleRotateWindow_Loaded);
        }
        
        void DragScaleRotateWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= new RoutedEventHandler(DragScaleRotateWindow_Loaded);

            //MainRoot.Children.Add(PQ.Multitouch.Controls.TouchViewer.Instance);
            //PQ.Multitouch.Controls.TouchViewer.Instance.ImagePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\cursor.bmp";

            //this.MouseDown += new MouseButtonEventHandler(btn_MouseDown);
            //this.AddHandler(TouchEvent.TouchDownEvent, new TouchHandler(OnTouchDown1));

        }

        void test10()
        {
            Rect ScreenResolutionRect = new Rect(0, 0, System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);

            MultiDragScaleRotate dsr = new MultiDragScaleRotate(true, true, true, true, ScreenResolutionRect);
            dsr.MinTouchCount = 2;
            MultiTouch.EnableGesture(this.image, dsr, null);
        }


        void test8()
        {
            MultiTouch.EnableGesture(this.image, new DragScaleRotate(true, false, false, false, null),null);
            MultiTouch.EnableGesture(this.canvas, new SingleClickGesture(), new GestureHandler(OnSingleClick),true);
        }

        private void OnSingleClick(object sender, GestureEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine( sender.ToString() + " .OnSingleClick... ");
        }
        

        private void test6()
        {
            //MultiTouch.EnableGesture(this.image, new SingleMoveGesture(), new GestureHandler(Ontest6SingleMoveImage));
            //MultiTouch.EnableGesture(this, new SingleMoveGesture(), new GestureHandler(Ontest6SingleMoveImage),true);

            MultiTouch.EnableGesture(this, new ZoomGesture(), new ZoomHandler(OnZoom1));
        }

        private void OnZoom1(object sender, ZoomEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(" OnZoom : " + e.ToString());
        }

        private void Ontest6SingleMoveImage(object sender, GestureEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Ontest6SingleMoveImage..." + sender.ToString());
        }


        private MultiDragScaleRotate MDSRInstance;
        private void test5()
        {
            //Matrix m = new Matrix();
            //m.Scale(2.0,2.0);
            //m.Rotate(30);
            //m.Translate(200, 200);
            //image.RenderTransform = new MatrixTransform(m);


            //this.image.AddHandler(TouchEvent.TouchDownEvent, new TouchHandler(OnTouchDown));            
            //, null
            //MultiTouch.EnableGesture(this.canvas, new DragScaleRotate_G2(), null);
            //MultiTouch.EnableGesture(this.image, new DragScaleRotate_G2(true, true, true), null);

            //MultiTouch.EnableGesture(this.button, new DragScaleRotate_G2(true, true, true), null);            

            Rect ScreenResolutionRect = new Rect(0, 0, System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);

            DragScaleRotate dsr = MultiTouch.EnableGesture(this.image, new DragScaleRotate(true, true, true, true, ScreenResolutionRect), null) as DragScaleRotate;
            dsr.TranslateDamping = 0.95;

            //MultiTouch.EnableGesture(this.image, new MultiDragScaleRotate(true, true, true, true, ScreenResolutionRect), null);

            //MDSRInstance = MultiTouch.EnableGesture(this.image, new MultiDragScaleRotate(true, true, true, true, ScreenResolutionRect), null) as MultiDragScaleRotate;
            //MultiTouch.EnableGesture(this.image, new TouchEndGesture(), new GestureHandler(OnTouchEnd));
        }


        private void OnTouchEnd(object sender, GestureEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine( MDSRInstance.CurrentScaleWidth + " ;  " + MDSRInstance.CurrentScaleHeight);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Matrix m = this.image.RenderTransform.Value;
            m.Append(this.canvas.RenderTransform.Value);

            this.image.RenderTransform = new MatrixTransform(m);
        }


        private void OnTouchDown(object sender, PQ.Multitouch.TouchEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            System.Diagnostics.Debug.WriteLine(this.image.PointFromScreen(pt));            
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        private void test4()
        {
            MultiTouch.EnableGesture(this.image, new SingleMoveGesture(), new GestureHandler(OnTest4SingleMoveImage));
            MultiTouch.EnableGesture(this.canvas, new SingleMoveGesture(), new GestureHandler(OnTest4SingleMoveCanvas));
        }

        private void OnTest4SingleMoveImage(object sender, GestureEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("OnTest4SingleMoveImage...: " + e.ToString());
        }

        private void OnTest4SingleMoveCanvas(object sender, GestureEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("OnTest4SingleMoveCanvas...");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        
        private void test2()
        {
            //System.Diagnostics.Debug.WriteLine("================================");
            //UtilDebugger.TraceLogicalTree(this, 0);
            //System.Diagnostics.Debug.WriteLine("================================");
            //UtilDebugger.TraceVisualTree(MainRoot, 0);
            //MultiTouch.EnableGesture(this.MainRoot, new SingleDownGesture(), new RoutedEventHandler(DebugGestureHandler));
            
            //MultiTouch.EnableGesture(this.image, new DragMoveGesture(), new RoutedEventHandler(OnDrag));
            MultiTouch.EnableGesture(this.canvas, new DragMoveGesture(), new DragHandler(OnDrag));
        }

        private void test1()
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
            //MultiTouch.EnableGesture(this.image, new MultiMoveGesture(), new GestureHandler(DebugGestureHandler),true);
            //MultiTouch.EnableGesture(this.image, new MultiUpGesture(), new GestureHandler(DebugGestureHandler));

            //MultiTouch.EnableGesture(this.image, new ZoomGesture(), new ZoomHandler(OnZoom));
            //MultiTouch.EnableGesture(this.image, new RotateGesture(), new RotateHandler(OnRotate));
            //MultiTouch.EnableGesture(this.image, new DragMoveGesture(), new DragHandler(OnDrag),true);
            //MultiTouch.EnableGesture(this.image, new FlickGesture(), new FlickHandler(OnFlick), true);

            MultiTouch.EnableGesture(this.image, new ManipulateGesture(), new ManipulateHandler(OnManipulate), true);
        }

        private void OnTouchMove(object sender, PQ.Multitouch.TouchEventArgs e)
        {
            this.image.SetValue(Canvas.LeftProperty, e.X);
            this.image.SetValue(Canvas.TopProperty, e.Y);
        }

        private void DebugGestureHandler(object sender, GestureEventArgs e)
        {            
            //for (int i = 0; i < e.TouchBlobs.Count; i++)
            //{                
            //    BlobInfo bi = e.TouchBlobs[i];
            //    System.Diagnostics.Debug.WriteLine(bi.ToString());
            //}
            System.Diagnostics.Trace.WriteLine("DebugRoutedHandler: " + e.ToString());
        }

        private void DebugRoutedHandler1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DebugRoutedHandler1: " + sender.ToString() + "   " + e.RoutedEvent.Name);
            e.Handled = true;
        }

        private void DebugRoutedHandler(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DebugRoutedHandler: " + sender.ToString() + "   " + e.RoutedEvent.Name);
            e.Handled = true;
        }

        private void DebugHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DebugHandler: " + sender.ToString() + "   " + e.ToString());
        }

        private void OnFlick(object sender, FlickEventArgs fe)
        {
            System.Diagnostics.Debug.WriteLine("DebugHandler: " + sender.ToString() + "   " + fe.ToString());
        }

        private void OnZoom(object sender, ZoomEventArgs ze)
        {            
            System.Diagnostics.Trace.WriteLine("OnZoom: " + ze.ToString());
            //System.Diagnostics.Debug.WriteLine("DebugRoutedHandler: [ FrameID " + ze.FrameID + " ]  " + sender.ToString() + "   " + ze.RoutedEvent.Name);
            this.image.RenderTransformOrigin = new Point(0.5, 0.5);
            Matrix m = this.image.RenderTransform.Value;
            m.Scale(ze.DeltaScale, ze.DeltaScale);
            this.image.RenderTransform = new MatrixTransform(m);
        }

        private void OnRotate(object sender, RotateEventArgs re)
        {
            //for (int i = 0; i < re.TouchBlobs.Count; i++)
            //{
            //    BlobInfo bi = re.TouchBlobs[i];
            //    System.Diagnostics.Trace.WriteLine(bi.ToString());
            //}
            //System.Diagnostics.Trace.WriteLine(re.ToString());

            Matrix m = this.image.RenderTransform.Value;
            m.Rotate(re.DeltaAngle * 180 / Math.PI);
            this.image.RenderTransform = new MatrixTransform(m);
        }

        private void OnDrag(object sender, DragMoveEventArgs de)
        {            
            //System.Diagnostics.Debug.WriteLine("OnDrag: [ FrameID " + de.FrameID + " ]  " + de.DeltaVector);
            System.Diagnostics.Debug.WriteLine("OnDrag: [ FrameID " + de.FrameID + " ]  " + de.ToString());
            
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            Matrix m = image.RenderTransform.Value;
            m.Translate(de.DeltaVector.X, de.DeltaVector.Y);
            image.RenderTransform = new MatrixTransform(m);
        }

        private void OnManipulate(object sender, ManipulateEventArgs me)
        {
            System.Diagnostics.Trace.WriteLine("OnManipulate: [ FrameID " + me.FrameID + " ]  " + me.ToString());

            
            Matrix m = this.image.RenderTransform.Value;
            m.Scale(me.DeltaScale, me.DeltaScale);
            m.Rotate(me.DeltaAngle * 180 / Math.PI);
            m.Translate(me.DeltaVector.X, me.DeltaVector.Y);
            this.image.RenderTransform = new MatrixTransform(m);
        }
    }
}
