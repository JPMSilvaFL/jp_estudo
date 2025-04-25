using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agenda_api.Migrations
{
    /// <inheritdoc />
    public partial class TableUserFKConstrainsts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PerfilAcesso_PessoaId",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilAcessoId",
                table: "Usuario",
                column: "PerfilAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PerfilAcesso_PerfilAcessoId",
                table: "Usuario",
                column: "PerfilAcessoId",
                principalTable: "PerfilAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PerfilAcesso_PerfilAcessoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilAcessoId",
                table: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PerfilAcesso_PessoaId",
                table: "Usuario",
                column: "PessoaId",
                principalTable: "PerfilAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
