using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaWebtool2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Algorithms",
                columns: table => new
                {
                    AlgorithmId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    AlgorithmName = table.Column<string>(type: "TEXT", nullable: false),
                    AlgorithmDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Algorithms", x => x.AlgorithmId);
                });

            migrationBuilder.CreateTable(
                name: "DataPoints",
                columns: table => new
                {
                    DataPointId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataPointName = table.Column<string>(type: "TEXT", nullable: false),
                    DataPointDescription = table.Column<string>(type: "TEXT", nullable: false),
                    AtomicAttribute = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueSet = table.Column<string>(type: "TEXT", nullable: true),
                    DataPointCategory = table.Column<string>(type: "TEXT", nullable: true),
                    PatientType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoints", x => x.DataPointId);
                });

            migrationBuilder.CreateTable(
                name: "AlgorithmDataPoint",
                columns: table => new
                {
                    AlgorithmsAlgorithmId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataPointsDataPointId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgorithmDataPoint", x => new { x.AlgorithmsAlgorithmId, x.DataPointsDataPointId });
                    table.ForeignKey(
                        name: "FK_AlgorithmDataPoint_Algorithms_AlgorithmsAlgorithmId",
                        column: x => x.AlgorithmsAlgorithmId,
                        principalTable: "Algorithms",
                        principalColumn: "AlgorithmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlgorithmDataPoint_DataPoints_DataPointsDataPointId",
                        column: x => x.DataPointsDataPointId,
                        principalTable: "DataPoints",
                        principalColumn: "DataPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlgorithmDataPoint_DataPointsDataPointId",
                table: "AlgorithmDataPoint",
                column: "DataPointsDataPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgorithmDataPoint");

            migrationBuilder.DropTable(
                name: "Algorithms");

            migrationBuilder.DropTable(
                name: "DataPoints");
        }
    }
}
