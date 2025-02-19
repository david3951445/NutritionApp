﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SampleDatabaseBuilder.Migrations
{
    [DbContext(typeof(SamplesContext))]
    [Migration("20241127032745_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AnalysisItem", b =>
                {
                    b.Property<int>("AnalysisItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnalysisItemCatagoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("分析項")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("單位")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("每100克含量")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AnalysisItemId");

                    b.HasIndex("AnalysisItemCatagoryId");

                    b.ToTable("AnalysisItem");
                });

            modelBuilder.Entity("AnalysisItemCatagory", b =>
                {
                    b.Property<int>("AnalysisItemCatagoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SampleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("分析項分類")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AnalysisItemCatagoryId");

                    b.HasIndex("SampleId");

                    b.ToTable("AnalysisItemCatagory");
                });

            modelBuilder.Entity("Sample", b =>
                {
                    b.Property<int>("SampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("俗名")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("內容物描述")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("整合編號")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("樣品名稱")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("樣品英文名稱")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SampleId");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("AnalysisItem", b =>
                {
                    b.HasOne("AnalysisItemCatagory", "AnalysisItemCatagory")
                        .WithMany("AnalysisItems")
                        .HasForeignKey("AnalysisItemCatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnalysisItemCatagory");
                });

            modelBuilder.Entity("AnalysisItemCatagory", b =>
                {
                    b.HasOne("Sample", "Sample")
                        .WithMany("AnalysisItemCatagories")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sample");
                });

            modelBuilder.Entity("AnalysisItemCatagory", b =>
                {
                    b.Navigation("AnalysisItems");
                });

            modelBuilder.Entity("Sample", b =>
                {
                    b.Navigation("AnalysisItemCatagories");
                });
#pragma warning restore 612, 618
        }
    }
}
