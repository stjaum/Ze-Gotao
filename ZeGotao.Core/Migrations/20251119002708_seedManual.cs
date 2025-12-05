using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeGotao.Core.Migrations
{
    /// <inheritdoc />
    public partial class seedManual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO TipoUsuario (DescricaoTipoUsuario) VALUES ('Administrador'),('Usuario');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
