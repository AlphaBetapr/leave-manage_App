using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_manage_App.Data.Migrations
{
    public partial class ChangeLeaveHistoriesToLeaveRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveHistories");

            migrationBuilder.AddColumn<string>(
                name: "DefaultDays",
                table: "LeaveTypeVM",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DefaultDays",
                table: "leaveTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "EmployeeVM",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    TaxId = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateJoined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "leaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingEmployeeId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    LeaveTypeId = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    DateActioned = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveRequests_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_leaveRequests_leaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveRequests_AspNetUsers_RequestingEmployeeId",
                        column: x => x.RequestingEmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EditLeaveAllocationVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(nullable: false),
                    LeaveTypeId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditLeaveAllocationVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditLeaveAllocationVM_EmployeeVM_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EditLeaveAllocationVM_LeaveTypeVM_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveAllocationVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    LeaveTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAllocationVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveAllocationVM_EmployeeVM_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveAllocationVM_LeaveTypeVM_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditLeaveAllocationVM_EmployeeId",
                table: "EditLeaveAllocationVM",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EditLeaveAllocationVM_LeaveTypeId",
                table: "EditLeaveAllocationVM",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocationVM_EmployeeId",
                table: "LeaveAllocationVM",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocationVM_LeaveTypeId",
                table: "LeaveAllocationVM",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_ApprovedById",
                table: "leaveRequests",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_LeaveTypeId",
                table: "leaveRequests",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_RequestingEmployeeId",
                table: "leaveRequests",
                column: "RequestingEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditLeaveAllocationVM");

            migrationBuilder.DropTable(
                name: "LeaveAllocationVM");

            migrationBuilder.DropTable(
                name: "leaveRequests");

            migrationBuilder.DropTable(
                name: "EmployeeVM");

            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "LeaveTypeVM");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultDays",
                table: "leaveTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "leaveHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateActioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveHistories_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_leaveHistories_leaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaveHistories_AspNetUsers_RequestingEmployeeId",
                        column: x => x.RequestingEmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaveHistories_ApprovedById",
                table: "leaveHistories",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_leaveHistories_LeaveTypeId",
                table: "leaveHistories",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveHistories_RequestingEmployeeId",
                table: "leaveHistories",
                column: "RequestingEmployeeId");
        }
    }
}
