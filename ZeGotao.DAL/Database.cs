using ZeGotao.DTO;

namespace ZeGotao.DAL
{

    public static class Database
    {

        public static List<UsuarioDTO> Usuarios
        {
            get => JsonDatabase.Ler<UsuarioDTO>("Usuarios.json");
            set => JsonDatabase.Salvar("Usuarios.json", value);
        }

  

    }
}