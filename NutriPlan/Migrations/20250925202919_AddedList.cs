using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlan.Migrations
{
    /// <inheritdoc />
    public partial class AddedList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grams",
                table: "RecipesIngredients");

            migrationBuilder.AddColumn<string>(
                name: "IngredientsList",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientsList",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "Grams",
                table: "RecipesIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
