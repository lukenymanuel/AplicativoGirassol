using API.Model;

namespace API.Models;
public class Nota
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public Aluno? Aluno { get; set; }
    public Professor? Professor{ get; set; }
    public Disciplina? Disciplina { get; set; } // Adicionado
    public string? Prova {  get; set; } // se é p1 , p2 oou pt
   // public int trimestre{ get; set; } 

}
