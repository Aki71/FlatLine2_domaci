using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatLine.Data.Migrations
{
    /// <inheritdoc />
    public partial class shortdescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShprtDescription",
                table: "Course",
                newName: "ShortDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Course",
                newName: "ShprtDescription");
        }
    }
}
