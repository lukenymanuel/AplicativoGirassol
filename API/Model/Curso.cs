namespace API.Models;

public class Curso
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public List<Disciplina>? Disciplinas { get; set; }
}

