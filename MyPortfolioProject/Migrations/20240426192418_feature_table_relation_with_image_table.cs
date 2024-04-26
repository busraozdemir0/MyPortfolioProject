using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioProject.Migrations
{
    public partial class feature_table_relation_with_image_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Features",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_ImageId",
                table: "Features",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Images_ImageId",
                table: "Features",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Images_ImageId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ImageId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Features");
        }
    }
}
