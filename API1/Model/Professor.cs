using System.ComponentModel;

namespace API.Models;

public class Professor 
{   
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public List<Turma> Turmas { get; set; }
    public List<Nota>? Notas { get; set; }
    public Disciplina? Disciplina { get; set; }

    public int Cargo { get; set; }
}
