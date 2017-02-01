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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Xps.Packaging;


using PQ.Multitouch;
using PQ.Multitouch.Controls;


namespace EasyMediaview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ITableWindow
    {
        Rect rect;

        Random rand;

        public MainWindow()
        {
            InitializeComponent();

            rect = new Rect(0, 0, System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);

            rand = new Random();

            LoadMedias();

            
            PQ.Multitouch.Controls.TouchViewer.Instance.ImagePath = System.Environment.CurrentDirectory + @"\cursor.bmp";
            myCanvas.Children.Add(PQ.Multitouch.Controls.TouchViewer.Instance);

            this.AddHandler(TouchEvent.TouchDoubleClickEvent, new TouchHandler(onDoubleClick));
            this.MouseDown += new MouseButtonEventHandler(MainWindow_MouseDown);
        }

        private void onDoubleClick(object sender, PQ.Multitouch.TouchEventArgs e)
        {
            System.Diagnostics.Debug.Write("ggg");
        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(this.Left.ToString() + " " + this.Top.ToString());
            double x = (double)myCanvas.GetValue(Canvas.LeftProperty);
            double y = (double)myCanvas.GetValue(Canvas.TopProperty);

            System.Diagnostics.Debug.WriteLine(x.ToString() + " " + y.ToString());
        }

        private void LoadMedias()
        {
            string path = System.Environment.CurrentDirectory + @"\medias";

            try
            {
                string[] files = System.IO.Directory.GetFiles(path);

                foreach (string file in files)
                {
                    LoadFile(file);
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("IO wrong:"+e.ToString());
            }
        }

        private void LoadFile(string file)
        {
            string fileExt = System.IO.Path.GetExtension(file).ToLower();

            if (fileExt == ".jpg" || fileExt == ".png" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".tif" || fileExt == ".ico" || fileExt == ".jpeg" || fileExt == ".tiff")
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(file));

                image.Width = 400;
                image.Height = 300;
               
                myCanvas.Children.Add(image);

                double x = rand.NextDouble() * rect.Width;
                double y = rand.NextDouble() * rect.Height;

                image.SetValue(Canvas.LeftProperty, x);
                image.SetValue(Canvas.TopProperty, y);

                MultiDragScaleRotate mdsr = new MultiDragScaleRotate(true, true, true, false, rect);
                MultiTouch.EnableGesture(image, mdsr, null);
            }
            else if (fileExt == ".avi" || fileExt == ".wmv" || fileExt == ".mpg" || fileExt == ".mpeg" || fileExt == ".mp4")
            {
                MediaElement me = new MediaElement();
                me.Source = new Uri(file);
                me.LoadedBehavior = MediaState.Manual;
                me.Play();
                me.MediaEnded += new RoutedEventHandler(me_MediaEnded);

                myCanvas.Children.Add(me);

                double x = rand.NextDouble() * rect.Width;
                double y = rand.NextDouble() * rect.Height;

                me.SetValue(Canvas.LeftProperty, x);
                me.SetValue(Canvas.TopProperty, y);

                MultiDragScaleRotate mdsr = new MultiDragScaleRotate(true, true, true, false, rect);
                MultiTouch.EnableGesture(me, mdsr, null);
            }
            else if (fileExt == ".xps")
            {
                DocumentViewer dv = (DocumentViewer)this.Resources["myDocViewer"];
                dv.Document = new XpsDocument(file, FileAccess.Read).GetFixedDocumentSequence();

                dv.FitToMaxPagesAcross(1);

                double x = rand.NextDouble() * rect.Width;
                double y = rand.NextDouble() * rect.Height;

                dv.SetValue(Canvas.LeftProperty, x);
                dv.SetValue(Canvas.TopProperty, y);

                myCanvas.Children.Add(dv);

                MultiDragScaleRotate mdsr = new MultiDragScaleRotate(true, true, true, false, rect);
                MultiTouch.EnableGesture(dv, mdsr, null);
            }
        }

        private void me_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement me = sender as MediaElement;

            me.Position = TimeSpan.FromSeconds(0);
            me.Play();
        }
    }
}
