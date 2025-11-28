using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeGotao.Core.Data;
using ZeGotao.DTO;

namespace ZeGotao.BLL
{
    public class TipoUsuarioBLL
    {
        private readonly ZeGotaoContext _context;

        public TipoUsuarioBLL(ZeGotaoContext ctx)
        {
            _context = ctx;
        }

        public List<TipoUsuarioDTO> GetAll()
        {
            return _context.TipoUsuario
                .Select(t => new TipoUsuarioDTO
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    DescricaoTipoUsuario = t.DescricaoTipoUsuario
                })
                .ToList();
        }
    }
}
