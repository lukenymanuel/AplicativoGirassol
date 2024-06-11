using MAUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Models;

public class Nota
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public Aluno Aluno { get; set; }
    public Professor Professor { get; set; }
    public Disciplina Disciplina { get; set; } // Adicionado
    public string Prova {  get; set; }
}