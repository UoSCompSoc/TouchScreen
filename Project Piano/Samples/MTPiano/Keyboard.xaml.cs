using System;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Animation;

using PQ.Multitouch;

namespace MTPiano
{
    public partial class Keyboard
    {
          
        public Keyboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds event handlers that change piano key images and play audio.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            AddHandlers();
        }
        /// <summary>
        /// Adds event handlers.
        /// </summary>
        private void AddHandlers()
        {
            AddHandler("C7");
            AddHandler("C_7");
            AddHandler("D7");
            AddHandler("D_7");
            AddHandler("E7");
            AddHandler("F7");
            AddHandler("F_7");
            AddHandler("G7");
            AddHandler("G_7");
            AddHandler("A7");
            AddHandler("A_7");
            AddHandler("B7");
            AddHandler("C6");
            AddHandler("C_6");
            AddHandler("D6");
            AddHandler("D_6");
            AddHandler("E6");
            AddHandler("F6");
            AddHandler("F_6");
            AddHandler("G6");
            AddHandler("G_6");
            AddHandler("A6");
            AddHandler("A_6");
            AddHandler("B6");
        }

        /// <summary>
        /// Adds a handler for the given key.
        /// </summary>
        /// <param name="key">a piano key to add handlers</param>
        private void AddHandler(string key)
        {
            TouchButton pianoKey = (TouchButton)GetElement(key);

            // add OnIsPressed changed
            DependencyPropertyDescriptor.FromProperty(Button.IsPressedProperty,
                typeof(Button)).AddValueChanged(pianoKey, OnIsPressedChanged);

            // add MouseLeftButton Down and Up
            pianoKey.MouseLeftButtonDown += OnMouseLeftButtonDown;
            pianoKey.MouseLeftButtonUp += OnMouseLeftButtonUp;
            pianoKey.MouseEnter += OnMouseLeftButtonDown;// OnMouseEnter;
            pianoKey.MouseLeave += OnMouseLeftButtonUp;// OnMouseLeave;

            pianoKey.TouchEnter += OnTouchEnter;
            pianoKey.TouchLeave += OnTouchLeave;
        }

        
        /// <summary>
        /// Event handler for the IsPressedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIsPressedChanged(object sender, EventArgs e)
        {
            Button pianoKey = (Button)sender;
            bool isPressed = pianoKey.IsPressed;

            if (isPressed)
            {
                // play the note only if a contact is over or
                // the mouse is over with the left key pressed,
                // pressing the left key is handled separately by the OnMouseLeftButtonDown and Up
                // event handlers
                if ( pianoKey.IsMouseOver && Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    StateChanged(pianoKey, true);
                }
            }
            else
            {
                // draw unpressed
                StateChanged(pianoKey, false);
            }
        }


        /// <summary>
        /// Handles piano key state change.
        /// </summary>
        /// <param name="pianoKey"></param>
        /// <param name="isPressed"></param>
        public void StateChanged(Button pianoKey, bool isPressed)
        {
            if (isPressed)
            {
                // play the note and draw piano key in the pressed state                
                PlayNote(pianoKey);
                DrawPianoKey(pianoKey, true);
            }
            else
            {
                // draw the piano key in unpressed state
                DrawPianoKey(pianoKey, false);
            }
        }


        /// <summary>
        /// Plays the tone.
        /// </summary>
        /// <param name="pianoKey"></param>
        private void PlayNote(Button keyBtn)
        {            
            MediaElement me = (MediaElement)audio.FindName(keyBtn.Name + "_wav");                      
            me.Stop();          
            me.Play();              
            // tone may be silent after a while, you need to use Microsoft.Xna.Framework to solve this problem.
            // we donnot use XNA in this multi-touch sample.
        }

        /// <summary>
        /// Returns an element for the given name.
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        private FrameworkElement GetElement(string elementName)
        {
            return (FrameworkElement)keys.FindName(elementName);
        }

        /// <summary>
        /// Draws the given pianoKey in pressed or unpressed state.
        /// </summary>
        /// <param name="pianoKey"></param>
        private void DrawPianoKey(FrameworkElement pianoKey, bool isPressed)
        {
            // draw the key in the pressed state
            string key = pianoKey.Name;

            Visibility pressedImageVisibility = isPressed ? Visibility.Visible : Visibility.Hidden;
            Visibility normalImageVisibility = isPressed ? Visibility.Hidden : Visibility.Visible;

            // sharp/flat tones
            if (key.Contains("_"))
            {
                GetElement("key" + key + "x").Visibility = pressedImageVisibility;
                GetElement("key" + key).Visibility = normalImageVisibility;
            }

            // normal tones
            else
            {
                GetElement("key" + key + "xtop").Visibility = pressedImageVisibility;
                GetElement("key" + key + "xbottom").Visibility = pressedImageVisibility;
                GetElement("key" + key + "top").Visibility = normalImageVisibility;
                GetElement("key" + key + "bottom").Visibility = normalImageVisibility;
            }
        }

        #region Mouse Events

        /// <summary>
        /// Event handler for the MouseDown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            StateChanged((Button)sender, true);
        }

        /// <summary>
        /// Event handler for the MouseUp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            StateChanged((Button)sender, false);
        }

        #endregion

        #region Touch Events

        private void OnTouchEnter(object sender, RoutedEventArgs e)
        {
            StateChanged((Button)sender, true);
        }

        private void OnTouchLeave(object sender, RoutedEventArgs e)
        {
            StateChanged((Button)sender, false);
        }

        #endregion
    }
}