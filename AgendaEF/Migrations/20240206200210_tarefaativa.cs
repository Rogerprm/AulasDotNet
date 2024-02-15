using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaEF.Migrations
{
    /// <inheritdoc />
    public partial class tarefaativa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TarefaAtiva",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarefaAtiva",
                table: "Tarefas");
        }
    }
}
