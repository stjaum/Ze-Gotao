using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using ZeGotao.Core;
using ZeGotao.Core.Data;


namespace ZeGotao.UII
{
    public partial class Login : Form
    {
        private readonly ZeGotaoContext _db;

        public Login()
        {
            InitializeComponent();
            _db = DbFactory.CreateDbContext();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Email(object sender, EventArgs e)
        {

        }

        private void Senha(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = DbFactory.CreateDbContext())
                {
                    var usuario = db.Usuario
                        .FirstOrDefault(u => u.Email == email && u.Senha == senha);

                    if (usuario == null)
                    {
                        MessageBox.Show("E-mail ou senha incorretos.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!usuario.Ativo)
                    {
                        MessageBox.Show("Seu usuário está inativo. Entre em contato com o suporte.",
                            "Acesso Negado",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    // Login bem-sucedido
                    MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Exemplo — abra o form principal
                    var main = new Principal(usuario);
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar logar:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
