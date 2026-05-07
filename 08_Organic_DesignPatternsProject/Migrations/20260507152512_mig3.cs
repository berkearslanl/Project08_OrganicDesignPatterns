using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _08_Organic_DesignPatternsProject.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeaturedProducts",
                columns: table => new
                {
                    FeaturedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedProducts", x => x.FeaturedProductId);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.GalleryId);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    QualityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageUrl = table.Column<int>(type: "int", nullable: false),
                    Item1Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item1Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item1ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item2Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item2Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item2ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item3Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item3Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item3ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item4Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item4Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item4ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.QualityId);
                });

            migrationBuilder.CreateTable(
                name: "SaleBanners",
                columns: table => new
                {
                    SaleBannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleBanners", x => x.SaleBannerId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Trends",
                columns: table => new
                {
                    TrendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trends", x => x.TrendId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturedProducts");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Qualities");

            migrationBuilder.DropTable(
                name: "SaleBanners");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Trends");
        }
    }
}
