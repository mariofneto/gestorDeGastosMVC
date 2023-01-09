using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorDeGastosMVC.Migrations
{
    /// <inheritdoc />
    public partial class tabelapessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_PessoaId",
                table: "Gastos",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Pessoas_PessoaId",
                table: "Gastos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Pessoas_PessoaId",
                table: "Gastos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_PessoaId",
                table: "Gastos");
        }
    }
}
