using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZavaJApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationDefinitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDefinitionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FutureChildrenDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureChildrenDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeightDefinitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeightDefinitionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeritalStatusDefinitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeritalStatusDefinitionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrayDefinitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayDefinitionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionDefinitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionDefinitionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectDefinitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectDefinitionTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Userlatitude = table.Column<double>(type: "float", nullable: false),
                    UserLongitude = table.Column<double>(type: "float", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Selfie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    MeritalStatusId = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    PrayId = table.Column<int>(type: "int", nullable: false),
                    heightId = table.Column<int>(type: "int", nullable: false),
                    IsSmoke = table.Column<bool>(type: "bit", nullable: false),
                    IsAlocahal = table.Column<bool>(type: "bit", nullable: false),
                    IsHaveChildren = table.Column<bool>(type: "bit", nullable: false),
                    FutureChildrenId = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWantToMoveAbroad = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_EducationDefinitionTable_EducationId",
                        column: x => x.EducationId,
                        principalTable: "EducationDefinitionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_FutureChildrenDefinition_FutureChildrenId",
                        column: x => x.FutureChildrenId,
                        principalTable: "FutureChildrenDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_HeightDefinitionTable_heightId",
                        column: x => x.heightId,
                        principalTable: "HeightDefinitionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_MeritalStatusDefinitionTable_MeritalStatusId",
                        column: x => x.MeritalStatusId,
                        principalTable: "MeritalStatusDefinitionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_PrayDefinitionTable_PrayId",
                        column: x => x.PrayId,
                        principalTable: "PrayDefinitionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_ProfessionDefinitionTable_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "ProfessionDefinitionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_SectDefinitionTable_SectId",
                        column: x => x.SectId,
                        principalTable: "SectDefinitionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EducationId",
                table: "Users",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FutureChildrenId",
                table: "Users",
                column: "FutureChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_heightId",
                table: "Users",
                column: "heightId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MeritalStatusId",
                table: "Users",
                column: "MeritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrayId",
                table: "Users",
                column: "PrayId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfessionId",
                table: "Users",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SectId",
                table: "Users",
                column: "SectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EducationDefinitionTable");

            migrationBuilder.DropTable(
                name: "FutureChildrenDefinition");

            migrationBuilder.DropTable(
                name: "HeightDefinitionTable");

            migrationBuilder.DropTable(
                name: "MeritalStatusDefinitionTable");

            migrationBuilder.DropTable(
                name: "PrayDefinitionTable");

            migrationBuilder.DropTable(
                name: "ProfessionDefinitionTable");

            migrationBuilder.DropTable(
                name: "SectDefinitionTable");
        }
    }
}
