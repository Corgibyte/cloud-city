using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudCity.Migrations
{
    public partial class RecreateMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "Description", "Name" },
                values: new object[] { 1, "The upper levels of Cloud City are given over primarily to resorts, hotels, casinos, museums, theaters, boutiques, restaurants, and other attractions for the sector's well-to-do.", "Tourist District" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "Description", "Name" },
                values: new object[] { 2, "Immediately accessible from the majority of Cloud City's landing bays and platforms, Port Town occupies levels 121 through 160 of the facility.", "Port Town" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "Description", "Name" },
                values: new object[] { 3, "These regions consist of tibanna gas mining and processing equipment, including carbonite freezing facilities. The industrial levels also include the necessities for maintaining Cloud City's operations.", "Industrial District" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Description", "DistrictId", "Level", "Name" },
                values: new object[,]
                {
                    { 1, "In a city well known for its elegant, high-class hotels, the Yarith Bespin stands out as the most elegant and highest class of them all.", 1, 1, "The Yarith Bespin" },
                    { 2, "Figg Hall is a public space for visitors and residents to speak with representatives of Cloud City's government.", 1, 1, "Figg Hall" },
                    { 3, "Located on level 121, almost exactly in the center of Port Town, is a long, wide corridor that runs from the outermost edges of the Floating Home platform to the central shaft used as an semi-open marketplace.", 2, 121, "Market Row" },
                    { 4, "Located on level 124, Landing Bay 124A is in all respects a perfectly normal and average Port Town landing bay for Cloud City.", 2, 124, "Landing Bay 124A" },
                    { 5, "\"Finest speeders on Bespin! You can trust me, I'm Honest Grek!\"", 3, 128, "Honest Grek's Speeders" },
                    { 6, "Negri is an Ugnaught male who oversees the operations of Process Vane 5. Negri's vane is the least efficient vane in the entire complex, with the most unscheduled downtime for \"maintenance.\" In reality, Negri is perfectly willing to take a little money under the table to freeze anything a client might want in one of his carbonite sledges.", 3, 1, "Negri's Processing Vane" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DistrictId",
                table: "Locations",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
