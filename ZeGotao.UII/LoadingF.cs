using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZeGotao.UII
{
    public class LoadingF : Form
    {
        private readonly System.Windows.Forms.Timer _timer;
        private int _angle = 0;

        public LoadingF()
        {
            // Aparência
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Width = 180;
            Height = 180;

            DoubleBuffered = true;

            BackColor = Color.FromArgb(30, 30, 30); // fundo escuro semi-transparente
            Opacity = 0.92;

            // Bordas arredondadas
            var hrgn = NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 24, 24);
            Region = Region.FromHrgn(hrgn);

            // Blur no Windows 10/11 (caso disponível)
            EnableBlur();

            // Timer da animação
            _timer = new System.Windows.Forms.Timer { Interval = 12 };
            _timer.Tick += (s, e) =>
            {
                _angle = (_angle + 4) % 360;
                Invalidate();
            };
            _timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Spinner em estilo circular
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.White, 6))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Triangle;

                e.Graphics.DrawArc(pen, 35, 35, 110, 110, _angle, 300);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timer?.Stop();
            base.OnFormClosing(e);
        }

        private void EnableBlur()
        {
            try
            {
                var accent = new NativeMethods.ACCENTPOLICY
                {
                    AccentState = NativeMethods.ACCENTSTATE.ACCENT_ENABLE_BLURBEHIND,
                    AccentFlags = 0,
                    GradientColor = 0,
                    AnimationId = 0
                };

                var data = new NativeMethods.WINCOMPATTRDATA
                {
                    Attribute = NativeMethods.WCA_ACCENT_POLICY,
                    SizeOfData = Marshal.SizeOf(accent)
                };

                data.Data = Marshal.AllocHGlobal(data.SizeOfData);
                Marshal.StructureToPtr(accent, data.Data, true);

                NativeMethods.SetWindowCompositionAttribute(this.Handle, ref data);

                Marshal.FreeHGlobal(data.Data);
            }
            catch
            {
                // Falha silenciosa em sistemas sem suporte
            }
        }

        private void InitializeComponent()
        {

        }
    }

    // -------------------------------------------------------
    // NATIVEMETHODS — NECESSÁRIA PARA O BLUR E BORDA REDONDA
    // -------------------------------------------------------
    internal static class NativeMethods
    {
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int left, int top, int right, int bottom,
            int width, int height);

        [DllImport("user32.dll")]
        public static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WINCOMPATTRDATA data);

        public const int WCA_ACCENT_POLICY = 19;

        public enum ACCENTSTATE
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACCENTPOLICY
        {
            public ACCENTSTATE AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINCOMPATTRDATA
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }
    }
}
