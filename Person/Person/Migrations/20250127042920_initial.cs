using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Person_json.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });
            migrationBuilder.Sql(@"
            CREATE PROCEDURE InsertPerson
                @personData NVARCHAR(MAX)
            AS
            BEGIN
                DECLARE @firstName NVARCHAR(100), @lastName NVARCHAR(100), @email NVARCHAR(100);

                SET @firstName = JSON_VALUE(@personData, '$.FirstName');
                SET @lastName = JSON_VALUE(@personData, '$.LastName');
                SET @email = JSON_VALUE(@personData, '$.Email');

                INSERT INTO Persons (FirstName, LastName, Email)
                VALUES (@firstName, @lastName, @email);
            END
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
