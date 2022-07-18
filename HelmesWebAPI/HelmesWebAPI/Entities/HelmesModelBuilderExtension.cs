using Helmes.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelmesWebAPI.Entities
{
    public static class HelmesModelBuilderExtension
    {
        public static void Seed(this ModelBuilder hemlesModelBuilder) 
        {
            hemlesModelBuilder.Entity<Sector>().HasData(
              new Sector { ID = 1, Name = "Manufacturing", Pid = null, Description = "Manufacturing" },
              new Sector { ID = 2, Name = "Construction materials", Pid = 1, Description = "Construction materials" },
              new Sector { ID = 3, Name= "Electronics and Optics", Pid = 1, Description = "Electronics and Optics" },
              new Sector { ID = 4, Name = "Food and Beverage", Pid = 1, Description = "Food and Beverage" },
              new Sector { ID = 5, Name = "Bakery &amp; confectionery products", Pid = 4, Description = "Bakery &amp; confectionery products" },
              new Sector { ID = 6, Name = "Beverages", Pid = 4, Description = "Beverages" },
              new Sector { ID = 7, Name = "Fish &amp; fish products", Pid = 4, Description = "Fish &amp; fish products" },
              new Sector { ID = 8, Name = "Meat &amp; meat products", Pid = 4, Description = "Meat &amp; meat products" },
              new Sector { ID = 9, Name = "Milk &amp; dairy products", Pid = 4, Description = "Milk &amp; dairy products" },
              new Sector { ID = 10, Name = "Other", Pid = 4, Description = "Other" },
              new Sector { ID = 11, Name = "Sweets &amp; snack food", Pid = 4, Description = "Sweets &amp; snack food" },
              new Sector { ID = 12, Name = "Furniture", Pid = 1, Description = "Furniture" },
              new Sector { ID = 13, Name = "Bathroom/sauna", Pid = 12, Description = "Bathroom/sauna" },
              new Sector { ID = 14, Name = "Bedroom", Pid = 12, Description = "Bedroom" },
              new Sector { ID = 15, Name = "Children’s room", Pid = 12, Description = "Children’s room" },
              new Sector { ID = 16, Name = "Kitchen", Pid = 12, Description = "Kitchen" },
              new Sector { ID = 17, Name = "Living room", Pid = 12, Description = "Living room" },
              new Sector { ID = 18, Name = "Office", Pid = 12, Description = "Office" },
              new Sector { ID = 19, Name = "Other (Furniture)", Pid = 12, Description = "Other (Furniture)" },
              new Sector { ID = 20, Name = "Outdoor", Pid = 12, Description = "Outdoor" },
              new Sector { ID = 21, Name = "Project furniture", Pid = 12, Description = "Project furniture" },
              new Sector { ID = 22, Name = "Machinery", Pid = 1, Description = "Machinery" },
              new Sector { ID = 23, Name = "Machinery components", Pid = 22, Description = "Machinery components" },
              new Sector { ID = 24, Name = "Machinery equipment/tools", Pid = 22, Description = "Machinery equipment/tools" },
              new Sector { ID = 25, Name = "Manufacture of machinery", Pid = 22, Description = "Manufacture of machinery" },
              new Sector { ID = 26, Name = "Maritime", Pid = 22, Description = "Maritime" },
              new Sector { ID = 27, Name = "Aluminium and steel workboats", Pid = 26, Description = "Aluminium and steel workboats" },
              new Sector { ID = 28, Name = "Boat/Yacht building", Pid = 26, Description = "Boat/Yacht building" },
              new Sector { ID = 29, Name = "Ship repair and conversion", Pid = 26, Description = "Ship repair and conversion" },
              new Sector { ID = 30, Name = "Metal structures", Pid = 22, Description = "Metal structures" },
              new Sector { ID = 31, Name = "Other", Pid = 22, Description = "Other" },
              new Sector { ID = 32, Name = "Repair and maintenance service", Pid = 22, Description = "Repair and maintenance service" },
              new Sector { ID = 33, Name = "Metalworking", Pid = 1, Description = "Metalworking" },
              new Sector { ID = 34, Name = "Construction of metal structures", Pid = 33, Description = "Construction of metal structures" },
              new Sector { ID = 35, Name = "Houses and buildings", Pid = 33, Description = "Houses and buildings" },
              new Sector { ID = 36, Name = "Metal products", Pid = 33, Description = "Metal products" },
              new Sector { ID = 37, Name = "Metal works", Pid = 33, Description = "Metal works" },
              new Sector { ID = 38, Name = "CNC-machining", Pid = 37, Description = "CNC-machining" },
              new Sector { ID = 39, Name = "Forgings, Fasteners", Pid = 37, Description = "Forgings, Fasteners" },
              new Sector { ID = 40, Name = "Gas, Plasma, Laser cutting", Pid = 37, Description = "Gas, Plasma, Laser cutting" },
              new Sector { ID = 41, Name = "MIG, TIG, Aluminum welding", Pid = 37, Description = "MIG, TIG, Aluminum welding" },
              new Sector { ID = 42, Name = "Plastic and Rubber", Pid = 1, Description = "Plastic and Rubber" },
              new Sector { ID = 43, Name = "Packaging", Pid = 42, Description = "Packaging" },
              new Sector { ID = 44, Name = "Plastic goods", Pid = 42, Description = "Plastic goods" },
              new Sector { ID = 45, Name = "Plastic processing technology", Pid = 42, Description = "Plastic processing technology" },
              new Sector { ID = 46, Name = "Blowing", Pid = 45, Description = "Blowing" },
              new Sector { ID = 47, Name = "Moulding", Pid = 45, Description = "Moulding" },
              new Sector { ID = 48, Name = "Plastics welding and processing", Pid = 45, Description = "Plastics welding and processing" },
              new Sector { ID = 49, Name = "Plastic profiles", Pid = 42, Description = "Plastic profiles" },
              new Sector { ID = 50, Name = "Printing", Pid = 1, Description = "Printing" },
              new Sector { ID = 51, Name = "Advertising", Pid = 50, Description = "Advertising" },
              new Sector { ID = 52, Name = "Book/Periodicals printing", Pid = 50, Description = "Book/Periodicals printing" },
              new Sector { ID = 53, Name = "Labelling and packaging printing", Pid = 50, Description = "Labelling and packaging printing" },
              new Sector { ID = 54, Name = "Textile and Clothing", Pid = 1, Description = "Textile and Clothing" },
              new Sector { ID = 55, Name = "Clothing", Pid = 54, Description = "Clothing" },
              new Sector { ID = 56, Name = "Textile", Pid = 54, Description = "Textile" },
              new Sector { ID = 57, Name = "Wood", Pid = 1, Description = "Wood" },
              new Sector { ID = 58, Name = "Other (Wood)", Pid = 57, Description = "Other (Wood)" },
              new Sector { ID = 59, Name = "Wooden building materials", Pid = 57, Description = "Wooden building materials" },
              new Sector { ID = 60, Name = "Wooden houses", Pid = 57, Description = "Wooden houses" },
              new Sector { ID = 61, Name = "Other", Pid = null, Description = "Other" },
              new Sector { ID = 62, Name = "Creative industries", Pid = 61, Description = "Creative industries" },
              new Sector { ID = 63, Name = "Energy technology", Pid = 61, Description = "Energy technology" },
              new Sector { ID = 64, Name = "Environment", Pid = 61, Description = "Environment" },
              new Sector { ID = 65, Name = "Service", Pid = null, Description = "Service" },
              new Sector { ID = 66, Name = "Business services", Pid = 65, Description = "Business services" },
              new Sector { ID = 67, Name = "Engineering", Pid = 65, Description = "Engineering" },
              new Sector { ID = 68, Name = "Information Technology and Telecommunications", Pid = 65, Description = "Information Technology and Telecommunications" },
              new Sector { ID = 69, Name = "Data processing, Web portals, E-marketing", Pid = 68, Description = "Data processing, Web portals, E-marketing" },
              new Sector { ID = 70, Name = "Programming, Consultancy", Pid = 68, Description = "Programming, Consultancy" },
              new Sector { ID = 71, Name = "Software, Hardware", Pid = 68, Description = "Software, Hardware" },
              new Sector { ID = 72, Name = "Telecommunications", Pid = 68, Description = "Telecommunications" },
              new Sector { ID = 73, Name = "Tourism", Pid = 65, Description = "Tourism" },
              new Sector { ID = 74, Name = "Translation services", Pid = 65, Description = "Translation services" },
              new Sector { ID = 75, Name = "Transport and Logistics", Pid = 65, Description = "Transport and Logistics" },
              new Sector { ID = 76, Name = "Air", Pid = 75, Description = "Air" },
              new Sector { ID = 77, Name = "Rail", Pid = 75, Description = "Rail" },
              new Sector { ID = 78, Name = "Road", Pid = 75, Description = "Road" },
              new Sector { ID = 79, Name = "Water", Pid = 75, Description = "Water" }
              );
        }
    }
}
