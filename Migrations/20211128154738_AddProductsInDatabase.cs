using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Ecom.Migrations
{
    public partial class AddProductsInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Categories] ON;

            INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName])
                VALUES
                    (1, 'Family car');
                    
            SET IDENTITY_INSERT [dbo].[Categories] OFF;
            ");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
