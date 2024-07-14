using Microsoft.EntityFrameworkCore;
using GymApp.Models;
using Microsoft.Extensions.Logging;

namespace GymApp.Data
{
    public class GymAppContext : DbContext
    {
        public GymAppContext(DbContextOptions<GymAppContext> options) : base(options) { }

        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }
        public DbSet<TrainingEquipement> TrainingEquipements { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=gymapp.db")
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingEquipement>().HasData(
                new TrainingEquipement(1, "Barbell"),
                new TrainingEquipement(2, "Dumbell"),
                new TrainingEquipement(3, "Kettlebell"),
                new TrainingEquipement(4, "Resistance Band")
            );

            modelBuilder.Entity<BodyPart>().HasData(
                new BodyPart(1, "Shoulders"),
                new BodyPart(2, "Chest"),
                new BodyPart(3, "Back"),
                new BodyPart(4, "Abs"),
                new BodyPart(5, "Glutes"),
                new BodyPart(6, "Quads"),
                new BodyPart(7, "Biceps"),
                new BodyPart(8, "Triceps")
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise(1, "Bench Press", 1, new List<int> { 2 }),
                new Exercise(2, "Bench Press with dumbells", 2, new List<int> { 2 }),
                new Exercise(3, "Squat", 1, new List<int> { 5, 6 }),
                new Exercise(4, "Bend Over Row w/ dumbells", 2, new List<int> { 3 }),
                new Exercise(5, "Biceps curl w/ dumbells", 2, new List<int> { 7 }),
                new Exercise(6, "Triceps pull downs w/ band", 4, new List<int> { 8 }),
                new Exercise(7, "Dead Lift", 1, new List<int> { 3, 5 })
            );

            modelBuilder.Entity<WorkoutSession>().HasData(
                new WorkoutSession
                {
                    WorkoutSessionId = 1,
                    TimeStarted = new DateTime(2024, 5, 1, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 5, 1, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 2,
                    TimeStarted = new DateTime(2024, 5, 10, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 5, 10, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 3,
                    TimeStarted = new DateTime(2024, 5, 20, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 5, 20, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 4,
                    TimeStarted = new DateTime(2024, 6, 5, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 6, 5, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 5,
                    TimeStarted = new DateTime(2024, 6, 15, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 6, 15, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 6,
                    TimeStarted = new DateTime(2024, 6, 25, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 6, 25, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 7,
                    TimeStarted = new DateTime(2024, 7, 5, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 7, 5, 19, 0, 0)
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 8,
                    TimeStarted = new DateTime(2024, 7, 15, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 7, 15, 19, 0, 0)
                }
            );

            modelBuilder.Entity<ExerciseSet>().HasData(
                new ExerciseSet { ExerciseSetId = 1, ExerciseId = 1, WorkoutSessionId = 1, Repetitions = 10, Weight = 100 },
                new ExerciseSet { ExerciseSetId = 2, ExerciseId = 2, WorkoutSessionId = 1, Repetitions = 8, Weight = 90 },
                new ExerciseSet { ExerciseSetId = 3, ExerciseId = 3, WorkoutSessionId = 1, Repetitions = 6, Weight = 85 }
            );

            modelBuilder.Entity<ExerciseSet>()
                .HasOne(es => es.WorkoutSession)
                .WithMany(ws => ws.ExerciseSets)
                .HasForeignKey(es => es.WorkoutSessionId);

            modelBuilder.Entity<ExerciseSet>()
                .HasOne(es => es.Exercise)
                .WithMany()
                .HasForeignKey(es => es.ExerciseId);
        }
    }
}
