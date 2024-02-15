using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaEF.Migrations
{
    /// <inheritdoc />
    public partial class addcolunaReuniao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReuniaoAtiva",
                table: "Reunioes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReuniaoAtiva",
                table: "Reunioes");
        }
    }
}
