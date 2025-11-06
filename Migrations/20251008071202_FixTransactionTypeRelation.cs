using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionTypeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Transactions",
                newName: "TransactionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TypeId",
                table: "Transactions",
                newName: "IX_Transactions_TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionTypeId",
                table: "Transactions",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                newName: "IX_Transactions_TypeId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TypeId",
                table: "Transactions",
                column: "TypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
