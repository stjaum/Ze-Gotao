using Microsoft.EntityFrameworkCore;
using ZeGotao.DTO;

namespace ZeGotao.DAL.Context
{
    public class ZeGotaoContext : DbContext
    {
        public ZeGotaoContext(DbContextOptions<ZeGotaoContext> options)
            : base(options) { }

        public DbSet<UsuarioDTO> Usuario { get; set; } = default;
        
    }
}

