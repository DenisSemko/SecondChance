using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeTestQuestionLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyTest_Question_QuestionId",
                table: "DailyTest");

            migrationBuilder.DropIndex(
                name: "IX_DailyTest_QuestionId",
                table: "DailyTest");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "DailyTest");

            migrationBuilder.AddColumn<Guid>(
                name: "TestIdId",
                table: "Question",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "QuestionId",
                table: "DailyTest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyTest_QuestionId",
                table: "DailyTest",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTest_Question_QuestionId",
                table: "DailyTest",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
