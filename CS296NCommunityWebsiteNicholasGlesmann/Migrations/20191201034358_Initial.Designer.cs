﻿// <auto-generated />
using System;
using CS295NCommunityWebsiteNicholasGlesmann.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS295NCommunityWebsiteNicholasGlesmann.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191201034358_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab1Part2SkeletalCommunityWebsite.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("IsResponse");

                    b.Property<int?>("MessageID1");

                    b.Property<string>("MessagePriority");

                    b.Property<string>("MessageText");

                    b.Property<string>("MessageTitle");

                    b.Property<string>("Name");

                    b.Property<string>("Recipient");

                    b.HasKey("MessageID");

                    b.HasIndex("MessageID1");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Lab1Part2SkeletalCommunityWebsite.Models.Response", b =>
                {
                    b.Property<int>("ResponseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<string>("Recipient");

                    b.Property<string>("ResponseText");

                    b.Property<string>("ResponseTitle");

                    b.HasKey("ResponseID");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Lab1Part2SkeletalCommunityWebsite.Models.SignificantPerson", b =>
                {
                    b.Property<int>("SignificantPersonID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("League");

                    b.Property<string>("Name");

                    b.Property<string>("StarCraftRace");

                    b.HasKey("SignificantPersonID");

                    b.ToTable("SignificantPeople");
                });

            modelBuilder.Entity("Lab1Part2SkeletalCommunityWebsite.Models.Message", b =>
                {
                    b.HasOne("Lab1Part2SkeletalCommunityWebsite.Models.Message")
                        .WithMany("Responses")
                        .HasForeignKey("MessageID1");
                });
#pragma warning restore 612, 618
        }
    }
}
