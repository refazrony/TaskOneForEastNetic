using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskOne.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderid);
                });

            migrationBuilder.CreateTable(
                name: "windows",
                columns: table => new
                {
                    winId = table.Column<int>(type: "int", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    WindowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityOfWindows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSubElements = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_windows", x => x.winId);
                    table.ForeignKey(
                        name: "FK_windows_Orders_orderid",
                        column: x => x.orderid,
                        principalTable: "Orders",
                        principalColumn: "orderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubElement",
                columns: table => new
                {
                    SubElementID = table.Column<int>(type: "int", nullable: false),
                    winId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElement", x => x.SubElementID);
                    table.ForeignKey(
                        name: "FK_SubElement_windows_winId",
                        column: x => x.winId,
                        principalTable: "windows",
                        principalColumn: "winId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubElement_winId",
                table: "SubElement",
                column: "winId");

            migrationBuilder.CreateIndex(
                name: "IX_windows_orderid",
                table: "windows",
                column: "orderid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubElement");

            migrationBuilder.DropTable(
                name: "windows");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
