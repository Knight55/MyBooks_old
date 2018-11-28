﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBooks.Bll.Context;
using MyBooks.Bll.Entities;

namespace MyBooks.Bll.Migrations
{
    [DbContext(typeof(MyBookContext))]
    [Migration("20181128192016_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBook.Bll.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AUTHOR");
                });

            modelBuilder.Entity("MyBook.Bll.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Fantasy");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("BOOK");
                });

            modelBuilder.Entity("MyBook.Bll.Entities.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<string>("Format")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Paperback");

                    b.Property<string>("IsbnNumber");

                    b.Property<int>("NumberOfPages");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("PublisherId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("EDITION");
                });

            modelBuilder.Entity("MyBook.Bll.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PUBLISHER");
                });

            modelBuilder.Entity("MyBook.Bll.Entities.Writing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int>("BookId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Writing");
                });

            modelBuilder.Entity("MyBook.Bll.Entities.Edition", b =>
                {
                    b.HasOne("MyBook.Bll.Entities.Book", "Book")
                        .WithMany("Editions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBook.Bll.Entities.Publisher", "Publisher")
                        .WithMany("Editions")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBook.Bll.Entities.Writing", b =>
                {
                    b.HasOne("MyBook.Bll.Entities.Author", "Author")
                        .WithMany("Writings")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBook.Bll.Entities.Book", "Book")
                        .WithMany("Writings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
