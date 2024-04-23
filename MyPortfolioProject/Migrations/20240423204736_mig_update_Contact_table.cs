using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioProject.Migrations
{
    public partial class mig_update_Contact_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Phone2",
                table: "Contacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Phone1",
                table: "Contacts",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "Phone2");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "Phone1");

            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
