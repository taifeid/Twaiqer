﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Twitter.Data;

namespace Twitter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210620151614_AddAllTableAndRelations")]
    partial class AddAllTableAndRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Twitter.Models.FollowModel", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("followerId")
                        .HasColumnType("int");

                    b.HasKey("userId", "followerId");

                    b.HasIndex("followerId");

                    b.ToTable("Follow");
                });

            modelBuilder.Entity("Twitter.Models.ProfileModel", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<string>("DateOfJoin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTweets")
                        .HasColumnType("int");

                    b.Property<string>("ProfileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalFollowers")
                        .HasColumnType("int");

                    b.Property<int>("TotalFollowing")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Twitter.Models.TweetModel", b =>
                {
                    b.Property<int>("TweetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TweetContent")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<DateTime>("TweetDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("Twitter.Models.UserModel", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Twitter.Models.FollowModel", b =>
                {
                    b.HasOne("Twitter.Models.UserModel", "follower")
                        .WithMany("UserFollowing")
                        .HasForeignKey("followerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Twitter.Models.UserModel", "user")
                        .WithMany("UserFollowers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("follower");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Twitter.Models.ProfileModel", b =>
                {
                    b.HasOne("Twitter.Models.UserModel", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Twitter.Models.ProfileModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Models.TweetModel", b =>
                {
                    b.HasOne("Twitter.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Models.UserModel", b =>
                {
                    b.Navigation("Profile");

                    b.Navigation("UserFollowers");

                    b.Navigation("UserFollowing");
                });
#pragma warning restore 612, 618
        }
    }
}
