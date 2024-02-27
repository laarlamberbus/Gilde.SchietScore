﻿// <auto-generated />
using System;
using Gilde.SchietScore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gilde.SchietScore.Persistence.Migrations
{
    [DbContext(typeof(SchietScoreDbContext))]
    [Migration("20240212105158_CompetitieIsAfgerond")]
    partial class CompetitieIsAfgerond
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Gilde.SchietScore.Domain.SchietScoreUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.CompetitieDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDatum")
                        .HasColumnType("date");

                    b.Property<bool>("IsAfgerond")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartDatum")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Competities");
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.KorpsDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitieId")
                        .HasColumnType("integer");

                    b.Property<int>("GemiddeldeScore")
                        .HasColumnType("integer");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompetitieId");

                    b.ToTable("Korpsen");
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.LidDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSchietendLid")
                        .HasColumnType("boolean");

                    b.Property<string>("KNTSNummer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Klasse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Leden");
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.ResultaatDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AantalKogels")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Datum")
                        .HasColumnType("date");

                    b.Property<int>("DeelnemerId")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<int>("WedstrijdId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeelnemerId");

                    b.HasIndex("WedstrijdId");

                    b.ToTable("Resultaten");
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.WedstrijdDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EindDatum")
                        .HasColumnType("date");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartDatum")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Wedstrijden");
                });

            modelBuilder.Entity("KorpsDtoLidDto", b =>
                {
                    b.Property<int>("KorpsenId")
                        .HasColumnType("integer");

                    b.Property<int>("LedenId")
                        .HasColumnType("integer");

                    b.HasKey("KorpsenId", "LedenId");

                    b.HasIndex("LedenId");

                    b.ToTable("KorpsDtoLidDto");
                });

            modelBuilder.Entity("LidDtoWedstrijdDto", b =>
                {
                    b.Property<int>("DeelnemersId")
                        .HasColumnType("integer");

                    b.Property<int>("WedstrijdenId")
                        .HasColumnType("integer");

                    b.HasKey("DeelnemersId", "WedstrijdenId");

                    b.HasIndex("WedstrijdenId");

                    b.ToTable("LidDtoWedstrijdDto");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.KorpsDto", b =>
                {
                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.CompetitieDto", "Competitie")
                        .WithMany("Korpsen")
                        .HasForeignKey("CompetitieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competitie");
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.ResultaatDto", b =>
                {
                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.LidDto", "Deelnemer")
                        .WithMany()
                        .HasForeignKey("DeelnemerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.WedstrijdDto", "Wedstrijd")
                        .WithMany("Resultaten")
                        .HasForeignKey("WedstrijdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deelnemer");

                    b.Navigation("Wedstrijd");
                });

            modelBuilder.Entity("KorpsDtoLidDto", b =>
                {
                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.KorpsDto", null)
                        .WithMany()
                        .HasForeignKey("KorpsenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.LidDto", null)
                        .WithMany()
                        .HasForeignKey("LedenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LidDtoWedstrijdDto", b =>
                {
                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.LidDto", null)
                        .WithMany()
                        .HasForeignKey("DeelnemersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gilde.SchietScore.Persistence.Dtos.WedstrijdDto", null)
                        .WithMany()
                        .HasForeignKey("WedstrijdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Gilde.SchietScore.Domain.SchietScoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Gilde.SchietScore.Domain.SchietScoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gilde.SchietScore.Domain.SchietScoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Gilde.SchietScore.Domain.SchietScoreUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.CompetitieDto", b =>
                {
                    b.Navigation("Korpsen");
                });

            modelBuilder.Entity("Gilde.SchietScore.Persistence.Dtos.WedstrijdDto", b =>
                {
                    b.Navigation("Resultaten");
                });
#pragma warning restore 612, 618
        }
    }
}