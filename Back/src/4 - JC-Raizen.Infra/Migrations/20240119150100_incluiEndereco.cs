using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JC_Raizen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class incluiEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "Cliente",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "complemento",
                table: "Cliente",
                type: "VARCHAR(180)",
                maxLength: 180,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localidade",
                table: "Cliente",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "logradouro",
                table: "Cliente",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "Cliente",
                type: "VARCHAR(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "complemento",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "localidade",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "logradouro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "Cliente");
        }
    }
}
