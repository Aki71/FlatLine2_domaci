using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatLine.Data.Migrations
{
    /// <inheritdoc />
    public partial class jessir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Course",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureContentType",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureFileName",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ProfilePictureContentType",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ProfilePictureFileName",
                table: "Course");
        }
    }
}
