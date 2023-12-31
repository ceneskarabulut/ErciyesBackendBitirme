﻿// <auto-generated />
using System;
using BitirmeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitirmeApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231121200004_NullableKullaniciId")]
    partial class NullableKullaniciId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("BitirmeApp.Data.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("KategoriAciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("KategoriAd")
                        .HasColumnType("TEXT");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("BitirmeApp.Data.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciAd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("BitirmeApp.Data.Makale", b =>
                {
                    b.Property<int>("MakaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int>("KategoriId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resim")
                        .HasColumnType("TEXT");

                    b.Property<string>("İcerik")
                        .HasColumnType("TEXT");

                    b.HasKey("MakaleId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Makaleler");
                });

            modelBuilder.Entity("BitirmeApp.Data.PasswordCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("PasswordCodes");
                });

            modelBuilder.Entity("BitirmeApp.Data.Yorum", b =>
                {
                    b.Property<int>("YorumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MakaleId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OlusturmaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("YorumAciklama")
                        .HasColumnType("TEXT");

                    b.HasKey("YorumId");

                    b.HasIndex("KullaniciId");

                    b.HasIndex("MakaleId");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("BitirmeApp.Data.Makale", b =>
                {
                    b.HasOne("BitirmeApp.Data.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitirmeApp.Data.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("BitirmeApp.Data.PasswordCode", b =>
                {
                    b.HasOne("BitirmeApp.Data.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("BitirmeApp.Data.Yorum", b =>
                {
                    b.HasOne("BitirmeApp.Data.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitirmeApp.Data.Makale", "Makale")
                        .WithMany("Yorums")
                        .HasForeignKey("MakaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Makale");
                });

            modelBuilder.Entity("BitirmeApp.Data.Makale", b =>
                {
                    b.Navigation("Yorums");
                });
#pragma warning restore 612, 618
        }
    }
}
