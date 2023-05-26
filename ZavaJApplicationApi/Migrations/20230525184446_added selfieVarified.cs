using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZavaJApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class addedselfieVarified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelfieVarified",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelfieVarified",
                table: "Users");
        }
    }
}
