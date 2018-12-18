using Microsoft.EntityFrameworkCore.Migrations;

namespace PassportCodeChallenge.Migrations
{
    public partial class arrayConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactoryChild");

            migrationBuilder.AddColumn<string>(
                name: "Children",
                table: "Factories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Children",
                table: "Factories");

            migrationBuilder.CreateTable(
                name: "FactoryChild",
                columns: table => new
                {
                    FactoryChildId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FactoryId = table.Column<int>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryChild", x => x.FactoryChildId);
                    table.ForeignKey(
                        name: "FK_FactoryChild_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "FactoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactoryChild_FactoryId",
                table: "FactoryChild",
                column: "FactoryId");
        }
    }
}
