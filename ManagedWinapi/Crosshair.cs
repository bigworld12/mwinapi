using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ManagedWinapi
{
    /// <summary>
    /// This component displays a crosshair icon that can be dragged to any point
    /// on screen. This is useful to select other programs by dragging the crosshair
    /// to a program window.
    /// </summary>
    public partial class Crosshair : UserControl
    {
        Image myImage;
        Cursor myCursor;

        /// <summary>
        /// Occurs when the user finished dragging the crosshair. Use 
        /// <see cref="Cursor.Position"/> to detect the cursor position.
        /// </summary>
        public event EventHandler CrosshairDragged;

        /// <summary>
        /// Occurs while the user drags the crosshair. Use 
        /// <see cref="Cursor.Position"/> to detect the cursor position.
        /// </summary>
        public event EventHandler CrosshairDragging;

        /// <summary>
        /// Creates a new crosshair control.
        /// </summary>
        public Crosshair()
        {
            InitializeComponent();
            myImage = new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ManagedWinapi.crosshair.ico"));
            myCursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ManagedWinapi.crosshair.ico"));
            dragger.Image = myImage;
        }

        private void dragger_MouseDown(object sender, MouseEventArgs e)
        {
            dragger.Image = null;
            dragger.Cursor = myCursor;
        }

        private void dragger_MouseUp(object sender, MouseEventArgs e)
        {
            dragger.Image = myImage;
            dragger.Cursor = Cursors.Cross;
            CrosshairDragged(this, new EventArgs());
        }

        private void dragger_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragger.Cursor == myCursor)
            {
                if (CrosshairDragging != null)
                {
                    CrosshairDragging(this, new EventArgs());
                }
            }
        }
    }
}
