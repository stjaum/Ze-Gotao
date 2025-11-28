using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace ZeGotao.UII
{
    public partial class Principal : Form
    {
        private Process? server;

        public Principal()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }
        private async void Principal_Load(object sender, EventArgs e)
        {
            // Inicia o backend ASP.NET automaticamente
            server = Process.Start(new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run --project \"C:\\Users\\joao.vvsilva21\\source\\repos\\Ze-Gotao\\ZeGotao\\ZeGotao.csproj\"",
                UseShellExecute = false,
                CreateNoWindow = true,         // Não cria janela
                WindowStyle = ProcessWindowStyle.Hidden, // Garante que fique invisível
                RedirectStandardOutput = true, // (opcional) permite ler logs se quiser
                RedirectStandardError = true
            });

            await webView2.EnsureCoreWebView2Async(null);

            // Tempo para o servidor ASP.NET iniciar
            await Task.Delay(8000);

            // Certifique-se que essa URL é a mesma do launchSettings.json
            webView2.Source = new Uri("http://localhost:5029");
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void webView2_Click(object sender, EventArgs e)
        {

        }
    }
}
