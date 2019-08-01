using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServer.Migrations
{
    public partial class ReviewsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Review_AspNetUsers_CreatedById",
            //     table: "Review");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Review_Items_ItemId",
            //     table: "Review");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Review_AspNetUsers_UpdatedById",
            //     table: "Review");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_Review",
            //     table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UpdatedById",
                table: "Reviews",
                newName: "IX_Reviews_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ItemId",
                table: "Reviews",
                newName: "IX_Reviews_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_CreatedById",
                table: "Reviews",
                newName: "IX_Reviews_CreatedById");

            // migrationBuilder.AlterColumn<string>(
            //     name: "Title",
            //     table: "Items",
            //     maxLength: 100,
            //     nullable: false,
            //     oldClrType: typeof(string),
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "Name",
            //     table: "Items",
            //     maxLength: 100,
            //     nullable: false,
            //     oldClrType: typeof(string),
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "Description",
            //     table: "Items",
            //     maxLength: 3000,
            //     nullable: false,
            //     oldClrType: typeof(string),
            //     oldNullable: true);

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_Reviews",
            //     table: "Reviews",
            //     column: "Id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Reviews_AspNetUsers_CreatedById",
            //     table: "Reviews",
            //     column: "CreatedById",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Reviews_Items_ItemId",
            //     table: "Reviews",
            //     column: "ItemId",
            //     principalTable: "Items",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Reviews_AspNetUsers_UpdatedById",
            //     table: "Reviews",
            //     column: "UpdatedById",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Reviews_AspNetUsers_CreatedById",
            //     table: "Reviews");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Reviews_Items_ItemId",
            //     table: "Reviews");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Reviews_AspNetUsers_UpdatedById",
            //     table: "Reviews");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_Reviews",
            //     table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UpdatedById",
                table: "Review",
                newName: "IX_Review_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ItemId",
                table: "Review",
                newName: "IX_Review_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CreatedById",
                table: "Review",
                newName: "IX_Review_CreatedById");

            // migrationBuilder.AlterColumn<string>(
            //     name: "Title",
            //     table: "Items",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldMaxLength: 100);

            // migrationBuilder.AlterColumn<string>(
            //     name: "Name",
            //     table: "Items",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldMaxLength: 100);

            // migrationBuilder.AlterColumn<string>(
            //     name: "Description",
            //     table: "Items",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldMaxLength: 3000);

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_Review",
            //     table: "Review",
            //     column: "Id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Review_AspNetUsers_CreatedById",
            //     table: "Review",
            //     column: "CreatedById",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Review_Items_ItemId",
            //     table: "Review",
            //     column: "ItemId",
            //     principalTable: "Items",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Review_AspNetUsers_UpdatedById",
            //     table: "Review",
            //     column: "UpdatedById",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }
    }
}
