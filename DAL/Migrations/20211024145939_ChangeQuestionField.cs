using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeQuestionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_DailyTest_TestIdId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_TestIdId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TestIdId",
                table: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "DailyTestId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_DailyTestId",
                table: "Question",
                column: "DailyTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_DailyTest_DailyTestId",
                table: "Question",
                column: "DailyTestId",
                principalTable: "DailyTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_DailyTest_DailyTestId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_DailyTestId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "DailyTestId",
                table: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "TestIdId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestIdId",
                table: "Question",
                column: "TestIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_DailyTest_TestIdId",
                table: "Question",
                column: "TestIdId",
                principalTable: "DailyTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
