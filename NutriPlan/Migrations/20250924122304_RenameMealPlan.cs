using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlan.Migrations
{
    /// <inheritdoc />
    public partial class RenameMealPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Recipes_RecipeID",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "MealPlans",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlans_RecipeID",
                table: "MealPlans",
                newName: "IX_MealPlans_RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Recipes_RecipeId",
                table: "MealPlans",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Recipes_RecipeId",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "MealPlans",
                newName: "RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlans_RecipeId",
                table: "MealPlans",
                newName: "IX_MealPlans_RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Recipes_RecipeID",
                table: "MealPlans",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
