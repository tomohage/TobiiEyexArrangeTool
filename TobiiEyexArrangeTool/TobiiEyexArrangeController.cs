using System;
using System.Windows.Forms;

namespace TobiiEyexArrangeTool
{
    using EyeXFramework;
    using Tobii.EyeX.Framework;

    class TobiiEyexArrangeController
    {
        private EyeXHost eyexHost = null;
        public double x, y;
        public double monitorHeight, monitorWidth;


        public void StartTobiiEyex()
        {
                eyexHost = new EyeXHost();
                eyexHost.Start();
                AddVisionDataListener();
                SetDisplaySizeByScreen();
        }

        public void DisposeTobiiEyex()
        {
            eyexHost.Dispose();
        }

        public void AddVisionDataListener()
        {
            var stream = this.eyexHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            stream.Next += (s, e) =>
            {
                x = e.X;
                y = e.Y;
            };
        }

        /// <summary>
        /// Screenクラスでモニターの解像度を取得するメソッド
        /// SetDisplaySizeメソッドの暫定対応
        /// </summary>
        private void SetDisplaySizeByScreen()
        {
            Console.WriteLine(Screen.PrimaryScreen.Bounds);
            this.monitorHeight = Screen.PrimaryScreen.Bounds.Height;
            this.monitorWidth = Screen.PrimaryScreen.Bounds.Width;
            Console.WriteLine(this.monitorHeight + "," + this.monitorWidth);
            Console.WriteLine("Finish setting display size. Get size from monitor_height or monitor_width.");
            return;
        }
    }
}
