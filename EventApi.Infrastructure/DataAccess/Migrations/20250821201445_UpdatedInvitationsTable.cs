using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventApi.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedInvitationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Invitations",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Invitations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Invitations");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Invitations",
                newName: "User");
        }
    }
}
