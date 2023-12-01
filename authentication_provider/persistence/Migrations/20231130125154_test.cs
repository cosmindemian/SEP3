using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailVerificationCode_Credentials_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailVerificationCode",
                schema: "authentication_provider",
                table: "EmailVerificationCode");

            migrationBuilder.RenameTable(
                name: "EmailVerificationCode",
                schema: "authentication_provider",
                newName: "EmailVerificationCodes",
                newSchema: "authentication_provider");

            migrationBuilder.RenameIndex(
                name: "IX_EmailVerificationCode_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCodes",
                newName: "IX_EmailVerificationCodes_CredentialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailVerificationCodes",
                schema: "authentication_provider",
                table: "EmailVerificationCodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailVerificationCodes_Credentials_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCodes",
                column: "CredentialId",
                principalSchema: "authentication_provider",
                principalTable: "Credentials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailVerificationCodes_Credentials_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailVerificationCodes",
                schema: "authentication_provider",
                table: "EmailVerificationCodes");

            migrationBuilder.RenameTable(
                name: "EmailVerificationCodes",
                schema: "authentication_provider",
                newName: "EmailVerificationCode",
                newSchema: "authentication_provider");

            migrationBuilder.RenameIndex(
                name: "IX_EmailVerificationCodes_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCode",
                newName: "IX_EmailVerificationCode_CredentialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailVerificationCode",
                schema: "authentication_provider",
                table: "EmailVerificationCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailVerificationCode_Credentials_CredentialId",
                schema: "authentication_provider",
                table: "EmailVerificationCode",
                column: "CredentialId",
                principalSchema: "authentication_provider",
                principalTable: "Credentials",
                principalColumn: "Id");
        }
    }
}
