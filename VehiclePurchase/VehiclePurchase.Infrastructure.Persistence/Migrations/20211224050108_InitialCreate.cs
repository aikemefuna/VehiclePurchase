using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VehiclePurchase.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "VehicleBodyType",
                columns: table => new
                {
                    VehicleBodyTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    Premium = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodyType", x => x.VehicleBodyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    VehicleMakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    MakeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMake", x => x.VehicleMakeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    VehicleMakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehicleMake_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMake",
                        principalColumn: "VehicleMakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    VehicleMakeId = table.Column<int>(nullable: false),
                    VehicleModelId = table.Column<int>(nullable: false),
                    VehicleBodyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleBodyType_VehicleBodyTypeId",
                        column: x => x.VehicleBodyTypeId,
                        principalTable: "VehicleBodyType",
                        principalColumn: "VehicleBodyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleMake_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMake",
                        principalColumn: "VehicleMakeId",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "ThirdPartyPurchase",
                columns: table => new
                {
                    ThirdPartyPurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdPartyPurchase", x => x.ThirdPartyPurchaseId);
                    table.ForeignKey(
                        name: "FK_ThirdPartyPurchase_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyPurchase_VehicleId",
                table: "ThirdPartyPurchase",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleBodyTypeId",
                table: "Vehicle",
                column: "VehicleBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleMakeId",
                table: "Vehicle",
                column: "VehicleMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelId",
                table: "Vehicle",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleMakeId",
                table: "VehicleModel",
                column: "VehicleMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThirdPartyPurchase");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleBodyType");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleMake");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }
    }
}
