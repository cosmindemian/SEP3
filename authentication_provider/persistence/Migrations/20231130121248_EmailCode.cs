using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class EmailCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                schema: "authentication_provider",
                table: "Credentials",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EmailVerificationCode",
                schema: "authentication_provider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CredentialId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerificationCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerificationCode_Credentials_CredentialId",
                        column: x => x.CredentialId,
                        principalSchema: "authentication_provider",
                        principalTable: "Credentials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                schema: "authentication_provider",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerificationCode_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCode",
                column: "CredentialId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailVerificationCode",
                schema: "authentication_provider");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                schema: "authentication_provider",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                schema: "authentication_provider",
                table: "Credentials");
        }
    }
}
