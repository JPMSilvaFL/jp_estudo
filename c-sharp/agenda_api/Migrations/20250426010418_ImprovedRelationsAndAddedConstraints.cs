using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agenda_api.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedRelationsAndAddedConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_IdPerson",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Pessoa_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Secretaria_Funcionario_IdFuncionario",
                table: "Secretaria");

            migrationBuilder.DropIndex(
                name: "IX_Secretaria_IdFuncionario",
                table: "Secretaria");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdPerson",
                table: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Secretaria_IdFuncionario",
                table: "Secretaria",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdPerson",
                table: "Cliente",
                column: "IdPerson",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa",
                table: "Cliente",
                column: "IdPerson",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Pessoa",
                table: "Funcionario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Secretaria_Funcionario",
                table: "Secretaria",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Pessoa",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Secretaria_Funcionario",
                table: "Secretaria");

            migrationBuilder.DropIndex(
                name: "IX_Secretaria_IdFuncionario",
                table: "Secretaria");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdPerson",
                table: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Secretaria_IdFuncionario",
                table: "Secretaria",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdPerson",
                table: "Cliente",
                column: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_IdPerson",
                table: "Cliente",
                column: "IdPerson",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Pessoa_PessoaId",
                table: "Funcionario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Secretaria_Funcionario_IdFuncionario",
                table: "Secretaria",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
