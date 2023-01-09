using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorDeGastosMVC.Migrations
{
    /// <inheritdoc />
    public partial class criandotabelaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaNome",
                table: "Gastos");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Gastos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Gastos");

            migrationBuilder.AddColumn<string>(
                name: "PessoaNome",
                table: "Gastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
