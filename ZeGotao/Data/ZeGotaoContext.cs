using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeGotao.Models;

namespace ZeGotao.Data
{
    public class ZeGotaoContext : DbContext
    {
        public ZeGotaoContext (DbContextOptions<ZeGotaoContext> options)
            : base(options)
        {
        }

        public DbSet<TipoUsuario> TipoUsuario { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<DependenteUsuario> DependenteUsuario { get; set; } = default!;
        public DbSet<Unidade> Unidade { get; set; } = default!;
        public DbSet<Vacinas> Vacinas { get; set; } = default!;
        public DbSet<Vacinacao> Vacinacao { get; set; } = default!;
    }



}
