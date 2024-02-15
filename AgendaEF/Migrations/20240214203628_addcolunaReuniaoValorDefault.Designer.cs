﻿// <auto-generated />
using System;
using AgendaEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaEF.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20240214203628_addcolunaReuniaoValorDefault")]
    partial class addcolunaReuniaoValorDefault
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendaEF.Models.Reuniao", b =>
                {
                    b.Property<int>("ReuniaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReuniaoId"));

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataReuniao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ReuniaoAtiva")
                        .HasColumnType("bit");

                    b.HasKey("ReuniaoId");

                    b.ToTable("Reunioes");
                });

            modelBuilder.Entity("AgendaEF.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarefaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReuniaoId")
                        .HasColumnType("int");

                    b.Property<bool>("TarefaAtiva")
                        .HasColumnType("bit");

                    b.HasKey("TarefaId");

                    b.HasIndex("ReuniaoId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("AgendaEF.Models.Tarefa", b =>
                {
                    b.HasOne("AgendaEF.Models.Reuniao", "Reuniao")
                        .WithMany("Tarefas")
                        .HasForeignKey("ReuniaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reuniao");
                });

            modelBuilder.Entity("AgendaEF.Models.Reuniao", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
