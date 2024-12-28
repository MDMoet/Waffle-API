using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Waffle_API.Models;

namespace Waffle_API.Context;

public partial class WaffleDbContext : DbContext
{
    public WaffleDbContext()
    {
    }

    public WaffleDbContext(DbContextOptions<WaffleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Muscle> Muscles { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    public virtual DbSet<RoutineDetail> RoutineDetails { get; set; }

    public virtual DbSet<SelectedRoutine> SelectedRoutines { get; set; }

    public virtual DbSet<Models.Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<WeekDay> WeekDays { get; set; }

    public virtual DbSet<WeightLog> WeightLogs { get; set; }

    public virtual DbSet<WeightLogsTimeline> WeightLogsTimelines { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutDay> WorkoutDays { get; set; }

    public virtual DbSet<WorkoutDayAfter> WorkoutDayAfters { get; set; }

    public virtual DbSet<WorkoutDayAfterDetail> WorkoutDayAfterDetails { get; set; }

    public virtual DbSet<WorkoutDayDetail> WorkoutDayDetails { get; set; }

    public virtual DbSet<WorkoutDetail> WorkoutDetails { get; set; }

    public virtual DbSet<WorkoutLog> WorkoutLogs { get; set; }

    public virtual DbSet<WorkoutLogsTimeline> WorkoutLogsTimelines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=77.251.5.254;database=waffle_workout_db;user id=ps250444;password=G7!rE2@9wN^zX3#jU1*QkT5&fL0$", ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.HasIndex(e => e.EquipmentName, "equipment_name").IsUnique();

            entity.Property(e => e.EquipmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("equipment_id");
            entity.Property(e => e.EquipmentImgPath)
                .HasMaxLength(256)
                .HasColumnName("equipment_img_path");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(64)
                .HasColumnName("equipment_name");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PRIMARY");

            entity.ToTable("goals");

            entity.HasIndex(e => e.WorkoutId, "g_workout_id");

            entity.HasIndex(e => new { e.UserId, e.WorkoutId }, "user_id").IsUnique();

            entity.Property(e => e.GoalId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("goal_id");
            entity.Property(e => e.GoalWeight)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("goal_weight");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_id");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("g_user_id");

            entity.HasOne(d => d.Workout).WithMany(p => p.Goals)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("g_workout_id");
        });

        modelBuilder.Entity<Muscle>(entity =>
        {
            entity.HasKey(e => e.MuscleId).HasName("PRIMARY");

            entity.ToTable("muscles");

            entity.HasIndex(e => e.MuscleName, "muscle_name").IsUnique();

            entity.Property(e => e.MuscleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("muscle_id");
            entity.Property(e => e.MuscleImgPath)
                .HasMaxLength(256)
                .HasColumnName("muscle_img_path");
            entity.Property(e => e.MuscleName)
                .HasMaxLength(64)
                .HasColumnName("muscle_name");
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.HasKey(e => e.RoutineId).HasName("PRIMARY");

            entity.ToTable("routines");

            entity.HasIndex(e => e.UserId, "r_user_id");

            entity.Property(e => e.RoutineId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("routine_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Routines)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("r_user_id");
        });

        modelBuilder.Entity<RoutineDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("routine_details");

            entity.HasIndex(e => e.WeekDayId, "rd_week_day_id");

            entity.HasIndex(e => e.RoutineId, "routine_id");

            entity.HasIndex(e => e.WorkoutAfterId, "workout_after_id");

            entity.HasIndex(e => e.WorkoutDayId, "workout_day_id");

            entity.Property(e => e.RoutineId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("routine_id");
            entity.Property(e => e.WeekDayId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("week_day_id");
            entity.Property(e => e.WorkoutAfterId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_after_id");
            entity.Property(e => e.WorkoutDayId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_day_id");

            entity.HasOne(d => d.Routine).WithMany()
                .HasForeignKey(d => d.RoutineId)
                .HasConstraintName("rd_routine_id");

            entity.HasOne(d => d.WeekDay).WithMany()
                .HasForeignKey(d => d.WeekDayId)
                .HasConstraintName("rd_week_day_id");

            entity.HasOne(d => d.WorkoutAfter).WithMany()
                .HasForeignKey(d => d.WorkoutAfterId)
                .HasConstraintName("rd_workout_after_id");

            entity.HasOne(d => d.WorkoutDay).WithMany()
                .HasForeignKey(d => d.WorkoutDayId)
                .HasConstraintName("rd_workout_day_id");
        });

        modelBuilder.Entity<SelectedRoutine>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("selected_routines");

            entity.HasIndex(e => e.RoutineId, "sr_routine_id");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.RoutineId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("routine_id");

            entity.HasOne(d => d.Routine).WithMany(p => p.SelectedRoutines)
                .HasForeignKey(d => d.RoutineId)
                .HasConstraintName("sr_routine_id");

            entity.HasOne(d => d.User).WithOne(p => p.SelectedRoutine)
                .HasForeignKey<SelectedRoutine>(d => d.UserId)
                .HasConstraintName("sr_user_id");
        });

        modelBuilder.Entity<Models.Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("types");

            entity.HasIndex(e => e.TypeName, "type_name").IsUnique();

            entity.Property(e => e.TypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(45)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.UserName, "user_name").IsUnique();

            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerified)
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("email_verified");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(64)
                .HasColumnName("remember_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(32)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_details");

            entity.HasIndex(e => e.UserId, "ui_user_details_user_id").IsUnique();

            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FatMass)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("fat_mass");
            entity.Property(e => e.Gender)
                .HasColumnType("enum('male','female','rather not say')")
                .HasColumnName("gender");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("height");
            entity.Property(e => e.MuscleMass)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("muscle_mass");
            entity.Property(e => e.System)
                .HasColumnType("enum('imperial','metric')")
                .HasColumnName("system");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("weight");

            entity.HasOne(d => d.User).WithOne()
                .HasForeignKey<UserDetail>(d => d.UserId)
                .HasConstraintName("ud_user_id");
        });

        modelBuilder.Entity<WeekDay>(entity =>
        {
            entity.HasKey(e => e.WeekDayId).HasName("PRIMARY");

            entity.ToTable("week_days");

            entity.Property(e => e.WeekDayId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("week_day_id");
            entity.Property(e => e.DayName)
                .HasMaxLength(32)
                .HasColumnName("day_name");
        });

        modelBuilder.Entity<WeightLog>(entity =>
        {
            entity.HasKey(e => e.WeightLogId).HasName("PRIMARY");

            entity.ToTable("weight_logs");

            entity.Property(e => e.WeightLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("weight_log_id");
            entity.Property(e => e.FatMassLog)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("fat_mass_log");
            entity.Property(e => e.MuscleMassLog)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("muscle_mass_log");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.WeightLog1)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("weight_log");
        });

        modelBuilder.Entity<WeightLogsTimeline>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.WeightLogId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("weight_logs_timeline");

            entity.HasIndex(e => e.WeightLogId, "weight_log_id");

            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.WeightLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("weight_log_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.User).WithMany(p => p.WeightLogsTimelines)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("wlt_user_id");

            entity.HasOne(d => d.WeightLog).WithMany(p => p.WeightLogsTimelines)
                .HasForeignKey(d => d.WeightLogId)
                .HasConstraintName("wlt_weight_log_id");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.WorkoutId).HasName("PRIMARY");

            entity.ToTable("workouts");

            entity.HasIndex(e => e.WorkoutName, "workout_name").IsUnique();

            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_id");
            entity.Property(e => e.WorkoutImgPath)
                .HasMaxLength(256)
                .HasColumnName("workout_img_path");
            entity.Property(e => e.WorkoutName)
                .HasMaxLength(64)
                .HasColumnName("workout_name");
        });

        modelBuilder.Entity<WorkoutDay>(entity =>
        {
            entity.HasKey(e => e.WorkoutDayId).HasName("PRIMARY");

            entity.ToTable("workout_days");

            entity.HasIndex(e => e.UserId, "wd_user_id");

            entity.Property(e => e.WorkoutDayId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_day_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.WorkoutDays)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wd_user_id");
        });

        modelBuilder.Entity<WorkoutDayAfter>(entity =>
        {
            entity.HasKey(e => e.WorkoutAfterId).HasName("PRIMARY");

            entity.ToTable("workout_day_afters");

            entity.HasIndex(e => e.UserId, "wda_user_id");

            entity.Property(e => e.WorkoutAfterId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_after_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.WorkoutDayAfters)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("wda_user_id");
        });

        modelBuilder.Entity<WorkoutDayAfterDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("workout_day_after_details");

            entity.HasIndex(e => new { e.WorkoutAfterId, e.WorkoutId }, "workout_after_id").IsUnique();

            entity.HasIndex(e => e.WorkoutId, "workout_id");

            entity.Property(e => e.Weight)
                .HasPrecision(4, 2)
                .HasColumnName("weight");
            entity.Property(e => e.WorkoutAfterId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_after_id");
            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_id");
            entity.Property(e => e.WorkoutTime)
                .HasColumnType("time")
                .HasColumnName("workout_time");

            entity.HasOne(d => d.WorkoutAfter).WithMany()
                .HasForeignKey(d => d.WorkoutAfterId)
                .HasConstraintName("wdad_workout_after_id");

            entity.HasOne(d => d.Workout).WithMany()
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("wdad_workout_id");
        });

