using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WimabEventApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRsvpAndInvitationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RsvpStatus",
                table: "Invitations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InvitationId",
                table: "Guests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RsvpDeadline",
                table: "Events",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_InvitationId",
                table: "Guests",
                column: "InvitationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Invitations_InvitationId",
                table: "Guests",
                column: "InvitationId",
                principalTable: "Invitations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Invitations_InvitationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_InvitationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RsvpStatus",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "InvitationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RsvpDeadline",
                table: "Events");
        }
    }
}
