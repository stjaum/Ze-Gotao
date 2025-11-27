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

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
