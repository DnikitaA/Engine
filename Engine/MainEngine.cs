using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Threading;
using System.Collections;

namespace Engine
{
    public class MainEngine
    {
        private Device device = null;
        private InputDevices input = null;
        private Control renderWindow = null;
        public Thread renderThread = null;
        private Thread processDevices = null;

        private PresentParameters presentParams = new PresentParameters();
        private Color bgColor = Color.Black;
        private float zDepth = 1.0f;

        public MainEngine(Control mainForm)
        {
            renderWindow = mainForm;
        }

        public void InitializeGraphics()
        {
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            device = new Device(0, DeviceType.Hardware, renderWindow, CreateFlags.HardwareVertexProcessing, presentParams);
            renderThread = new Thread(Render);
            renderThread.Start();
        }

        public void InitializeInput()
        {
            input = new InputDevices(renderWindow);
            processDevices = new Thread(input.Processing);
            processDevices.Start();
        }

        public void DeInitializeGraphics()
        {
            device = null;
            renderThread.Abort();
        }

        public void DeInitializeInput()
        {
            input = null;
            processDevices.Abort();
        }

        private void Render()
        {
            CustomVertex.TransformedColored[] verts = new CustomVertex.TransformedColored[3];
            verts[0].Position = new Vector4(renderWindow.Width / 2.0f, 50.0f, 0.5f, 1.0f);
            verts[0].Color = Color.Red.ToArgb();
            verts[1].Position = new Vector4(renderWindow.Width - (renderWindow.Width / 5.0f), renderWindow.Height - (renderWindow.Height / 5.0f), 0.5f, 1.0f);
            verts[1].Color = Color.Green.ToArgb();
            verts[2].Position = new Vector4(renderWindow.Width / 5.0f, renderWindow.Height - (renderWindow.Height / 5.0f), 0.5f, 1.0f);
            verts[2].Color = Color.Blue.ToArgb();
            while (true)
            {
                device.Clear(ClearFlags.Target, bgColor, zDepth, 0);
                device.BeginScene();
                device.VertexFormat = CustomVertex.TransformedColored.Format;
                device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, verts);
                device.EndScene();
                device.Present();
            }
        }

        public void SetBackgroudColor(Color color)
        {
            bgColor = color;
        }

        public void SetZDepth(float depth)
        {
            zDepth = depth;
        }
    }
}
