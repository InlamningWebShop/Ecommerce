using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Migrations
{
    public partial class AddCustomerRoleToJane : Migration
    {
        const string ADMIN_USER_GUID = "7e602731-eb26-4646-b33b-75ae4fdd5a2e";
        const string ADMIN_ROLE_GUID = "a71d65a6-51a4-4ead-8461-e9dee07332e1";
        const string CUSTOMER_ROLE_GUID = "628dd256-26ba-4122-b9d3-cc6f9fe81855";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{CUSTOMER_ROLE_GUID}','Customer','CUSTOMER')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}','{CUSTOMER_ROLE_GUID}')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
