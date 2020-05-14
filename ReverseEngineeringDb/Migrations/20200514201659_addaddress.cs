using Microsoft.EntityFrameworkCore.Migrations;

namespace ReverseEngineeringDb.Migrations
{
    public partial class addaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    CompanyKey = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.CompanyKey);
                    table.ForeignKey(
                        name: "FK_Address_Companies_CompanyKey",
                        column: x => x.CompanyKey,
                        principalTable: "Companies",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
