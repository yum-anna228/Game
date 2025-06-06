﻿// <auto-generated />
using System;
using Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Game.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Game.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameSessionId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsTrump")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PlayerInGameId")
                        .HasColumnType("uuid");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("Suit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<Guid?>("TurnId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.HasIndex("PlayerInGameId");

                    b.HasIndex("TurnId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Game.GameSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TrumpSuit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("Game.PlayerInGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameSessionId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAttacker")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDefender")
                        .HasColumnType("boolean");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.HasIndex("UserId");

                    b.ToTable("PlayerInGames");
                });

            modelBuilder.Entity("Game.PlayerStatistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("GamesDraw")
                        .HasColumnType("integer");

                    b.Property<int>("GamesLost")
                        .HasColumnType("integer");

                    b.Property<int>("GamesWon")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PlayerStatistics");
                });

            modelBuilder.Entity("Game.Turn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttackerPlayerInGameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DefenderPlayerInGameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameSessionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AttackerPlayerInGameId");

                    b.HasIndex("DefenderPlayerInGameId");

                    b.HasIndex("GameSessionId");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("Game.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Game.Card", b =>
                {
                    b.HasOne("Game.GameSession", "GameSession")
                        .WithMany("Cards")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.PlayerInGame", "PlayerInGame")
                        .WithMany()
                        .HasForeignKey("PlayerInGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.Turn", "Turn")
                        .WithMany("Cards")
                        .HasForeignKey("TurnId");

                    b.Navigation("GameSession");

                    b.Navigation("PlayerInGame");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("Game.PlayerInGame", b =>
                {
                    b.HasOne("Game.GameSession", "GameSession")
                        .WithMany("PlayerInGames")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.User", "User")
                        .WithMany("PlayerInGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Game.PlayerStatistics", b =>
                {
                    b.HasOne("Game.User", "User")
                        .WithOne("Statistics")
                        .HasForeignKey("Game.PlayerStatistics", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Game.Turn", b =>
                {
                    b.HasOne("Game.PlayerInGame", "AttackerPlayerInGame")
                        .WithMany()
                        .HasForeignKey("AttackerPlayerInGameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Game.PlayerInGame", "DefenderPlayerInGame")
                        .WithMany()
                        .HasForeignKey("DefenderPlayerInGameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Game.GameSession", "GameSession")
                        .WithMany("Turns")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttackerPlayerInGame");

                    b.Navigation("DefenderPlayerInGame");

                    b.Navigation("GameSession");
                });

            modelBuilder.Entity("Game.GameSession", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("PlayerInGames");

                    b.Navigation("Turns");
                });

            modelBuilder.Entity("Game.Turn", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("Game.User", b =>
                {
                    b.Navigation("PlayerInGames");

                    b.Navigation("Statistics")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
