using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace De_mau_so1_C3.Migrations
{
    /// <inheritdoc />
    public partial class c2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_LopHocs_MaLop",
                table: "SinhViens");

            migrationBuilder.AlterColumn<string>(
                name: "MaLop",
                table: "SinhViens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_LopHocs_MaLop",
                table: "SinhViens",
                column: "MaLop",
                principalTable: "LopHocs",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_LopHocs_MaLop",
                table: "SinhViens");

            migrationBuilder.AlterColumn<string>(
                name: "MaLop",
                table: "SinhViens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_LopHocs_MaLop",
                table: "SinhViens",
                column: "MaLop",
                principalTable: "LopHocs",
                principalColumn: "MaLop");
        }
    }
}
