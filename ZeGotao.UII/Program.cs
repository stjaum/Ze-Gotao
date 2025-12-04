using System;
using System.Threading;
using System.Windows.Forms;

namespace ZeGotao.UII
{
    internal static class Program
    {
        private static LoadingF? loading;

        [STAThread]
        static void Main()
        {
            // configurações padrão
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Thread separada para a tela de loading
            Thread loadingThread = new Thread(() =>
            {
                loading = new LoadingF();
                Application.Run(loading);
            });

            loadingThread.SetApartmentState(ApartmentState.STA);
            loadingThread.IsBackground = true;
            loadingThread.Start();

            // ---- PROCESSOS PESADOS INICIALIZANDO ----
            Thread.Sleep(2000);  // teste - substitua pelo dotnet run
            // -----------------------------------------

            // Fecha loading com segurança
            if (loading != null && loading.IsHandleCreated)
            {
                loading.Invoke(new Action(() =>
                {
                    loading.Close();
                }));
            }

            // Inicia o form principal
            Application.Run(new Principal());
        }
    }
}