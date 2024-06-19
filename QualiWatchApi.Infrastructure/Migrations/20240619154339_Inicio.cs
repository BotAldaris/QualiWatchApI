using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualiWatchApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Lote = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaAdicionado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoiAlertado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosAdicionados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosAdicionados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosMonitorados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PermaneciaEmEstoque = table.Column<int>(type: "int", nullable: false),
                    DiasAteRemocaoAposAlerta = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosMonitorados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Validades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiaAdicionado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validades_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Validades_ProdutoId",
                table: "Validades",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosAdicionados");

            migrationBuilder.DropTable(
                name: "ProdutosMonitorados");

            migrationBuilder.DropTable(
                name: "Validades");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
