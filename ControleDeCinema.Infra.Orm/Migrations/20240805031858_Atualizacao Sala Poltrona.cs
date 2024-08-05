using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoSalaPoltrona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    QtdAssentosDisponiveis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPoltrona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Sala_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPoltrona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBSala_TBPoltrona",
                        column: x => x.Sala_Id,
                        principalTable: "TBSala",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPoltrona_Sala_Id",
                table: "TBPoltrona",
                column: "Sala_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBPoltrona");

            migrationBuilder.DropTable(
                name: "TBSala");
        }
    }
}
