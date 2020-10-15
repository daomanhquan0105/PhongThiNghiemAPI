using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongThiNghiem.Migrations
{
    public partial class updateTableThietBi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ThietBis",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ThietBis");
        }
    }
}
