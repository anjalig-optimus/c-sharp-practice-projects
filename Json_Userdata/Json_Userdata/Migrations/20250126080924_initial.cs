using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Json_Userdata.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
            migrationBuilder.Sql(@"
            CREATE PROCEDURE InsertUser
                @userData NVARCHAR(MAX)
            AS
            BEGIN
                DECLARE @firstName NVARCHAR(100), @lastName NVARCHAR(100), @email NVARCHAR(100);

                SET @firstName = JSON_VALUE(@userData, '$.FirstName');
                SET @lastName = JSON_VALUE(@userData, '$.LastName');
                SET @email = JSON_VALUE(@userData, '$.Email');

                -- Insert the new user
                INSERT INTO Users (FirstName, LastName, Email)
                VALUES (@firstName, @lastName, @email);
            END
        ");
            string userData = @"{""FirstName"": ""John"", ""LastName"": ""Doe"", ""Email"": ""john.doe@example.com""}";
            migrationBuilder.Sql($"EXEC spInsertUserData @inputjson = N'{inputjson}'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
