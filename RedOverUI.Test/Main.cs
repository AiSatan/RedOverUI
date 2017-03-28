using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Red.BitmapHelpers;

namespace RedOverUI.Test
{
    [TestClass]
    public class Main
    {
        [TestMethod]
        public void SimpleRun()
        {
            var resetEvent = new AutoResetEvent(false);
            RedOverlay.OnShown += () =>
            {
                RedOverlay.Refresh();
                resetEvent.Set();
            };

            RedOverlay.OnUpdate += g =>
            {
                g.FillRectangle(Brushes.Red, new Rectangle(0, 0, 10, 10));
            };

            resetEvent.WaitOne(5000);

            using (var bmpScreenCapture = new Bitmap(10, 10))
            {
                using (var g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(0, 0, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);
                }
                var pixels = bmpScreenCapture.BitmapToByteRgbQ();

                var width = bmpScreenCapture.Width;
                var height = bmpScreenCapture.Height;
                for (var x = 0; x < width; x++)
                {
                    for (var y = 0; y < height; y++)
                    {
                        var color = pixels.GetColor(x, y);
                        Assert.IsTrue(color.R == Color.Red.R);
                    }
                }
            }
            RedOverlay.Shutdown();
        }
    }
}
