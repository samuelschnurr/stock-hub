using Microsoft.EntityFrameworkCore.Migrations;

namespace StockHubApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAcquisitionPricePerUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Stocks",
                type: "decimal(17,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(17,4)");

            migrationBuilder.AddColumn<decimal>(
                name: "AcquisitionPricePerUnit",
                table: "Stocks",
                type: "decimal(12,4)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcquisitionPricePerUnit",
                table: "Stocks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "NVARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Stocks",
                type: "DECIMAL(17,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(17,4)");
        }
    }
}
