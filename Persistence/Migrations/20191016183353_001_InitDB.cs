using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class _001_InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastAccessOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsExplicit = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackPlaylistAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaylistId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    AddedTrackToPlaylistOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackPlaylistAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackPlaylistAssignments_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrackPlaylistAssignments_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Queens of the Stone Age" },
                    { 2, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Led Zeppelin" },
                    { 3, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Black Sabbath" },
                    { 4, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Gary Clark Jr." },
                    { 5, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Them Crooked Vultures" },
                    { 6, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Black Keys" },
                    { 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Killing Joke" },
                    { 8, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Black Rebel Motorcycle Club" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "FirstName", "LastAccessOn", "LastName" },
                values: new object[] { 1, new DateTime(2016, 6, 13, 19, 41, 32, 643, DateTimeKind.Local).AddTicks(6241), "Daniel", new DateTime(2019, 10, 14, 21, 31, 11, 535, DateTimeKind.Local).AddTicks(9553), "Agg" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Villains" },
                    { 15, 8, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "B.R.M.C." },
                    { 14, 8, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Specter At The  Feast" },
                    { 13, 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Brighter Than A Thousand Suns" },
                    { 12, 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Absolute Dissent" },
                    { 11, 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Laugh? I Nearly Bought One!" },
                    { 9, 6, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "\"Let's Rock\"" },
                    { 10, 6, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "El Camino" },
                    { 7, 4, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "This Land" },
                    { 6, 3, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Paranoid" },
                    { 5, 3, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Masters of Reality" },
                    { 4, 2, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Led Zeppelin IV" },
                    { 3, 2, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Led Zeppelin II" },
                    { 2, 1, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "...Like Clockwork" },
                    { 8, 5, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), "Them Crooked Vultures" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "CreatedOn", "Name", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2018, 12, 30, 15, 2, 25, 0, DateTimeKind.Local), "Music to Focus", 1 },
                    { 1, new DateTime(2019, 10, 13, 20, 12, 32, 0, DateTimeKind.Local), "Walk Like a Badass", 1 },
                    { 2, new DateTime(2019, 8, 22, 12, 52, 18, 0, DateTimeKind.Local), "Mellow Rock", 1 },
                    { 4, new DateTime(2018, 10, 5, 10, 36, 10, 0, DateTimeKind.Local), "Oldschool Goodness", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumId", "CreatedOn", "IsExplicit", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Feet Don't Fail Me" },
                    { 23, 14, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Funny Games" },
                    { 22, 13, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Love of the Masses" },
                    { 21, 12, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "The Raven King" },
                    { 20, 11, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Requiem" },
                    { 19, 10, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Sister" },
                    { 18, 10, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Run Right Back" },
                    { 17, 9, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Eagle Birds" },
                    { 16, 8, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Gunman" },
                    { 15, 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "The Guitar Man" },
                    { 14, 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "I Walk Alone" },
                    { 24, 15, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Red Eyes And Tears" },
                    { 13, 7, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Pearl Cadillac" },
                    { 11, 6, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "War Pigs" },
                    { 10, 5, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Into the Void" },
                    { 9, 4, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Going to California" },
                    { 8, 4, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Rock and Roll" },
                    { 7, 4, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Black Dog" },
                    { 6, 3, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Whole Lotta Love" },
                    { 5, 3, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Ramble On" },
                    { 4, 2, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Kalopsia" },
                    { 3, 2, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "I Appear Missing" },
                    { 2, 1, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "The Evil Has Landed" },
                    { 12, 6, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "Fairies Wear Boots" },
                    { 25, 15, new DateTime(1990, 1, 1, 13, 0, 0, 0, DateTimeKind.Local), false, "As Sure As The Sun" }
                });

            migrationBuilder.InsertData(
                table: "TrackPlaylistAssignments",
                columns: new[] { "Id", "AddedTrackToPlaylistOn", "PlaylistId", "TrackId" },
                values: new object[,]
                {
                    { 3, new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 13, new DateTime(2018, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 23 },
                    { 11, new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 23 },
                    { 10, new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 22 },
                    { 9, new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 21 },
                    { 5, new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 18 },
                    { 1, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 17 },
                    { 4, new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 16 },
                    { 24, new DateTime(2018, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12 },
                    { 23, new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 11 },
                    { 22, new DateTime(2018, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 10 },
                    { 21, new DateTime(2018, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 9 },
                    { 14, new DateTime(2018, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9 },
                    { 8, new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 20, new DateTime(2018, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8 },
                    { 19, new DateTime(2018, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7 },
                    { 18, new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 6 },
                    { 17, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 16, new DateTime(2019, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 7, new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 15, new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 2, new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 6, new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 24 },
                    { 12, new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackPlaylistAssignments_PlaylistId",
                table: "TrackPlaylistAssignments",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackPlaylistAssignments_TrackId",
                table: "TrackPlaylistAssignments",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackPlaylistAssignments");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
