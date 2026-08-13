using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewHome.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    surname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    raiting = table.Column<double>(type: "double precision", nullable: false),
                    picture_path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_evaluations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    rating_value = table.Column<double>(type: "double precision", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk__evaluations", x => x.id);
                    table.ForeignKey(
                        name: "fk__evaluations_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "_pet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    picture_path = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    species = table.Column<string>(type: "text", nullable: false),
                    breed = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    health = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    castration = table.Column<bool>(type: "boolean", nullable: false),
                    sheltered = table.Column<bool>(type: "boolean", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk__pet", x => x.id);
                    table.ForeignKey(
                        name: "fk__pet_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix__evaluations_user_id",
                table: "_evaluations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix__pet_owner_id",
                table: "_pet",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_evaluations");

            migrationBuilder.DropTable(
                name: "_pet");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
