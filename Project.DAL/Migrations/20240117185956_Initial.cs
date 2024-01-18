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
                    { 1, "17304d73-b058-4c7a-8fdc-95533d1c8918", "Creator", "CREATOR" },
                    { 2, "e18f4fa5-07dd-4553-8da4-4d7e9f741a3e", "Responder", "RESPONDER" },
                    { 3, "535bc100-abc2-4cba-85e1-bad29d1238f3", "Analyzer", "ANALYZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a8647d30-7d91-499a-9435-2e09b7830486", new DateTime(2024, 1, 17, 21, 59, 55, 666, DateTimeKind.Local).AddTicks(1905), null, "creator@gmail.com", true, true, null, null, "Kemal", "CREATOR@GMAIL.COM", "CREATOR", "AQAAAAEAACcQAAAAENPu17FpaMyhKR2dPbbxPsspRTtDVWrSTN+hbSn9MRcnr30GTVeiCHqOAVwYdTN4qg==", "5312292928", true, "0df8c238-9133-4744-8f08-771c74fee04d", (byte)1, "Akcan", false, "Creator" },
                    { 2, 0, "c4abaeb6-7968-486f-b43d-7b94a42f008a", new DateTime(2024, 1, 17, 21, 59, 55, 666, DateTimeKind.Local).AddTicks(1942), null, "responder@gmail.com", true, true, null, null, "Sefa", "RESPONDER@GMAIL.COM", "RESPONDER", "AQAAAAEAACcQAAAAEOqpGDKWXjigc4IUtAFS9M6tt2xaXDDj8Qkwe2Y1tacPqZgTP+3n0Fru7STm0jL8fA==", "5446340539", true, "7d89bbf4-e504-4bd1-a404-1b544cfb5f13", (byte)1, "Er", false, "Responder" },
                    { 3, 0, "39fe04b0-1503-44d3-b308-4f54ed66976e", new DateTime(2024, 1, 17, 21, 59, 55, 666, DateTimeKind.Local).AddTicks(1959), null, "analyzer@gmail.com", true, true, null, null, "Bora", "ANALYZER@GMAIL.COM", "ANALYZER", "AQAAAAEAACcQAAAAEH/q2B6T/odsmHHNDakuTozICxFb2VRyY1rIr5zXZcFEjEaTuEW/npWkSyJt27UMqQ==", "5446340539", true, "ee225303-7c1e-4f20-91e2-fe6d16ed18fd", (byte)1, "Öz", false, "Analyzer" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "ModifiedDate", "Score", "Status" },
                values: new object[,]
                {
                    { 1, "A", new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(2625), null, null, (byte)10, (byte)1 },
                    { 2, "B", new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(2631), null, null, (byte)6, (byte)1 },
                    { 3, "C", new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(2634), null, null, (byte)8, (byte)1 }
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
                values: new object[] { 1, 1, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(5009), null, null, "İşyeri Memnuniyeti", (byte)1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "GroupId", "IsItAnswered", "ModifiedDate", "ParentQuestionId", "Status", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4173), null, 3, false, null, null, (byte)1, 1, "İş yerindeki genel çalışma ortamından ne kadar memnunsunuz?" },
                    { 2, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4179), null, 2, false, null, null, (byte)1, 1, "Takım arkadaşlarıyla iletişim ve işbirliği konusundaki deneyimleriniz nedir?" },
                    { 5, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4189), null, 3, false, null, null, (byte)1, 1, "Performans değerlendirmelerinizle ilgili olarak geribildirim almak konusundaki memnuniyetiniz nedir?" },
                    { 7, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4196), null, 2, false, null, null, (byte)1, 1, "İş yükü ve stres seviyeleriniz hakkında nasıl hissediyorsunuz?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "QuestionId", "Status", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4152), null, null, 1, (byte)1, "Çok memnunum" },
                    { 2, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4165), null, null, 1, (byte)1, "Memnun değilim" },
                    { 3, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4237), null, null, 2, (byte)1, "Mükemmel" },
                    { 4, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4239), null, null, 2, (byte)1, "İyileştirilebilir" },
                    { 9, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4256), null, null, 5, (byte)1, "Memnunum" },
                    { 10, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4260), null, null, 5, (byte)1, "Daha fazla geribildirim bekliyorum" },
                    { 13, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4267), null, null, 7, (byte)1, "Yönetilebilir" },
                    { 14, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4269), null, null, 7, (byte)1, "Yüksek" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "GroupId", "IsItAnswered", "ModifiedDate", "ParentQuestionId", "Status", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4183), null, 1, false, null, 2, (byte)1, 1, "Şirket tarafından sunulan eğitim ve gelişim fırsatlarından ne kadar faydalandınız?" },
                    { 4, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4186), null, 2, false, null, 2, (byte)1, 1, "Çalışma saatleri ve esneklik konusundaki beklentilerinizi karşılayabiliyor musunuz?" },
                    { 6, new DateTime(2024, 1, 17, 21, 59, 55, 673, DateTimeKind.Local).AddTicks(4194), null, 2, false, null, 5, (byte)1, 1, "İş güvenliği önlemleri ve çalışma ortamı konusunda endişeleriniz var mı?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "QuestionId", "Status", "Text" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4242), null, null, 3, (byte)1, "Çok fazla fayda sağladım" },
                    { 6, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4248), null, null, 3, (byte)1, "Yeterli değil" },
                    { 7, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4251), null, null, 4, (byte)1, "Evet, tam olarak" },
                    { 8, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4253), null, null, 4, (byte)1, "Hayır, daha fazla esneklik istiyorum" },
                    { 11, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4262), null, null, 6, (byte)1, "Hayır, güvenli hissediyorum" },
                    { 12, new DateTime(2024, 1, 17, 21, 59, 55, 665, DateTimeKind.Local).AddTicks(4265), null, null, 6, (byte)1, "Evet, iyileştirmeler yapılmalı" }
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