        modelBuilder.Entity<WorkoutDayDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("workout_day_details");

            entity.HasIndex(e => e.WorkoutDayId, "workout_day_id");

            entity.HasIndex(e => new { e.WorkoutDayId, e.WorkoutId }, "workout_day_id_2").IsUnique();

            entity.HasIndex(e => e.WorkoutId, "workout_id");

            entity.Property(e => e.Reps)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("reps");
            entity.Property(e => e.Sets)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("sets");
            entity.Property(e => e.WorkoutDayId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_day_id");
            entity.Property(e => e.WorkoutDayName)
                .HasMaxLength(64)
                .HasColumnName("workout_day_name");
            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_id");
            entity.Property(e => e.WorkoutWeight)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("workout_weight");

            entity.HasOne(d => d.WorkoutDay).WithMany()
                .HasForeignKey(d => d.WorkoutDayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wdd_workout_day_id");

            entity.HasOne(d => d.Workout).WithMany()
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wdd_workout_id");
        });

        modelBuilder.Entity<WorkoutDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("workout_details");

            entity.HasIndex(e => e.EquipmentId, "wd_equipment_id");

            entity.HasIndex(e => e.MuscleId, "wd_muscle_id");

            entity.HasIndex(e => e.TypeId, "wd_type_id");

            entity.HasIndex(e => new { e.WorkoutId, e.MuscleId, e.TypeId, e.EquipmentId }, "workout_id").IsUnique();

