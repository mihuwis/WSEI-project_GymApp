using Microsoft.EntityFrameworkCore;
using GymApp.Models;

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
    }
}

