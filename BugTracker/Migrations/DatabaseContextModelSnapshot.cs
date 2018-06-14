﻿// <auto-generated />
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BugTracker.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("BugTracker.Models.Bug", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcceptanceCriteria");

                    b.Property<string>("Assignee");

                    b.Property<DateTime>("CreatedAtUTC")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("StoryPoints");

                    b.Property<DateTime>("UpdatedAtUTC");

                    b.Property<int>("priority");

                    b.Property<int>("state");

                    b.HasKey("Id");

                    b.ToTable("Bugs");
                });
#pragma warning restore 612, 618
        }
    }
}
