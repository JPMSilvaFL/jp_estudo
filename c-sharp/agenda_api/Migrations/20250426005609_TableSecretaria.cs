using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agenda_api.Migrations
{
    /// <inheritdoc />
    public partial class TableSecretaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuario",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.CreateTable(
                name: "Secretaria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFuncionario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSala = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretaria_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Secretaria_IdFuncionario",
                table: "Secretaria",
                column: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Secretaria");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuario",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");
        }
    }
}
