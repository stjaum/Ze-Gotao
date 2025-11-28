using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeGotao.Core.Data;
using ZeGotao.DTO;

namespace ZeGotao.BLL
{
    public class VacinasBLL
    {
        private readonly ZeGotaoContext _context;

        public VacinasBLL(ZeGotaoContext ctx)
        {
            _context = ctx;
        }

        public List<VacinasDTO> GetAll()
        {
            return _context.Vacinas
                .Select(v => new VacinasDTO
                {
                    IdVacina = v.IdVacina,
                    NomeVacina = v.NomeVacina,
                    DescricaoVacina = v.DescricaoVacina,
                    FaixaEtaria = v.FaixaEtaria
                }).ToList();
        }
    }
}
