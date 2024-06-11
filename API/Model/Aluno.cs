using API.Models;

namespace API.Model;

public class Aluno
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public Curso? Curso { get; set; }
    public List<Nota>? Notas { get; set; }
    public Turma? Turma { get; set; }

    public int Cargo { get; set; }
}

