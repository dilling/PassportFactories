﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PassportCodeChallenge.Data;

namespace PassportCodeChallenge.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181218081744_arrayConversion")]
    partial class arrayConversion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("PassportCodeChallenge.Models.Factory", b =>
                {
                    b.Property<int>("FactoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Children");

                    b.Property<string>("Name");

                    b.HasKey("FactoryId");

                    b.ToTable("Factories");
                });
#pragma warning restore 612, 618
        }
    }
}