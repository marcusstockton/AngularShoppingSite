using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServer.Migrations
{
    public partial class AddingItemModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryOptionId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemConditionId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sold",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DeliveryOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOptions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryOptions_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCategories_ItemCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCategories_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: false),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemConditions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemConditions_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_DeliveryOptionId",
                table: "Items",
                column: "DeliveryOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemConditionId",
                table: "Items",
                column: "ItemConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOptions_CreatedById",
                table: "DeliveryOptions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOptions_UpdatedById",
                table: "DeliveryOptions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CreatedById",
                table: "ItemCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_ParentCategoryId",
                table: "ItemCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_UpdatedById",
                table: "ItemCategories",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConditions_CreatedById",
                table: "ItemConditions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConditions_UpdatedById",
                table: "ItemConditions",
                column: "UpdatedById");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Items_DeliveryOptions_DeliveryOptionId",
            //    table: "Items",
            //    column: "DeliveryOptionId",
            //    principalTable: "DeliveryOptions",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Items_ItemConditions_ItemConditionId",
            //    table: "Items",
            //    column: "ItemConditionId",
            //    principalTable: "ItemConditions",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_DeliveryOptions_DeliveryOptionId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemConditions_ItemConditionId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "DeliveryOptions");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "ItemConditions");

            migrationBuilder.DropIndex(
                name: "IX_Items_DeliveryOptionId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemConditionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DeliveryOptionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemConditionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Sold",
                table: "Items");
        }
    }
}
