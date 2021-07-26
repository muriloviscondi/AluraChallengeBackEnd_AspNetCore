﻿// <auto-generated />
using System;
using AluraChallenge.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AluraChallenge.Infra.Migrations
{
    [DbContext(typeof(AluraChallengeContext))]
    [Migration("20210726134027_CreateCategory")]
    partial class CreateCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AluraChallenge.Domain.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(450)")
                        .HasMaxLength(450);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AluraChallenge.Domain.Entities.Video", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(450)")
                        .HasMaxLength(450);

                    b.Property<string>("CategoryId")
                        .HasColumnType("character varying(450)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("AluraChallenge.Domain.Entities.Video", b =>
                {
                    b.HasOne("AluraChallenge.Domain.Entities.Category", "Category")
                        .WithMany("Videos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}