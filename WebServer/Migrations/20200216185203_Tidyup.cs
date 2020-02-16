using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServer.Migrations
{
    public partial class Tidyup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId1",
                table: "Reviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ItemId1",
                table: "Reviews",
                column: "ItemId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Reviews_Items_ItemId1",
            //    table: "Reviews",
            //    column: "ItemId1",
            //    principalTable: "Items",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Reviews_Items_ItemId1",
            //    table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ItemId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "Reviews");
        }
    }
}
