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
                        name: "FK_AppUserSurveys_Surveys_AppUserId",
                        column: x => x.AppUserId,
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
                    { 1, "4b30024e-cd2b-4f43-9708-c02adee10410", "Creator", "CREATOR" },
                    { 2, "d4936249-5e1d-46fe-b62a-e8ef3e27fddd", "Responder", "RESPONDER" },
                    { 3, "b6bccd98-d3b8-4d75-a589-215a3bbe55d9", "Analyzer", "ANALYZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "592efcfb-392f-4de3-bb20-db61a7123033", new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(9972), null, "creator@gmail.com", true, true, null, null, "Kemal", "CREATOR@GMAIL.COM", "CREATOR", "AQAAAAEAACcQAAAAELDR6PJsGBK4dDWRLBgH9X1mLcVVtrc8pKXYs1TqX/3beljvQDu5M2DMncxTgUsD4Q==", "5312292928", true, "545b31cf-8834-4f88-b9ed-c9ce1a6356f4", (byte)1, "Akcan", false, "Creator" },
                    { 2, 0, "5e3f0248-cbcf-4f74-a75b-ed9679bb96c2", new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(9984), null, "responder@gmail.com", true, true, null, null, "Sefa", "RESPONDER@GMAIL.COM", "RESPONDER", "AQAAAAEAACcQAAAAEMaF2QlpWU/c1kDaXqZaJ8oagm/IKqA/Mrq2WrwG1lgjzw7tcYbMY/R1X+elyWosEw==", "5446340539", true, "df54cbbe-6d19-49dc-ac6d-c76bfb8a097b", (byte)1, "Er", false, "Responder" },
                    { 3, 0, "dc3c2c3c-767e-4749-a2b9-39c0d9d882e9", new DateTime(2024, 1, 15, 15, 31, 8, 933, DateTimeKind.Local).AddTicks(1), null, "analyzer@gmail.com", true, true, null, null, "Bora", "ANALYZER@GMAIL.COM", "ANALYZER", "AQAAAAEAACcQAAAAENsCLvX/9tQfzFmV7aIZfVH0JvvCh6raq3pm9jDd7KTRdklfFPv9FzFI49aJiVoQiA==", "5446340539", true, "2733da78-ccaa-427c-99fd-8ffed787a198", (byte)1, "Öz", false, "Analyzer" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "ModifiedDate", "Score", "Status" },
                values: new object[,]
                {
                    { 1, "A", new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(8944), null, null, (byte)10, (byte)1 },
                    { 2, "B", new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(8948), null, null, (byte)6, (byte)1 },
                    { 3, "C", new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(8949), null, null, (byte)8, (byte)1 }
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
                values: new object[] { 1, 1, new DateTime(2024, 1, 15, 15, 31, 8, 937, DateTimeKind.Local).AddTicks(97), null, null, "İşyeri Memnuniyeti", (byte)1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "GroupId", "IsItAnswered", "ModifiedDate", "ParentQuestionId", "Status", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9702), null, 3, false, null, null, (byte)1, 1, "İş yerindeki genel çalışma ortamından ne kadar memnunsunuz?" },
                    { 2, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9705), null, 2, false, null, null, (byte)1, 1, "Takım arkadaşlarıyla iletişim ve işbirliği konusundaki deneyimleriniz nedir?" },
                    { 5, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9709), null, 3, false, null, null, (byte)1, 1, "Performans değerlendirmelerinizle ilgili olarak geribildirim almak konusundaki memnuniyetiniz nedir?" },
                    { 7, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9713), null, 2, false, null, null, (byte)1, 1, "İş yükü ve stres seviyeleriniz hakkında nasıl hissediyorsunuz?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "QuestionId", "Status", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1249), null, null, 1, (byte)1, "Çok memnunum" },
                    { 2, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1251), null, null, 1, (byte)1, "Memnun değilim" },
                    { 3, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1253), null, null, 2, (byte)1, "Mükemmel" },
                    { 4, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1254), null, null, 2, (byte)1, "İyileştirilebilir" },
                    { 9, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1260), null, null, 5, (byte)1, "Memnunum" },
                    { 10, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1262), null, null, 5, (byte)1, "Daha fazla geribildirim bekliyorum" },
                    { 13, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1265), null, null, 7, (byte)1, "Yönetilebilir" },
                    { 14, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1266), null, null, 7, (byte)1, "Yüksek" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "GroupId", "IsItAnswered", "ModifiedDate", "ParentQuestionId", "Status", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9707), null, 1, false, null, 2, (byte)1, 1, "Şirket tarafından sunulan eğitim ve gelişim fırsatlarından ne kadar faydalandınız?" },
                    { 4, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9708), null, 2, false, null, 2, (byte)1, 1, "Çalışma saatleri ve esneklik konusundaki beklentilerinizi karşılayabiliyor musunuz?" },
                    { 6, new DateTime(2024, 1, 15, 15, 31, 8, 936, DateTimeKind.Local).AddTicks(9711), null, 2, false, null, 5, (byte)1, 1, "İş güvenliği önlemleri ve çalışma ortamı konusunda endişeleriniz var mı?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "QuestionId", "Status", "Text" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1255), null, null, 3, (byte)1, "Çok fazla fayda sağladım" },
                    { 6, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1257), null, null, 3, (byte)1, "Yeterli değil" },
                    { 7, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1258), null, null, 4, (byte)1, "Evet, tam olarak" },
                    { 8, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1259), null, null, 4, (byte)1, "Hayır, daha fazla esneklik istiyorum" },
                    { 11, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1263), null, null, 6, (byte)1, "Hayır, güvenli hissediyorum" },
                    { 12, new DateTime(2024, 1, 15, 15, 31, 8, 932, DateTimeKind.Local).AddTicks(1264), null, null, 6, (byte)1, "Evet, iyileştirmeler yapılmalı" }
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
