using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dmail.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    EventStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventDuration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    SenderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mails_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spam",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BlockedUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spam", x => new { x.UserId, x.BlockedUserId });
                    table.ForeignKey(
                        name: "FK_Spam_Users_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spam_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    MailId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MailStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    EventResponse = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => new { x.MailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Receivers_Mails_MailId",
                        column: x => x.MailId,
                        principalTable: "Mails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "ante@gmail.com", "ante" },
                    { 2, "ivan@gmail.com", "ivan" },
                    { 3, "marko@gmail.com", "marko" },
                    { 4, "ana@gmail.com", "ana" },
                    { 5, "ana@gmail.com", "ana" },
                    { 6, "ivana@gmail.com", "ivana" }
                });

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "Id", "Content", "EventDuration", "EventStart", "SenderId", "SentAt", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Pozdrav, radi li sutra knjiznica?", null, null, 1, new DateTime(2022, 12, 1, 15, 0, 0, 0, DateTimeKind.Utc), "Upit", 0 },
                    { 2, "Kad cemo na kavu?", null, null, 1, new DateTime(2022, 11, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Kava", 0 },
                    { 3, "Kupio sam karte za oanj film o kojem smo pricali.", null, null, 2, new DateTime(2023, 1, 3, 15, 0, 0, 0, DateTimeKind.Utc), "Kino", 0 },
                    { 4, "Sretan Bozic!!!", null, null, 2, new DateTime(2022, 12, 25, 7, 0, 0, 0, DateTimeKind.Utc), "Cestitka", 0 },
                    { 5, "U privitku ti saljem dokumentaciju?", null, null, 3, new DateTime(2022, 12, 21, 15, 0, 0, 0, DateTimeKind.Utc), "Dokumentacija", 0 },
                    { 6, null, new TimeSpan(0, 4, 0, 0, 0), new DateTime(2023, 2, 1, 5, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2022, 12, 1, 3, 0, 0, 0, DateTimeKind.Utc), "Planinrenje", 1 },
                    { 7, null, new TimeSpan(0, 3, 0, 0, 0), new DateTime(2023, 1, 13, 12, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2022, 12, 1, 2, 0, 0, 0, DateTimeKind.Utc), "Predavanje", 1 },
                    { 8, null, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2023, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2022, 12, 1, 2, 0, 0, 0, DateTimeKind.Utc), "Nogometni termin", 1 },
                    { 9, null, new TimeSpan(0, 8, 0, 0, 0), new DateTime(2022, 12, 23, 20, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2022, 12, 10, 2, 0, 0, 0, DateTimeKind.Utc), "Docek Nove godine", 1 },
                    { 10, null, new TimeSpan(0, 4, 0, 0, 0), new DateTime(2023, 1, 18, 17, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2023, 1, 5, 2, 0, 0, 0, DateTimeKind.Utc), "Team Building", 1 }
                });

            migrationBuilder.InsertData(
                table: "Spam",
                columns: new[] { "BlockedUserId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId", "MailStatus" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId", "MailStatus" },
                values: new object[,]
                {
                    { 3, 1, 1 },
                    { 3, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId", "MailStatus" },
                values: new object[,]
                {
                    { 4, 5, 1 },
                    { 4, 6, 1 },
                    { 5, 1, 1 },
                    { 5, 2, 1 },
                    { 5, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId", "EventResponse" },
                values: new object[,]
                {
                    { 6, 3, 2 },
                    { 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId", "EventResponse" },
                values: new object[,]
                {
                    { 8, 2, 1 },
                    { 8, 4, 2 },
                    { 8, 5, 2 },
                    { 9, 2, 1 },
                    { 9, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId" },
                values: new object[] { 9, 5 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId", "EventResponse" },
                values: new object[] { 10, 2, 2 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "MailId", "UserId" },
                values: new object[,]
                {
                    { 10, 3 },
                    { 10, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mails_SenderId",
                table: "Mails",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_UserId",
                table: "Receivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Spam_BlockedUserId",
                table: "Spam",
                column: "BlockedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Spam");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
