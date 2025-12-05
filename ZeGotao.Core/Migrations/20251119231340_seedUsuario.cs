using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace ZeGotao.Core.Migrations
{
    /// <inheritdoc />
    public partial class seedUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Usuario (Nome, Email, Senha, Cpf, Telefone, Endereco, DataNascimento, TipoUsuarioId, Ativo) VALUES ('João da Silva', 'joao.silva@email.com', 'senha123', '111.222.333-44', '11987654321', 'Rua das Flores, 101', '1990-05-12', 2, 0),\r\n('Maria Oliveira', 'maria.oliveira@email.com', 'senha456', '222.333.444-55', '21999887766', 'Av. Brasil, 202', '1987-03-25', 2, 1),\r\n('Carlos Pereira', 'carlos.pereira@email.com', 'senha789', '333.444.555-66', '11966554433', 'Rua Afonso Pena, 303', '1995-09-18', 2, 1),\r\n('Ana Souza', 'ana.souza@email.com', 'senha321', '444.555.666-77', '11988552233', 'Rua Lima Barreto, 404', '1992-12-10', 2, 0),\r\n('Pedro Gomes', 'pedro.gomes@email.com', 'senha654', '555.666.777-88', '21977441155', 'Av. Paulista, 1500', '1989-07-09', 2, 1),\r\n('Lucas Martins', 'lucas.martins@email.com', 'senha987', '666.777.888-99', '31998776655', 'Rua Amazonas, 55', '1993-04-17', 2, 1),\r\n('Juliana Costa', 'juliana.costa@email.com', 'senha159', '777.888.999-00', '11944332211', 'Rua do Sol, 77', '1997-10-02', 2, 1),\r\n('Fernanda Rocha', 'fernanda.rocha@email.com', 'senha753', '888.999.000-11', '21933445566', 'Av. Copacabana, 987', '1984-01-14', 2, 1),\r\n('Ricardo Alves', 'ricardo.alves@email.com', 'senha852', '999.000.111-22', '11955667788', 'Rua Imperial, 12', '1991-02-28', 2, 1),\r\n('Paula Mendes', 'paula.mendes@email.com', 'senha951', '000.111.222-33', '11966778899', 'Rua Paraná, 88', '1996-05-05', 2, 1),\r\n('Marcos Lima', 'marcos.lima@email.com', 'senha258', '123.456.789-01', '21999884455', 'Av. Rio Branco, 200', '1988-11-20', 2, 1),\r\n('Beatriz Silva', 'beatriz.silva@email.com', 'senha357', '987.654.321-00', '11933446677', 'Rua Horizonte, 600', '1994-03-12', 2, 1),\r\n('Thiago Mendes', 'thiago.mendes@email.com', 'senha147', '159.753.486-20', '31988776655', 'Rua Ouro Preto, 750', '1986-06-19', 2, 1),\r\n('Larissa Alves', 'larissa.alves@email.com', 'senha369', '258.456.789-66', '11922119933', 'Av. Independência, 1120', '1993-09-30', 2, 1),\r\n('Gustavo Ribeiro', 'gustavo.ribeiro@email.com', 'senha7894', '741.852.963-00', '21966558844', 'Rua Bela Vista, 44', '1992-07-22', 2, 1),\r\n('Camila Duarte', 'camila.duarte@email.com', 'senha9871', '852.963.741-20', '11944335522', 'Rua dos Lírios, 99', '1998-04-08', 2, 1),\r\n('Rafael Nogueira', 'rafael.nogueira@email.com', 'senha2580', '369.258.147-77', '21977668855', 'Av. Central, 3300', '1985-10-30', 2, 1),\r\n('Aline Ferreira', 'aline.ferreira@email.com', 'senha6540', '456.123.789-11', '31944332266', 'Rua Vitória, 120', '1999-12-01', 2, 1),\r\n('Eduardo Cardoso', 'edu.cardoso@email.com', 'senha7531', '753.159.852-44', '11998877665', 'Rua São João, 555', '1991-08-18', 2, 1),\r\n('Sabrina Castro', 'sabrina.castro@email.com', 'senha1597', '951.357.258-99', '21944337755', 'Rua Nova Era, 707', '1987-02-07', 2, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
