using Microsoft.EntityFrameworkCore.Migrations;

namespace ReverseEngineeringDb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCompanyType",
                columns: table => new
                {
                    CompanyKey = table.Column<int>(nullable: false),
                    CompanyTypeKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCompanyType", x => new { x.CompanyKey, x.CompanyTypeKey });
                    table.ForeignKey(
                        name: "FK_CompanyCompanyType_Companies_CompanyKey",
                        column: x => x.CompanyKey,
                        principalTable: "Companies",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCompanyType_CompanyTypes_CompanyTypeKey",
                        column: x => x.CompanyTypeKey,
                        principalTable: "CompanyTypes",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCompanyType_CompanyTypeKey",
                table: "CompanyCompanyType",
                column: "CompanyTypeKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyCompanyType");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyTypes");
        }
    }
}
