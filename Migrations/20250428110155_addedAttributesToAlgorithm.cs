using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaWebtool2.Migrations
{
    /// <inheritdoc />
    public partial class addedAttributesToAlgorithm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Algorithms",
                newName: "ModelUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelUrl",
                table: "Algorithms",
                newName: "ImageUrl");
        }
    }
}