            entity.Property(e => e.EquipmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("equipment_id");
            entity.Property(e => e.MuscleId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("muscle_id");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("type_id");
            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_id");

            entity.HasOne(d => d.Equipment).WithMany()
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wd_equipment_id");

            entity.HasOne(d => d.Muscle).WithMany()
                .HasForeignKey(d => d.MuscleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wd_muscle_id");

            entity.HasOne(d => d.Type).WithMany()
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wd_type_id");

            entity.HasOne(d => d.Workout).WithMany()
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wd_workout_id");
        });

        modelBuilder.Entity<WorkoutLog>(entity =>
        {
            entity.HasKey(e => e.WorkoutLogId).HasName("PRIMARY");

            entity.ToTable("workout_logs");

            entity.HasIndex(e => e.WorkoutId, "wl_workout_id");

            entity.Property(e => e.WorkoutLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_log_id");
            entity.Property(e => e.Reps)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("reps");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(4,2) unsigned")
                .HasColumnName("weight");
            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_id");

            entity.HasOne(d => d.Workout).WithMany(p => p.WorkoutLogs)
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("wl_workout_id");
        });

        modelBuilder.Entity<WorkoutLogsTimeline>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.WorkoutLogId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("workout_logs_timeline");

            entity.HasIndex(e => e.WorkoutLogId, "workout_log_id");

            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.WorkoutLogId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("workout_log_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.User).WithMany(p => p.WorkoutLogsTimelines)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("wolt_user_id");

            entity.HasOne(d => d.WorkoutLog).WithMany(p => p.WorkoutLogsTimelines)
                .HasForeignKey(d => d.WorkoutLogId)
                .HasConstraintName("wlt_workout_logs_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
