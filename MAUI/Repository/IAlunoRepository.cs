using MAUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Repository;
 public interface IAlunoRepository
{
        Task<Aluno> Login(string username,string password);
}
