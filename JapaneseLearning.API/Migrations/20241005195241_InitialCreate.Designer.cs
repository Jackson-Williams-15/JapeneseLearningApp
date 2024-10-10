﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JapaneseLearning.Migrations
{
    [DbContext(typeof(LearningAppContext))]
    [Migration("20241005195241_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("JapaneseLearning.Models.ExampleSentences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastFetched")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PartOfSpeechId")
                        .HasColumnType("int");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Source")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Translation")
                        .HasColumnType("longtext");

                    b.Property<int>("VocabularyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartOfSpeechId");

                    b.HasIndex("VocabularyId");

                    b.ToTable("ExampleSentences");
                });

            modelBuilder.Entity("JapaneseLearning.Models.PartOfSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("PartsOfSpeech");
                });

            modelBuilder.Entity("JapaneseLearning.Models.VocabWords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastFetched")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Meaning")
                        .HasColumnType("longtext");

                    b.Property<string>("Reading")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Romaji")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Source")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Vocabulary");
                });

            modelBuilder.Entity("JapaneseLearning.Models.ExampleSentences", b =>
                {
                    b.HasOne("JapaneseLearning.Models.PartOfSpeech", "PartOfSpeech")
                        .WithMany("ExampleSentences")
                        .HasForeignKey("PartOfSpeechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JapaneseLearning.Models.VocabWords", "Vocabulary")
                        .WithMany("ExampleSentences")
                        .HasForeignKey("VocabularyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartOfSpeech");

                    b.Navigation("Vocabulary");
                });

            modelBuilder.Entity("JapaneseLearning.Models.PartOfSpeech", b =>
                {
                    b.Navigation("ExampleSentences");
                });

            modelBuilder.Entity("JapaneseLearning.Models.VocabWords", b =>
                {
                    b.Navigation("ExampleSentences");
                });
#pragma warning restore 612, 618
        }
    }
}
