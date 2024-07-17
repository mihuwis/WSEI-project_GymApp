using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymApp.Migrations
{
    /// <inheritdoc />
    public partial class InitializeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyParts",
                columns: table => new
                {
                    BodyPartID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BodyPartName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyParts", x => x.BodyPartID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipements",
                columns: table => new
                {
                    EquipementID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipementName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipements", x => x.EquipementID);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    WorkoutSessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeStarted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeFinished = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.WorkoutSessionId);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciseName = table.Column<string>(type: "TEXT", nullable: false),
                    TrainingEquipementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_TrainingEquipements_TrainingEquipementId",
                        column: x => x.TrainingEquipementId,
                        principalTable: "TrainingEquipements",
                        principalColumn: "EquipementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSets",
                columns: table => new
                {
                    ExerciseSetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Repetitions = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    WorkoutSessionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSets", x => x.ExerciseSetId);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_WorkoutSessions_WorkoutSessionId",
                        column: x => x.WorkoutSessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "WorkoutSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyParts",
                columns: new[] { "BodyPartID", "BodyPartName" },
                values: new object[,]
                {
                    { 1, "Shoulders" },
                    { 2, "Chest" },
                    { 3, "Back" },
                    { 4, "Abs" },
                    { 5, "Glutes" },
                    { 6, "Quads" },
                    { 7, "Biceps" },
                    { 8, "Triceps" }
                });

            migrationBuilder.InsertData(
                table: "TrainingEquipements",
                columns: new[] { "EquipementID", "EquipementName" },
                values: new object[,]
                {
                    { 1, "Barbell" },
                    { 2, "Dumbell" },
                    { 3, "Kettlebell" },
                    { 4, "Resistance Band" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutSessions",
                columns: new[] { "WorkoutSessionId", "TimeFinished", "TimeStarted" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 5, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 5, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 6, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 6, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 6, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 7, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 7, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "ExerciseName", "TrainingEquipementId" },
                values: new object[,]
                {
                    { 1, "Bench Press", 1 },
                    { 2, "Bench Press with dumbells", 2 },
                    { 3, "Squat", 1 },
                    { 4, "Bend Over Row w/ dumbells", 2 },
                    { 5, "Biceps curl w/ dumbells", 2 },
                    { 6, "Triceps pull downs w/ band", 4 },
                    { 7, "Dead Lift", 1 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseSets",
                columns: new[] { "ExerciseSetId", "ExerciseId", "Repetitions", "Weight", "WorkoutSessionId" },
                values: new object[,]
                {
                    { 1, 1, 10, 100f, 1 },
                    { 2, 2, 8, 90f, 1 },
                    { 3, 3, 6, 85f, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingEquipementId",
                table: "Exercises",
                column: "TrainingEquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_WorkoutSessionId",
                table: "ExerciseSets",
                column: "WorkoutSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyParts");

            migrationBuilder.DropTable(
                name: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "TrainingEquipements");
        }
    }
}
