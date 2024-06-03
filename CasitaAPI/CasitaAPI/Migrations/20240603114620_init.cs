using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasitaAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    receipt_date = table.Column<DateOnly>(type: "date", nullable: true),
                    balance = table.Column<decimal>(type: "money", nullable: false),
                    necessities_percentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    savings_percentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    wants_percentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    recovery_code = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Financial",
                        column: x => x.id,
                        principalTable: "Financial",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    amount_spent = table.Column<decimal>(type: "money", nullable: true),
                    total_amount = table.Column<decimal>(type: "money", nullable: true),
                    created_at = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    finantial_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    list_type_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionList", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionList_Financial",
                        column: x => x.finantial_id,
                        principalTable: "Financial",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TransactionList_ListType",
                        column: x => x.list_type_id,
                        principalTable: "ListType",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TransactionList_Priority",
                        column: x => x.priority_id,
                        principalTable: "Priority",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    description = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.id);
                    table.ForeignKey(
                        name: "FK_List_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    is_concluded = table.Column<bool>(type: "bit", nullable: true),
                    list_id = table.Column<int>(type: "int", nullable: false),
                    priority_id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListItem_Priority",
                        column: x => x.priority_id,
                        principalTable: "Priority",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ListItem_TransactionList1",
                        column: x => x.list_id,
                        principalTable: "TransactionList",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<decimal>(type: "money", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    list_id = table.Column<int>(type: "int", nullable: true),
                    frequency_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transaction_Frequency",
                        column: x => x.frequency_id,
                        principalTable: "Frequency",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionList",
                        column: x => x.list_id,
                        principalTable: "TransactionList",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AppTask",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    priority_id = table.Column<int>(type: "int", nullable: true),
                    list_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_concluded = table.Column<bool>(type: "bit", nullable: true),
                    frequency_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.id);
                    table.ForeignKey(
                        name: "FK_Task_List",
                        column: x => x.list_id,
                        principalTable: "List",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTask_list_id",
                table: "AppTask",
                column: "list_id");

            migrationBuilder.CreateIndex(
                name: "IX_List_user_id",
                table: "List",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_list_id",
                table: "ListItem",
                column: "list_id");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_priority_id",
                table: "ListItem",
                column: "priority_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_frequency_id",
                table: "Transaction",
                column: "frequency_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_list_id",
                table: "Transaction",
                column: "list_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionList_finantial_id",
                table: "TransactionList",
                column: "finantial_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionList_list_type_id",
                table: "TransactionList",
                column: "list_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionList_priority_id",
                table: "TransactionList",
                column: "priority_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTask");

            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "TransactionList");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ListType");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "Financial");
        }
    }
}
