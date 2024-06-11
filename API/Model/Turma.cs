namespace API.Models;

public class Turma
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public Curso? Curso { get; set; }

}
