using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    System = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE1A52B4D33F", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AdditionalData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityPage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole__3D978A354708CBD1", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRole_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "User",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_User_Guid",
                table: "User",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserGuid",
                table: "UserRole",
                column: "UserGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "UserActivityLog");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
