using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartWorkout1.Entities;

namespace SmartWorkout1.Context
{
    public class SmartWorkoutContext : DbContext
    {
        public SmartWorkoutContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet <User> Users { get; set; }
        public DbSet <Excercise> Excercises { get; set; }

        public DbSet <ExcerciseLog> ExcerciseLogs { get; set; }

        public DbSet <Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure relationships and constraints
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(w => w.Workouts)
                .HasForeignKey(w => w.UserId)
                .HasConstraintName("FK_Workouts_Users");

            modelBuilder.Entity<ExcerciseLog>()
               .HasOne(el => el.Excercise)
               .WithMany(e => e.ExcerciseLogs)
               .HasForeignKey(el => el.ExcerciseId)
               .HasConstraintName("FK_ExcerciseLogs_Excercises");

            modelBuilder.Entity<ExcerciseLog>()
                .HasOne(el => el.Workout)
                .WithMany(w => w.ExcerciseLogs)
                .HasForeignKey(el => el.WorkoutId)
                .HasConstraintName("FK_ExerciseLogs_Workouts");

            base.OnModelCreating(modelBuilder);

        }
    }

}

