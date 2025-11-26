using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Core.Data;
using ZeGotao.DTO;

namespace ZeGotao.BLL
{
    public class VacinacaoBLL
    {
        private readonly ZeGotaoContext _context;

        public VacinacaoBLL(ZeGotaoContext ctx)
        {
            _context = ctx;
        }

        public List<VacinacaoDTO> GetAll()
        {
            return _context.Vacinacao
                .Include(v => v.Usuario)
                .Include(v => v.Vacina)
                .Include(v => v.Unidade)
                .Select(v => new VacinacaoDTO
                {
                    IdVacinacao = v.IdVacinacao,
                    IdUsuario = v.IdUsuario,
                    IdVacina = v.IdVacina,
                    IdUnidade = v.IdUnidade,
                    Status = v.Status,
                    NomeUsuario = v.Usuario.Nome,
                    NomeVacina = v.Vacina.NomeVacina,
                    NomeUnidade = v.Unidade.NomeUnidade
                })
                .ToList();
        }
    }
}
