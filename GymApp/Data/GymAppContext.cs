using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymApp.Models;

namespace GymApp.Data
{
    class GymAppContext : DbContext
    {
        public GymAppContext(DbContextOptions<GymAppContext> options) : base(options) { }

        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }
        public DbSet<TrainingEquipement> TrainingEquipements { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
    }
}
