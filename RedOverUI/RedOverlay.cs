﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RedOverUI
{
    public static class RedOverlay
    {
        public static event Action<Graphics> OnUpdate = delegate { };
        public static event Action OnShown = delegate { };
        private static Overlay _overlayForm;
        private static Thread FormThread { get; }

        static RedOverlay()
        {
            FormThread = new Thread(() =>
            {
                _overlayForm = new Overlay();
                Application.Run(_overlayForm);
            });
            FormThread.TrySetApartmentState(ApartmentState.STA);
            FormThread.Start();
        }

        public static void Refresh()
        {
            if (_overlayForm == null)
                return;

            if (_overlayForm.InvokeRequired)
            {
                _overlayForm?.Invoke(new Action(Refresh));
                return;
            }
            _overlayForm?.Refresh();
        }

        public static void Shutdown()
        {
            if (_overlayForm.InvokeRequired)
            {
                _overlayForm?.Invoke(new Action(Shutdown));
                return;
            }
            _overlayForm?.Close();
        }

        public static void SetOpacity(int alpha)
        {
            if (_overlayForm.InvokeRequired)
            {
                _overlayForm?.Invoke(new Action<int>(SetOpacity), alpha);
                return;
            }
            _overlayForm?.SetOpacity(alpha / 255.0d);
        }

        #region Called from Form

        internal static void Update(Graphics g)
        {
            OnUpdate(g);
        }

        internal static void FormShown()
        {
            OnShown();
        }

        #endregion

    }
}