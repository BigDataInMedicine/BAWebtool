using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaWebtool2.Migrations
{
    /// <inheritdoc />
    public partial class EnumValuesInDataPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPointCategory",
                table: "DataPoints");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "DataPoints",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "DataPoints");

            migrationBuilder.AddColumn<string>(
                name: "DataPointCategory",
                table: "DataPoints",
                type: "TEXT",
                nullable: true);
        }
    }
}
