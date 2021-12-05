using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeParentChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentChild_AspNetUsers_ChildIdId",
                table: "ParentChild");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentChild_AspNetUsers_ParentIdId",
                table: "ParentChild");

            migrationBuilder.DropIndex(
                name: "IX_ParentChild_ChildIdId",
                table: "ParentChild");

            migrationBuilder.DropIndex(
                name: "IX_ParentChild_ParentIdId",
                table: "ParentChild");

            migrationBuilder.DropColumn(
                name: "ChildIdId",
                table: "ParentChild");

            migrationBuilder.DropColumn(
                name: "ParentIdId",
                table: "ParentChild");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "ParentChild",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "ParentChild",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentChild_ChildId",
                table: "ParentChild",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentChild_ParentId",
                table: "ParentChild",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChild_AspNetUsers_ChildId",
                table: "ParentChild",
                column: "ChildId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChild_AspNetUsers_ParentId",
                table: "ParentChild",
                column: "ParentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentChild_AspNetUsers_ChildId",
                table: "ParentChild");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentChild_AspNetUsers_ParentId",
                table: "ParentChild");

            migrationBuilder.DropIndex(
                name: "IX_ParentChild_ChildId",
                table: "ParentChild");

            migrationBuilder.DropIndex(
                name: "IX_ParentChild_ParentId",
                table: "ParentChild");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "ParentChild");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ParentChild");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildIdId",
                table: "ParentChild",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentIdId",
                table: "ParentChild",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentChild_ChildIdId",
                table: "ParentChild",
                column: "ChildIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentChild_ParentIdId",
                table: "ParentChild",
                column: "ParentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChild_AspNetUsers_ChildIdId",
                table: "ParentChild",
                column: "ChildIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentChild_AspNetUsers_ParentIdId",
                table: "ParentChild",
                column: "ParentIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
