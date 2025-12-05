using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ZeGotao.ViewModels
{
    public class AtualizarCarteirinhaViewModel
    {
        public int IdUsuario { get; set; }

        public int IdVacina { get; set; }
        public IEnumerable<SelectListItem> Vacinas { get; set; }

        public DateTime DataTomou { get; set; }

        public int IdUnidade { get; set; }
        public IEnumerable<SelectListItem> Unidades { get; set; }
    }
}
