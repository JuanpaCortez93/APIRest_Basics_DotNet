using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWT_P2.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Schools_StudentId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Students_StudentId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SchoolId",
                table: "Messages",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Schools_SchoolId",
                table: "Messages",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Students_StudentId",
                table: "Messages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Schools_SchoolId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Students_StudentId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SchoolId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Schools_StudentId",
                table: "Messages",
                column: "StudentId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Students_StudentId",
                table: "Messages",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
