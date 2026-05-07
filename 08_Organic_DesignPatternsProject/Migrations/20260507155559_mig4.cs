using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _08_Organic_DesignPatternsProject.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "FeaturedProducts");

            migrationBuilder.RenameColumn(
                name: "ImageUrl2",
                table: "FeaturedProducts",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "FeaturedProducts",
                newName: "ImageUrl2");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "FeaturedProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
