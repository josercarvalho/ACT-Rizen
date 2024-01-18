using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JC_Raizen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class passwordTOdatanascimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Cliente",
                newName: "datanascimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "datanascimento",
                table: "Cliente",
                newName: "password");
        }
    }
}
