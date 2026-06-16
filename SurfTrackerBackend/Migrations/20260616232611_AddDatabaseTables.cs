using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Surfboards",
                columns: table => new
                {
                    SurfboardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surfboards", x => x.SurfboardId);
                    table.ForeignKey(
                        name: "FK_Surfboards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurfSpots",
                columns: table => new
                {
                    SurfSpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfSpots", x => x.SurfSpotId);
                    table.ForeignKey(
                        name: "FK_SurfSpots_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurfSessions",
                columns: table => new
                {
                    SurfSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurfboardId = table.Column<int>(type: "int", nullable: false),
                    SurfSpotId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfSessions", x => x.SurfSessionId);
                    table.ForeignKey(
                        name: "FK_SurfSessions_SurfSpots_SurfSpotId",
                        column: x => x.SurfSpotId,
                        principalTable: "SurfSpots",
                        principalColumn: "SurfSpotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurfSessions_Surfboards_SurfboardId",
                        column: x => x.SurfboardId,
                        principalTable: "Surfboards",
                        principalColumn: "SurfboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurfSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurfSessionSwell",
                columns: table => new
                {
                    SurfSessionSwellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfSessionId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaveHeight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WavePeriod = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WaveDirection = table.Column<int>(type: "int", nullable: true),
                    SwellWaveHeight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    SwellWavePeriod = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    SwellWaveDirection = table.Column<int>(type: "int", nullable: true),
                    WindWaveHeight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WindWavePeriod = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WindWaveDirection = table.Column<int>(type: "int", nullable: true),
                    SecondarySwellWaveHeight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    SecondarySwellWavePeriod = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    SecondarySwellWaveDirection = table.Column<int>(type: "int", nullable: true),
                    SeaLevelHeightMsl = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    SeaSurfaceTemperature = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    OceanCurrentVelocity = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    OceanCurrentDirection = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfSessionSwell", x => x.SurfSessionSwellId);
                    table.ForeignKey(
                        name: "FK_SurfSessionSwell_SurfSessions_SurfSessionId",
                        column: x => x.SurfSessionId,
                        principalTable: "SurfSessions",
                        principalColumn: "SurfSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurfSessionUserObservations",
                columns: table => new
                {
                    SurfSessionUserObservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfSessionId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfSessionUserObservations", x => x.SurfSessionUserObservationId);
                    table.ForeignKey(
                        name: "FK_SurfSessionUserObservations_SurfSessions_SurfSessionId",
                        column: x => x.SurfSessionId,
                        principalTable: "SurfSessions",
                        principalColumn: "SurfSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurfSessionWeather",
                columns: table => new
                {
                    SurfSessionWeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfSessionId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature2m = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WeatherCode = table.Column<int>(type: "int", nullable: true),
                    CloudCover = table.Column<int>(type: "int", nullable: true),
                    WindSpeed10m = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WindDirection10m = table.Column<int>(type: "int", nullable: true),
                    UvIndex = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Precipitation = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfSessionWeather", x => x.SurfSessionWeatherId);
                    table.ForeignKey(
                        name: "FK_SurfSessionWeather_SurfSessions_SurfSessionId",
                        column: x => x.SurfSessionId,
                        principalTable: "SurfSessions",
                        principalColumn: "SurfSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surfboards_UserId",
                table: "Surfboards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurfSessions_SurfboardId",
                table: "SurfSessions",
                column: "SurfboardId");

            migrationBuilder.CreateIndex(
                name: "IX_SurfSessions_SurfSpotId",
                table: "SurfSessions",
                column: "SurfSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_SurfSessions_UserId",
                table: "SurfSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurfSessionSwell_SurfSessionId_Time",
                table: "SurfSessionSwell",
                columns: new[] { "SurfSessionId", "Time" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurfSessionUserObservations_SurfSessionId",
                table: "SurfSessionUserObservations",
                column: "SurfSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurfSessionWeather_SurfSessionId_Time",
                table: "SurfSessionWeather",
                columns: new[] { "SurfSessionId", "Time" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurfSpots_UserId",
                table: "SurfSpots",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurfSessionSwell");

            migrationBuilder.DropTable(
                name: "SurfSessionUserObservations");

            migrationBuilder.DropTable(
                name: "SurfSessionWeather");

            migrationBuilder.DropTable(
                name: "SurfSessions");

            migrationBuilder.DropTable(
                name: "SurfSpots");

            migrationBuilder.DropTable(
                name: "Surfboards");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
