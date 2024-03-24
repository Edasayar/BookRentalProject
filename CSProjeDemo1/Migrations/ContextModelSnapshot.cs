﻿// <auto-generated />
using System;
using CSProjeDemo1.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSProjeDemo1.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSProjeDemo1.Entitys.BaseBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublicationYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Books");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseBook");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LibraryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int>("MemberNumber")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.HasIndex("LibraryId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BookHistory", b =>
                {
                    b.HasBaseType("CSProjeDemo1.Entitys.BaseBook");

                    b.Property<string>("HistoricalPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.HasIndex("MemberId");

                    b.HasDiscriminator().HasValue("BookHistory");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BookNovel", b =>
                {
                    b.HasBaseType("CSProjeDemo1.Entitys.BaseBook");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.HasIndex("MemberId");

                    b.ToTable("Books", t =>
                        {
                            t.Property("MemberId")
                                .HasColumnName("BookNovel_MemberId");
                        });

                    b.HasDiscriminator().HasValue("BookNovel");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BookScience", b =>
                {
                    b.HasBaseType("CSProjeDemo1.Entitys.BaseBook");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.HasIndex("MemberId");

                    b.ToTable("Books", t =>
                        {
                            t.Property("MemberId")
                                .HasColumnName("BookScience_MemberId");
                        });

                    b.HasDiscriminator().HasValue("BookScience");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BaseBook", b =>
                {
                    b.HasOne("CSProjeDemo1.Entitys.Library", null)
                        .WithMany("Books")
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.Member", b =>
                {
                    b.HasOne("CSProjeDemo1.Entitys.Library", null)
                        .WithMany("Members")
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BookHistory", b =>
                {
                    b.HasOne("CSProjeDemo1.Entitys.Member", null)
                        .WithMany("HBorrowedBooks")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BookNovel", b =>
                {
                    b.HasOne("CSProjeDemo1.Entitys.Member", null)
                        .WithMany("NBorrowedBooks")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.BookScience", b =>
                {
                    b.HasOne("CSProjeDemo1.Entitys.Member", null)
                        .WithMany("SBorrowedBooks")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.Library", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("CSProjeDemo1.Entitys.Member", b =>
                {
                    b.Navigation("HBorrowedBooks");

                    b.Navigation("NBorrowedBooks");

                    b.Navigation("SBorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
