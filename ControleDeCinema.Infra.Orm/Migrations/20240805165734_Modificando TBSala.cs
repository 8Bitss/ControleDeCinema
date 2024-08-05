using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoTBSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBSala_TBPoltrona",
                table: "TBPoltrona");

            migrationBuilder.AddForeignKey(
                name: "FK_TBSala_TBPoltrona",
                table: "TBPoltrona",
                column: "Sala_Id",
                principalTable: "TBSala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBSala_TBPoltrona",
                table: "TBPoltrona");

            migrationBuilder.AddForeignKey(
                name: "FK_TBSala_TBPoltrona",
                table: "TBPoltrona",
                column: "Sala_Id",
                principalTable: "TBSala",
                principalColumn: "Id");
        }
    }
}
