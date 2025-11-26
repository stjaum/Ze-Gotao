using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeGotao.DTO
{
    public class VacinacaoDTO
    {
        public int IdVacinacao { get; set; }
        public int IdUsuario { get; set; }
        public int IdVacina { get; set; }
        public int IdUnidade { get; set; }
        public bool Status { get; set; }

        // Campos opcionais para telas (sem navegação)
        public string NomeUsuario { get; set; }
        public string NomeVacina { get; set; }
        public string NomeUnidade { get; set; }
    }
}
