using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelmesWebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorsIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAgreeToTerms = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "Sector",
                columns: new[] { "ID", "Description", "Name", "Pid" },
                values: new object[,]
                {
                    { 1, "Manufacturing", "Manufacturing", null },
                    { 57, "Wood", "Wood", 1 },
                    { 56, "Textile", "Textile", 54 },
                    { 55, "Clothing", "Clothing", 54 },
                    { 54, "Textile and Clothing", "Textile and Clothing", 1 },
                    { 53, "Labelling and packaging printing", "Labelling and packaging printing", 50 },
                    { 52, "Book/Periodicals printing", "Book/Periodicals printing", 50 },
                    { 51, "Advertising", "Advertising", 50 },
                    { 58, "Other (Wood)", "Other (Wood)", 57 },
                    { 50, "Printing", "Printing", 1 },
                    { 48, "Plastics welding and processing", "Plastics welding and processing", 45 },
                    { 47, "Moulding", "Moulding", 45 },
                    { 46, "Blowing", "Blowing", 45 },
                    { 45, "Plastic processing technology", "Plastic processing technology", 42 },
                    { 44, "Plastic goods", "Plastic goods", 42 },
                    { 43, "Packaging", "Packaging", 42 },
                    { 42, "Plastic and Rubber", "Plastic and Rubber", 1 },
                    { 49, "Plastic profiles", "Plastic profiles", 42 },
                    { 41, "MIG, TIG, Aluminum welding", "MIG, TIG, Aluminum welding", 37 },
                    { 59, "Wooden building materials", "Wooden building materials", 57 },
                    { 61, "Other", "Other", null },
                    { 77, "Rail", "Rail", 75 },
                    { 76, "Air", "Air", 75 },
                    { 75, "Transport and Logistics", "Transport and Logistics", 65 },
                    { 74, "Translation services", "Translation services", 65 },
                    { 73, "Tourism", "Tourism", 65 },
                    { 72, "Telecommunications", "Telecommunications", 68 },
                    { 71, "Software, Hardware", "Software, Hardware", 68 },
                    { 60, "Wooden houses", "Wooden houses", 57 },
                    { 70, "Programming, Consultancy", "Programming, Consultancy", 68 },
                    { 68, "Information Technology and Telecommunications", "Information Technology and Telecommunications", 65 },
                    { 67, "Engineering", "Engineering", 65 },
                    { 66, "Business services", "Business services", 65 },
                    { 65, "Service", "Service", null },
                    { 64, "Environment", "Environment", 61 },
                    { 63, "Energy technology", "Energy technology", 61 },
                    { 62, "Creative industries", "Creative industries", 61 },
                    { 69, "Data processing, Web portals, E-marketing", "Data processing, Web portals, E-marketing", 68 },
                    { 78, "Road", "Road", 75 },
                    { 40, "Gas, Plasma, Laser cutting", "Gas, Plasma, Laser cutting", 37 },
                    { 38, "CNC-machining", "CNC-machining", 37 },
                    { 17, "Living room", "Living room", 12 }
                });

            migrationBuilder.InsertData(
                table: "Sector",
                columns: new[] { "ID", "Description", "Name", "Pid" },
                values: new object[,]
                {
                    { 16, "Kitchen", "Kitchen", 12 },
                    { 15, "Children’s room", "Children’s room", 12 },
                    { 14, "Bedroom", "Bedroom", 12 },
                    { 13, "Bathroom/sauna", "Bathroom/sauna", 12 },
                    { 12, "Furniture", "Furniture", 1 },
                    { 11, "Sweets &amp; snack food", "Sweets &amp; snack food", 4 },
                    { 18, "Office", "Office", 12 },
                    { 10, "Other", "Other", 4 },
                    { 8, "Meat &amp; meat products", "Meat &amp; meat products", 4 },
                    { 7, "Fish &amp; fish products", "Fish &amp; fish products", 4 },
                    { 6, "Beverages", "Beverages", 4 },
                    { 5, "Bakery &amp; confectionery products", "Bakery &amp; confectionery products", 4 },
                    { 4, "Food and Beverage", "Food and Beverage", 1 },
                    { 3, "Electronics and Optics", "Electronics and Optics", 1 },
                    { 2, "Construction materials", "Construction materials", 1 },
                    { 9, "Milk &amp; dairy products", "Milk &amp; dairy products", 4 },
                    { 39, "Forgings, Fasteners", "Forgings, Fasteners", 37 },
                    { 19, "Other (Furniture)", "Other (Furniture)", 12 },
                    { 21, "Project furniture", "Project furniture", 12 },
                    { 37, "Metal works", "Metal works", 33 },
                    { 36, "Metal products", "Metal products", 33 },
                    { 35, "Houses and buildings", "Houses and buildings", 33 },
                    { 34, "Construction of metal structures", "Construction of metal structures", 33 },
                    { 33, "Metalworking", "Metalworking", 1 },
                    { 32, "Repair and maintenance service", "Repair and maintenance service", 22 },
                    { 31, "Other", "Other", 22 },
                    { 20, "Outdoor", "Outdoor", 12 },
                    { 30, "Metal structures", "Metal structures", 22 },
                    { 28, "Boat/Yacht building", "Boat/Yacht building", 26 },
                    { 27, "Aluminium and steel workboats", "Aluminium and steel workboats", 26 },
                    { 26, "Maritime", "Maritime", 22 },
                    { 25, "Manufacture of machinery", "Manufacture of machinery", 22 },
                    { 24, "Machinery equipment/tools", "Machinery equipment/tools", 22 },
                    { 23, "Machinery components", "Machinery components", 22 },
                    { 22, "Machinery", "Machinery", 1 },
                    { 29, "Ship repair and conversion", "Ship repair and conversion", 26 },
                    { 79, "Water", "Water", 75 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
