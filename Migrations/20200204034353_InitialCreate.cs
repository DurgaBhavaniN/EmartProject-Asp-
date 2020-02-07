using Microsoft.EntityFrameworkCore.Migrations;

namespace EmartProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    s_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_name = table.Column<string>(maxLength: 20, nullable: false),
                    s_pwd = table.Column<string>(nullable: true),
                    s_emailid = table.Column<string>(nullable: true),
                    gstin = table.Column<double>(nullable: false),
                    bank_details = table.Column<string>(nullable: true),
                    Photpath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.s_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
