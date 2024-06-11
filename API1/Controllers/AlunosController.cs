using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public AlunosController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> ReceberAlunos() => await appDbContext.Alunos.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Aluno>> AdicionarAluno(Aluno aluno)
        {
            if (aluno != null) {
                appDbContext.Alunos.Add(aluno);
                var result = await appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Invalid Request");
        }

        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<Aluno>> Login(string username, string password) 
        { 
            if(username is not null && password is not null) 
            {
                var aluno = await appDbContext.Alunos
                    .Where(x => x.Username!.ToLower().Equals(username.ToLower()) && x.Password == password)
                    .FirstOrDefaultAsync();
                return aluno != null ? Ok(aluno) : BadRequest("Aluno not found");
            }
            return BadRequest("Invalid Request");
        }
      
    }
}
