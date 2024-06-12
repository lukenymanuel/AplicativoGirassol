using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_curso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_disciplina",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    curso_id = table.Column<int>(type: "integer", nullable: false),
                    CursoId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_disciplina", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_disciplina_tb_curso_CursoId1",
                        column: x => x.CursoId1,
                        principalTable: "tb_curso",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_disciplina_tb_curso_curso_id",
                        column: x => x.curso_id,
                        principalTable: "tb_curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    disciplina_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_professor", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_professor_tb_disciplina_disciplina_id",
                        column: x => x.disciplina_id,
                        principalTable: "tb_disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    curso_id = table.Column<int>(type: "integer", nullable: false),
                    DisciplinaId = table.Column<int>(type: "integer", nullable: true),
                    ProfessorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_turma", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_turma_tb_curso_curso_id",
                        column: x => x.curso_id,
                        principalTable: "tb_curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_turma_tb_disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "tb_disciplina",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_turma_tb_professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "tb_professor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_aluno = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    curso_id = table.Column<int>(type: "integer", nullable: false),
                    turma_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_aluno_tb_curso_curso_id",
                        column: x => x.curso_id,
                        principalTable: "tb_curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_aluno_tb_turma_turma_id",
                        column: x => x.turma_id,
                        principalTable: "tb_turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_nota",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    aluno_id = table.Column<int>(type: "integer", nullable: false),
                    professor_id = table.Column<int>(type: "integer", nullable: false),
                    disciplina_id = table.Column<int>(type: "integer", nullable: false),
                    prova = table.Column<string>(type: "text", nullable: true),
                    trimestre = table.Column<int>(type: "integer", nullable: false),
                    AlunoId1 = table.Column<int>(type: "integer", nullable: true),
                    ProfessorId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_nota", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_nota_tb_aluno_AlunoId1",
                        column: x => x.AlunoId1,
                        principalTable: "tb_aluno",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_nota_tb_aluno_aluno_id",
                        column: x => x.aluno_id,
                        principalTable: "tb_aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_nota_tb_disciplina_disciplina_id",
                        column: x => x.disciplina_id,
                        principalTable: "tb_disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_nota_tb_professor_ProfessorId1",
                        column: x => x.ProfessorId1,
                        principalTable: "tb_professor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_nota_tb_professor_professor_id",
                        column: x => x.professor_id,
                        principalTable: "tb_professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_aluno_curso_id",
                table: "tb_aluno",
                column: "curso_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_aluno_turma_id",
                table: "tb_aluno",
                column: "turma_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_disciplina_curso_id",
                table: "tb_disciplina",
                column: "curso_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_disciplina_CursoId1",
                table: "tb_disciplina",
                column: "CursoId1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_aluno_id",
                table: "tb_nota",
                column: "aluno_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_AlunoId1",
                table: "tb_nota",
                column: "AlunoId1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_disciplina_id",
                table: "tb_nota",
                column: "disciplina_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_professor_id",
                table: "tb_nota",
                column: "professor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_nota_ProfessorId1",
                table: "tb_nota",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_professor_disciplina_id",
                table: "tb_professor",
                column: "disciplina_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_turma_curso_id",
                table: "tb_turma",
                column: "curso_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_turma_DisciplinaId",
                table: "tb_turma",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_turma_ProfessorId",
                table: "tb_turma",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_nota");

            migrationBuilder.DropTable(
                name: "tb_aluno");

            migrationBuilder.DropTable(
                name: "tb_turma");

            migrationBuilder.DropTable(
                name: "tb_professor");

            migrationBuilder.DropTable(
                name: "tb_disciplina");

            migrationBuilder.DropTable(
                name: "tb_curso");
        }
    }
}
