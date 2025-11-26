using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeGotao.Core.Data;
using ZeGotao.DTO;

namespace ZeGotao.BLL
{
    public class UnidadeBLL
    {
        private readonly ZeGotaoContext _context;

        public UnidadeBLL(ZeGotaoContext ctx)
        {
            _context = ctx;
        }

        public List<UnidadeDTO> GetAll()
        {
            return _context.Unidade
                .Select(u => new UnidadeDTO
                {
                    IdUnidade = u.IdUnidade,
                    NomeUnidade = u.NomeUnidade,
                    Endereco = u.Endereco,
                    Telefone = u.Telefone
                }).ToList();
        }
    }
}
