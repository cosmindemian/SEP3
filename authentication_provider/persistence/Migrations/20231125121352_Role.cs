using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                schema: "authentication_provider",
                table: "Credentials",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "authentication_provider",
                table: "Credentials",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "authentication_provider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_RoleId",
                schema: "authentication_provider",
                table: "Credentials",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Roles_RoleId",
                schema: "authentication_provider",
                table: "Credentials",
                column: "RoleId",
                principalSchema: "authentication_provider",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Roles_RoleId",
                schema: "authentication_provider",
                table: "Credentials");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "authentication_provider");

            migrationBuilder.DropIndex(
                name: "IX_Credentials_RoleId",
                schema: "authentication_provider",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "authentication_provider",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "authentication_provider",
                table: "Credentials");
        }
    }
}
