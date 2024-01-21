using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserSurveys",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSurveys", x => new { x.AppUserId, x.SurveyId });
                    table.ForeignKey(
                        name: "FK_AppUserSurveys_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserSurveys_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsItAnswered = table.Column<bool>(type: "bit", nullable: false),
                    ParentQuestionId = table.Column<int>(type: "int", nullable: true),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Questions_ParentQuestionId",
                        column: x => x.ParentQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAnswers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAnswers", x => new { x.AppUserId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_AppUserAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserAnswers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "468f9bee-b0cc-4bed-acfb-0846c210a137", "Creator", "CREATOR" },
                    { 2, "09daffee-ff04-41d1-aead-7eedca95fe30", "Responder", "RESPONDER" },
                    { 3, "8dec57d4-89a0-4f3c-8ddc-e404fa8f1ffa", "Analyzer", "ANALYZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b7f6dd10-cf9e-4c40-aefc-bfe5c4cfb4a7", new DateTime(2024, 1, 21, 21, 52, 51, 92, DateTimeKind.Local).AddTicks(5929), null, "creator@gmail.com", true, true, null, null, "Kemal", "CREATOR@GMAIL.COM", "CREATOR", "AQAAAAEAACcQAAAAEIQ3WAJ2Fpm3Wxn207ffi9OXYUbeGSKZ6lkFb4U9rairXJ2FBHhRcIUK1V5uWbr7XA==", "5312292928", true, "93601eac-ec99-477e-8047-1d97eb4daec9", (byte)1, "Akcan", false, "Creator" },
                    { 2, 0, "29d232cc-5f15-4dd7-8ba0-f8df082576df", new DateTime(2024, 1, 21, 21, 52, 51, 92, DateTimeKind.Local).AddTicks(5964), null, "responder@gmail.com", true, true, null, null, "Sefa", "RESPONDER@GMAIL.COM", "RESPONDER", "AQAAAAEAACcQAAAAEKQFlAEmqcUzmw37MiyjiaxERli8TKD0oMPaAs03dRk1Yq3vNy4C02Ca0upTPqOjwA==", "5446340539", true, "4665c646-a23f-4087-88ef-448add2ee2a2", (byte)1, "Er", false, "Responder" },
                    { 3, 0, "82e80d88-0ef5-49fb-96e6-bdfc7af3628a", new DateTime(2024, 1, 21, 21, 52, 51, 92, DateTimeKind.Local).AddTicks(5980), null, "analyzer@gmail.com", true, true, null, null, "Bora", "ANALYZER@GMAIL.COM", "ANALYZER", "AQAAAAEAACcQAAAAEN6X5/oCCvV6zd4uMXnQWddnboPsGgZoG1TQgAxuyc/BMDeX4nugQY2Beg8eD0+UlA==", "5446340539", true, "6b405c39-e284-4fd5-aee0-032c7610fed0", (byte)1, "Öz", false, "Analyzer" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "ModifiedDate", "Score", "Status" },
                values: new object[,]
                {
                    { 1, "A", new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(123), null, null, (byte)10, (byte)1 },
                    { 2, "B", new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(130), null, null, (byte)6, (byte)1 },
                    { 3, "C", new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(133), null, null, (byte)8, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Status" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(2218), null, null, "İşyeri Memnuniyeti", (byte)1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "GroupId", "IsItAnswered", "ModifiedDate", "ParentQuestionId", "Status", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1432), null, 3, false, null, null, (byte)1, 1, "İş yerindeki genel çalışma ortamından ne kadar memnunsunuz?" },
                    { 2, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1436), null, 2, false, null, null, (byte)1, 1, "Takım arkadaşlarıyla iletişim ve işbirliği konusundaki deneyimleriniz nedir?" },
                    { 5, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1444), null, 3, false, null, null, (byte)1, 1, "Performans değerlendirmelerinizle ilgili olarak geribildirim almak konusundaki memnuniyetiniz nedir?" },
                    { 7, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1452), null, 2, false, null, null, (byte)1, 1, "İş yükü ve stres seviyeleriniz hakkında nasıl hissediyorsunuz?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "QuestionId", "Status", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9888), null, null, 1, (byte)1, "Çok memnunum" },
                    { 2, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9893), null, null, 1, (byte)1, "Memnun değilim" },
                    { 3, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9896), null, null, 2, (byte)1, "Mükemmel" },
                    { 4, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9898), null, null, 2, (byte)1, "İyileştirilebilir" },
                    { 9, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9911), null, null, 5, (byte)1, "Memnunum" },
                    { 10, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9914), null, null, 5, (byte)1, "Daha fazla geribildirim bekliyorum" },
                    { 13, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9920), null, null, 7, (byte)1, "Yönetilebilir" },
                    { 14, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9922), null, null, 7, (byte)1, "Yüksek" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "GroupId", "IsItAnswered", "ModifiedDate", "ParentQuestionId", "Status", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1440), null, 1, false, null, 2, (byte)1, 1, "Şirket tarafından sunulan eğitim ve gelişim fırsatlarından ne kadar faydalandınız?" },
                    { 4, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1442), null, 2, false, null, 2, (byte)1, 1, "Çalışma saatleri ve esneklik konusundaki beklentilerinizi karşılayabiliyor musunuz?" },
                    { 6, new DateTime(2024, 1, 21, 21, 52, 51, 99, DateTimeKind.Local).AddTicks(1450), null, 2, false, null, 5, (byte)1, 1, "İş güvenliği önlemleri ve çalışma ortamı konusunda endişeleriniz var mı?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "QuestionId", "Status", "Text" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9900), null, null, 3, (byte)1, "Çok fazla fayda sağladım" },
                    { 6, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9904), null, null, 3, (byte)1, "Yeterli değil" },
                    { 7, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9907), null, null, 4, (byte)1, "Evet, tam olarak" },
                    { 8, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9909), null, null, 4, (byte)1, "Hayır, daha fazla esneklik istiyorum" },
                    { 11, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9916), null, null, 6, (byte)1, "Hayır, güvenli hissediyorum" },
                    { 12, new DateTime(2024, 1, 21, 21, 52, 51, 91, DateTimeKind.Local).AddTicks(9918), null, null, 6, (byte)1, "Evet, iyileştirmeler yapılmalı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAnswers_AnswerId",
                table: "AppUserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSurveys_SurveyId",
                table: "AppUserSurveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GroupId",
                table: "Questions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ParentQuestionId",
                table: "Questions",
                column: "ParentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CreatedBy",
                table: "Surveys",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAnswers");

            migrationBuilder.DropTable(
                name: "AppUserSurveys");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
