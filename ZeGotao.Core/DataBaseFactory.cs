using Microsoft.EntityFrameworkCore;
using ZeGotao.Core.Data;

namespace ZeGotao.Core
{
    public static class DbFactory
    {
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=ZeGotao;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static ZeGotaoContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ZeGotaoContext>();

            // adicionando o provider SQL Server
            optionsBuilder.UseSqlServer(ConnectionString);

            return new ZeGotaoContext(optionsBuilder.Options);
        }
    }
}