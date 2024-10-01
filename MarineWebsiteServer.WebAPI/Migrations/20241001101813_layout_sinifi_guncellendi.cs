using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineWebsiteServer.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class layout_sinifi_guncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Layouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Layouts");
        }
    }
}
