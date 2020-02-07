using Microsoft.EntityFrameworkCore.Migrations;

namespace EmartProject.Migrations.Buyer
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    b_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    b_name = table.Column<string>(maxLength: 20, nullable: false),
                    b_pwd = table.Column<string>(nullable: true),
                    b_email_id = table.Column<string>(nullable: true),
                    b_phn = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.b_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
