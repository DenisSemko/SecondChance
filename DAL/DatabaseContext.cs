using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<ParentChild> ParentChild { get; set; }
        public DbSet<DailyTest> DailyTest { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<DailyTestResult> DailyTestResult { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<ObservationResult> ObservationResult { get; set; }
        public DbSet<Dairy> Dairy { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameResult> GameResult { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ParentChild - User
            modelBuilder.Entity<ParentChild>()
                .HasOne(s => s.ParentId)
                .WithMany(a => a.UserParents);
            modelBuilder.Entity<ParentChild>()
                .HasOne(s => s.ChildId)
                .WithMany(a => a.UserChilds);

            modelBuilder.Entity<User>()
                .HasMany(s => s.UserParents)
                .WithOne(a => a.ParentId);
            modelBuilder.Entity<User>()
                .HasMany(s => s.UserChilds)
                .WithOne(a => a.ChildId);

            //DailyTest - Question
            modelBuilder.Entity<DailyTest>()
                .HasOne(s => s.Question)
                .WithMany(a => a.DailyTests);

            modelBuilder.Entity<Question>()
                .HasMany(s => s.DailyTests)
                .WithOne(a => a.Question);

            //DailyTest Result - DailyTest - User
            modelBuilder.Entity<DailyTestResult>()
                .HasOne(s => s.DailyTest)
                .WithMany(a => a.DailyTestResults);
            modelBuilder.Entity<DailyTestResult>()
                .HasOne(s => s.PassedUserId)
                .WithMany(a => a.DailyTestResults);

            modelBuilder.Entity<DailyTest>()
                .HasMany(s => s.DailyTestResults)
                .WithOne(a => a.DailyTest);
            modelBuilder.Entity<User>()
                .HasMany(s => s.DailyTestResults)
                .WithOne(a => a.PassedUserId);

            //Answer - User - DailyTest - Question
            modelBuilder.Entity<Answer>()
                .HasOne(s => s.PassedUserId)
                .WithMany(a => a.Answers);
            modelBuilder.Entity<Answer>()
                .HasOne(s => s.DailyTest)
                .WithMany(a => a.Answers);
            modelBuilder.Entity<Answer>()
                .HasOne(s => s.Question)
                .WithMany(a => a.Answers);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Answers)
                .WithOne(a => a.PassedUserId);
            modelBuilder.Entity<DailyTest>()
                .HasMany(s => s.Answers)
                .WithOne(a => a.DailyTest);
            modelBuilder.Entity<Question>()
                .HasMany(s => s.Answers)
                .WithOne(a => a.Question);

            //ObservationResult - User
            modelBuilder.Entity<ObservationResult>()
               .HasOne(s => s.PassedUserId)
               .WithMany(a => a.ObservationResults);

            modelBuilder.Entity<User>()
                .HasMany(s => s.ObservationResults)
                .WithOne(a => a.PassedUserId);


            //Dairy - User
            modelBuilder.Entity<Dairy>()
               .HasOne(s => s.PassedUserId)
               .WithMany(a => a.Dairies);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Dairies)
                .WithOne(a => a.PassedUserId);

            //GameResult - Game - User
            modelBuilder.Entity<GameResult>()
                .HasOne(s => s.Game)
                .WithMany(a => a.GameResults);
            modelBuilder.Entity<GameResult>()
                .HasOne(s => s.PassedUserId)
                .WithMany(a => a.GameResults);

            modelBuilder.Entity<Game>()
                .HasMany(s => s.GameResults)
                .WithOne(a => a.Game);
            modelBuilder.Entity<User>()
                .HasMany(s => s.GameResults)
                .WithOne(a => a.PassedUserId);
        }
    }
}
