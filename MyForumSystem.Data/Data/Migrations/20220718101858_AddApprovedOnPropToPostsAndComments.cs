using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyForumSystem.Data.Migrations
{
    public partial class AddApprovedOnPropToPostsAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "Posts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "Comments");
        }
    }
}
