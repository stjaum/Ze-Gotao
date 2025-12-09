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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            try
            {
                if (server != null && !server.HasExited)
                {
                    server.Kill(true);   // Encerra o processo e subprocessos
                    server.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro ao matar servidor: " + ex.Message);
            }
        }
        private Process? server;

        private Button btnClose;
        private Button btnMaxRestore;
        private Button btnMinimize;
        public Principal()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }
        private async Task<bool> EsperarBackendAsync()
        {
            using (var client = new HttpClient())
            {
                for (int i = 0; i < 30; i++) // tenta por até 30x (30s)
                {
                    try
                    {
                        var resp = await client.GetAsync("http://localhost:5029");
                        if (resp.IsSuccessStatusCode)
                            return true; // servidor está online
                    }
                    catch { }

                    await Task.Delay(1000); // espera 1s e tenta de novo
                }
            }

            return false; // se passou dos 30s, falhou
        }

        private async void Principal_Load(object sender, EventArgs e)
        {
            CriarLoadingOverlay(); // ← mostra o loading em cima do WebView2

            // iniciar projeto dotnet (mantém seu código)
            server = Process.Start(new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run --project \"C:\\Users\\joao.vvsilva21\\source\\repos\\Ze-Gotao\\ZeGotao\\ZeGotao.csproj\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });

            await webView2.EnsureCoreWebView2Async(null);

            // espera o backend realmente ficar pronto
            bool ok = await EsperarBackendAsync();

            if (ok)
            {
                webView2.Source = new Uri("http://localhost:5029");
            }
            else
            {
                MessageBox.Show("Falha ao iniciar o servidor.");
            }

            // esconde o overlay
            loadingOverlay.Visible = false;

            this.Padding = new Padding(1);
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void webView2_Click(object sender, EventArgs e)
        {

        }
        // FECHAR COMPLETO (mata o .NET + app)
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            try
            {
                if (server != null && !server.HasExited)
                    server.Kill(true);
            }
            catch { }

            Application.Exit();
        }

        // MAXIMIZAR / RESTAURAR
        private void BtnMaxRestore_Click(object? sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaxRestore.Text = "🗗"; // ícone de restaurar
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMaxRestore.Text = "⬜";
            }
        }

        // MINIMIZAR
        private void BtnMinimize_Click(object? sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "http://localhost:5029",
                UseShellExecute = true
            });
        }
    }
}
