using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineWebsiteServer.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class about_sinifi_ve_image_sinifi_iliskisi_kuruldu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Abouts");

            migrationBuilder.AddColumn<Guid>(
                name: "AboutId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AboutId",
                table: "Images",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Abouts_AboutId",
                table: "Images",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Abouts_AboutId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AboutId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
