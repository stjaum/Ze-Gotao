namespace ZeGotao.ViewModels
{
    public class CarteirinhaViewModel
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public List<CarteirinhaItemViewModel> Itens { get; set; }
    }

    public class CarteirinhaItemViewModel
    {
        public string NomeVacina { get; set; }
        public bool Tomou { get; set; }
        public DateTime DataTomou { get; set; }

        public string NomeUnidade { get; set; }     
        public string EnderecoUnidade { get; set; } 
    }
}
