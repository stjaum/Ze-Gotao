using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using ZeGotao.Models;

#nullable disable

namespace ZeGotao.Migrations
{
    /// <inheritdoc />
    public partial class seedDependenteUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DependenteUsuario (IdUsuario, Nome, Cpf, DataNascimento)  VALUES (1, 'Lucas da Silva', '123.456.789-10', '2012-04-15'),\r\n    (2, 'Mariana Oliveira', '987.654.321-00', '2015-09-22'),\r\n    (3, 'Pedro Henrique', '456.789.123-55', '2010-01-30'),\r\n    (4, 'Ana Clara', '321.654.987-44', '2013-06-05'),\r\n    (5, 'Gabriel Santos', '159.753.486-20', '2011-12-19');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
