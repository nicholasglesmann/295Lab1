using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295NCommunityWebsiteNicholasGlesmann.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    MessagePriority = table.Column<string>(nullable: true),
                    MessageTitle = table.Column<string>(nullable: true),
                    MessageText = table.Column<string>(nullable: true),
                    IsResponse = table.Column<int>(nullable: false),
                    MessageID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Messages_MessageID1",
                        column: x => x.MessageID1,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ResponseTitle = table.Column<string>(nullable: true),
                    ResponseText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseID);
                });

            migrationBuilder.CreateTable(
                name: "SignificantPeople",
                columns: table => new
                {
                    SignificantPersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    StarCraftRace = table.Column<string>(nullable: true),
                    League = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignificantPeople", x => x.SignificantPersonID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageID1",
                table: "Messages",
                column: "MessageID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "SignificantPeople");
        }
    }
}
