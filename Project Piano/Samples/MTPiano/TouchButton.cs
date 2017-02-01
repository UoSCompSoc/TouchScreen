using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

using PQ.Multitouch;

namespace MTPiano
{
    public class TouchButton :Button
    {

        private bool isTouchOver;

        public TouchButton()
            : base()
        {
            
        }

        public event RoutedEventHandler TouchClick
        {
            add 
            {                
                AddHandler(TouchEvent.TouchClickEvent, value); 
            }
            remove 
            {                
                RemoveHandler(TouchEvent.TouchClickEvent, value); 
            }
        }

        public event RoutedEventHandler TouchDown
        {
            add
            {
                AddHandler(TouchEvent.TouchDownEvent, value);
            }
            remove
            {   
                RemoveHandler(TouchEvent.TouchDownEvent, value);
            }
        }

        public event RoutedEventHandler TouchUp
        {
            add
            {
                AddHandler(TouchEvent.TouchUpEvent, value);
            }
            remove
            {
                RemoveHandler(TouchEvent.TouchUpEvent, value);
            }
        }

        public event RoutedEventHandler TouchEnter
        {
            add
            {
                AddHandler(TouchEvent.TouchEnterEvent, value);
            }
            remove
            {
                RemoveHandler(TouchEvent.TouchEnterEvent, value);
            }
        }

        public event RoutedEventHandler TouchLeave
        {
            add
            {
                AddHandler(TouchEvent.TouchLeaveEvent, value);
            }
            remove
            {
                RemoveHandler(TouchEvent.TouchLeaveEvent, value);
            }
        }

        public bool IsTouchOver
        {
            set { isTouchOver = value; }
            get { return isTouchOver; }
        }
    }
}
