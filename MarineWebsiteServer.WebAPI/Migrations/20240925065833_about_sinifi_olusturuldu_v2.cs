using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineWebsiteServer.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class about_sinifi_olusturuldu_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text1",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Text2",
                table: "Abouts",
                newName: "Text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Abouts",
                newName: "Text2");

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
