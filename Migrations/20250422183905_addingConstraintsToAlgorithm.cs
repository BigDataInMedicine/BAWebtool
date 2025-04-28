using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaWebtool2.Migrations
{
    /// <inheritdoc />
    public partial class addingConstraintsToAlgorithm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Constraints",
                table: "Algorithms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Derivations",
                table: "Algorithms",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Constraints",
                table: "Algorithms");

            migrationBuilder.DropColumn(
                name: "Derivations",
                table: "Algorithms");
        }
    }
}
