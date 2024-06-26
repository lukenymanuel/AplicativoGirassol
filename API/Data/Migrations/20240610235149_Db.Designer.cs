﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240610235149_Db")]
    partial class Db
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Model.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cargo")
                        .HasColumnType("integer");

                    b.Property<int?>("CursoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("API.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CursoId")
                        .HasColumnType("integer");

                    b.Property<string>("MatrizProva")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("API.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlunoId")
                        .HasColumnType("integer");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("integer");

                    b.Property<string>("Prova")
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cargo")
                        .HasColumnType("integer");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("API.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CursoId")
                        .HasColumnType("integer");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("API.Model.Aluno", b =>
                {
                    b.HasOne("API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.HasOne("API.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");

                    b.Navigation("Curso");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("API.Models.Disciplina", b =>
                {
                    b.HasOne("API.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("API.Models.Nota", b =>
                {
                    b.HasOne("API.Model.Aluno", "Aluno")
                        .WithMany("Notas")
                        .HasForeignKey("AlunoId");

                    b.HasOne("API.Models.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("API.Models.Professor", "Professor")
                        .WithMany("Notas")
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.HasOne("API.Models.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("API.Models.Turma", b =>
                {
                    b.HasOne("API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.HasOne("API.Models.Disciplina", null)
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("API.Models.Professor", null)
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("API.Model.Aluno", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("API.Models.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("API.Models.Disciplina", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("API.Models.Professor", b =>
                {
                    b.Navigation("Notas");

                    b.Navigation("Turmas");
                });
#pragma warning restore 612, 618
        }
    }
}
