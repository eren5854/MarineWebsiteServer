using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineWebsiteServer.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class entity_sinifi_duzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatdDate",
                table: "Homes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatdBy",
                table: "Homes",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatdDate",
                table: "HomeImages",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatdBy",
                table: "HomeImages",
                newName: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Homes",
                newName: "UpdatdDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Homes",
                newName: "UpdatdBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "HomeImages",
                newName: "UpdatdDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "HomeImages",
                newName: "UpdatdBy");
        }
    }
}
