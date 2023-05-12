using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomensTechForum.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateoffensiveprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Offensive",
                table: "PostThread",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfReports",
                table: "PostThread",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Offensive",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfReports",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfReports",
                table: "PostThread");

            migrationBuilder.DropColumn(
                name: "NoOfReports",
                table: "Post");

            migrationBuilder.AlterColumn<bool>(
                name: "Offensive",
                table: "PostThread",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Offensive",
                table: "Post",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
