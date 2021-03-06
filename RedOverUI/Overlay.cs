﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RedOverUI
{
    internal sealed partial class Overlay : Form
    {
        internal Overlay()
        {
            InitializeComponent();
            InitForm();
            SetFormToTransparent();
        }

        private void InitForm()
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        private void SetFormToTransparent()
        {
            Win32Delegates.SetWindowLong(Handle, (int)Win32Delegates.GWL.ExStyle, (int)Win32Delegates.WS_EX.Layered | (int)Win32Delegates.WS_EX.Transparent);
        }

        #region Call Overlay events

        private void Overlay_Shown(object sender, EventArgs e)
        {
            RedOverlay.FormShown();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // set on top - always
                Win32Delegates.SetWindowPos(this.Handle, Win32Delegates.HWND_TOPMOST, 0, 0, 0, 0, Win32Delegates.TOPMOST_FLAGS);
                // refresh
                e.Graphics.Clear(Color.Black);
                // call event
                RedOverlay.Update(e.Graphics);
            }
            catch
            {
                // ignored
            }
        }

        #endregion

    }
}
