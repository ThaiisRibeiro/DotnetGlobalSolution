using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GlobalSolutionBancoDotnet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DotnetGS_Contas_Energia",
                columns: table => new
                {
                    id_conta_energia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_preco_ecologico = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    quantidade_kwh = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    valor_gasto_real = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Valortotalecologico = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Valoreconomizado = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DotnetGS_Contas_Energia", x => x.id_conta_energia);
                });

            migrationBuilder.CreateTable(
                name: "DotnetGS_Preco_Ecologico",
                columns: table => new
                {
                    id_preco_ecologico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    valor_1kwh = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DotnetGS_Preco_Ecologico", x => x.id_preco_ecologico);
                });

            migrationBuilder.CreateTable(
                name: "DotnetGS_Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    login = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DotnetGS_Usuario", x => x.id_usuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DotnetGS_Contas_Energia");

            migrationBuilder.DropTable(
                name: "DotnetGS_Preco_Ecologico");

            migrationBuilder.DropTable(
                name: "DotnetGS_Usuario");
        }
    }
}
