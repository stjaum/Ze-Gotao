using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeGotao.Migrations
{
    /// <inheritdoc />
    public partial class seedUnidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Unidade (NomeUnidade, Endereco, Telefone) VALUES ('Unidade Central', 'Avenida Principal, 1000 - Centro, São Paulo - SP', '1133224455'),\r\n    ('Unidade Zona Norte', 'Rua das Orquídeas, 250 - Santana, São Paulo - SP', '11988776655'),\r\n    ('Unidade Zona Sul', 'Avenida das Nações, 780 - Santo Amaro, São Paulo - SP', '11999885544');\r\n ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
