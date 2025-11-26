using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeGotao.Core.Data;
using ZeGotao.DTO;

namespace ZeGotao.BLL
{
    public class DependenteUsuarioBLL
    {
        private readonly ZeGotaoContext _context;

        public DependenteUsuarioBLL(ZeGotaoContext ctx)
        {
            _context = ctx;
        }

        public List<DependenteUsuarioDTO> GetByUsuario(int idUsuario)
        {
            return _context.DependenteUsuario
                .Where(d => d.IdUsuario == idUsuario)
                .Select(d => new DependenteUsuarioDTO
                {
                    IdDependenteUsuario = d.IdDependenteUsuario,
                    IdUsuario = d.IdUsuario,
                    Nome = d.Nome,
                    Cpf = d.Cpf,
                    DataNascimento = d.DataNascimento
                })
                .ToList();
        }

        public void Add(DependenteUsuarioDTO dto)
        {
            var d = new DependenteUsuario
            {
                IdUsuario = dto.IdUsuario,
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento
            };

            _context.DependenteUsuario.Add(d);
            _context.SaveChanges();
        }
    }
}
