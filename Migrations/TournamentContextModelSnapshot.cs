﻿// <auto-generated />
using beerpong_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace beerpongapi.Migrations
{
    [DbContext(typeof(TournamentContext))]
    partial class TournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("beerpong_api.Models.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeerFor1")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("BeerFor2")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Order");

                    b.Property<bool>("Played")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int?>("PoolID");

                    b.Property<int?>("RoundID");

                    b.Property<int?>("Team1ID");

                    b.Property<int?>("Team2ID");

                    b.HasKey("ID");

                    b.HasIndex("PoolID");

                    b.HasIndex("RoundID");

                    b.HasIndex("Team1ID");

                    b.HasIndex("Team2ID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("beerpong_api.Models.Pool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("TournamentID");

                    b.HasKey("ID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Pool");
                });

            modelBuilder.Entity("beerpong_api.Models.Round", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TournamentID");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("beerpong_api.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeerAgainst")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("BeerFor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Name");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("PoolID");

                    b.Property<int?>("TournamentID");

                    b.HasKey("ID");

                    b.HasIndex("PoolID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("beerpong_api.Models.Tournament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("beerpong_api.Models.Match", b =>
                {
                    b.HasOne("beerpong_api.Models.Pool")
                        .WithMany("Matches")
                        .HasForeignKey("PoolID");

                    b.HasOne("beerpong_api.Models.Round")
                        .WithMany("Matches")
                        .HasForeignKey("RoundID");

                    b.HasOne("beerpong_api.Models.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1ID");

                    b.HasOne("beerpong_api.Models.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2ID");
                });

            modelBuilder.Entity("beerpong_api.Models.Pool", b =>
                {
                    b.HasOne("beerpong_api.Models.Tournament")
                        .WithMany("Pools")
                        .HasForeignKey("TournamentID");
                });

            modelBuilder.Entity("beerpong_api.Models.Team", b =>
                {
                    b.HasOne("beerpong_api.Models.Pool")
                        .WithMany("Teams")
                        .HasForeignKey("PoolID");

                    b.HasOne("beerpong_api.Models.Tournament")
                        .WithMany("Teams")
                        .HasForeignKey("TournamentID");
                });
#pragma warning restore 612, 618
        }
    }
}
