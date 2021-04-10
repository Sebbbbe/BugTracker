﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bugTrackerNew;

namespace bugTrackerNew.Migrations
{
    [DbContext(typeof(BugTrackerDBContext))]
    [Migration("20210410200519_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugTrackerNew.Models.Comment", b =>
                {
                    b.Property<Guid>("Comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Post_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("User_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("User_id1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Comment_id");

                    b.HasIndex("User_id");

                    b.HasIndex("User_id1");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BugTrackerNew.Models.Issue", b =>
                {
                    b.Property<Guid>("Post_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Asigned_to")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asignment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Completed_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("Project_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Project_id1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("User_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("due_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Post_id");

                    b.HasIndex("Project_id");

                    b.HasIndex("Project_id1");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("BugTrackerNew.Models.Project", b =>
                {
                    b.Property<Guid>("Project_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Project_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Project_id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BugTrackerNew.Models.User", b =>
                {
                    b.Property<Guid>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Second_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BugTrackerNew.Models.Comment", b =>
                {
                    b.HasOne("BugTrackerNew.Models.Issue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTrackerNew.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("User_id1");

                    b.Navigation("Issue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BugTrackerNew.Models.Issue", b =>
                {
                    b.HasOne("BugTrackerNew.Models.User", "User")
                        .WithMany("Issues")
                        .HasForeignKey("Project_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTrackerNew.Models.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("Project_id1");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BugTrackerNew.Models.Issue", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BugTrackerNew.Models.Project", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("BugTrackerNew.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}