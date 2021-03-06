﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenLibraryLabelImg.Data;

namespace OpenLibraryLabelImg.Migrations
{
    [DbContext(typeof(AnnotationContext))]
    partial class AnnotationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnnotationClassAnnotationCollection", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionsId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "CollectionsId");

                    b.HasIndex("CollectionsId");

                    b.ToTable("AnnotationClassAnnotationCollection");
                });

            modelBuilder.Entity("AnnotationCollectionYoloNet", b =>
                {
                    b.Property<int>("CollectionsId")
                        .HasColumnType("int");

                    b.Property<int>("NetsId")
                        .HasColumnType("int");

                    b.HasKey("CollectionsId", "NetsId");

                    b.HasIndex("NetsId");

                    b.ToTable("AnnotationCollectionYoloNet");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnotaionImageId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnnotaionImageId");

                    b.HasIndex("ClassId");

                    b.ToTable("AnnotationBox");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassLabel")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ColorArgb")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassLabel")
                        .IsUnique()
                        .HasFilter("[ClassLabel] IS NOT NULL");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BasePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnnotationCollectionId")
                        .HasColumnType("int");

                    b.Property<bool>("Excluded")
                        .HasColumnType("bit");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResolutionX")
                        .HasColumnType("int");

                    b.Property<int>("ResolutionY")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnotationCollectionId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.YoloNet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataFolderPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TargetXResolution")
                        .HasColumnType("int");

                    b.Property<int>("TargetYResolution")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeightFolderPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoloFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nets");
                });

            modelBuilder.Entity("AnnotationClassAnnotationCollection", b =>
                {
                    b.HasOne("OpenLibraryLabelImg.Model.AnnotationClass", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenLibraryLabelImg.Model.AnnotationCollection", null)
                        .WithMany()
                        .HasForeignKey("CollectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnnotationCollectionYoloNet", b =>
                {
                    b.HasOne("OpenLibraryLabelImg.Model.AnnotationCollection", null)
                        .WithMany()
                        .HasForeignKey("CollectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenLibraryLabelImg.Model.YoloNet", null)
                        .WithMany()
                        .HasForeignKey("NetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationBox", b =>
                {
                    b.HasOne("OpenLibraryLabelImg.Model.AnnotationImage", "AnnotaionImage")
                        .WithMany("Boxes")
                        .HasForeignKey("AnnotaionImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenLibraryLabelImg.Model.AnnotationClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnnotaionImage");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationImage", b =>
                {
                    b.HasOne("OpenLibraryLabelImg.Model.AnnotationCollection", null)
                        .WithMany("Images")
                        .HasForeignKey("AnnotationCollectionId");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationCollection", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("OpenLibraryLabelImg.Model.AnnotationImage", b =>
                {
                    b.Navigation("Boxes");
                });
#pragma warning restore 612, 618
        }
    }
}
