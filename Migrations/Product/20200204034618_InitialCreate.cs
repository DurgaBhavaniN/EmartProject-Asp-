using Microsoft.EntityFrameworkCore.Migrations;

namespace EmartProject.Migrations.Product
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    i_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_id = table.Column<int>(nullable: false),
                    c_name = table.Column<string>(nullable: true),
                    sub_id = table.Column<int>(nullable: false),
                    sub_name = table.Column<string>(nullable: true),
                    gst = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    stk_num = table.Column<int>(nullable: false),
                    i_name = table.Column<string>(nullable: true),
                    s_id = table.Column<int>(nullable: false),
                    ItemPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.i_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
