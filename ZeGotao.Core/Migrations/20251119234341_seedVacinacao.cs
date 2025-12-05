using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeGotao.Core.Migrations
{
    /// <inheritdoc />
    public partial class seedVacinacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Vacinacao (IdUsuario, IdVacina, IdUnidade, Status) VALUES (1, 1, 1, 1),\r\n(2, 3, 2, 1),\r\n(3, 5, 3, 0),\r\n(4, 2, 1, 1),\r\n(5, 7, 2, 1),\r\n(6, 10, 3, 0),\r\n(7, 4, 1, 1),\r\n(8, 6, 2, 1),\r\n(9, 12, 1, 0),\r\n(10, 8, 3, 1),\r\n(11, 15, 1, 1),\r\n(12, 9, 2, 0),\r\n(13, 11, 1, 1),\r\n(14, 16, 3, 1),\r\n(15, 13, 2, 0),\r\n(16, 19, 3, 1),\r\n(17, 14, 1, 1),\r\n(18, 20, 2, 0),\r\n(19, 18, 1, 1),\r\n(20, 22, 3, 1); ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
