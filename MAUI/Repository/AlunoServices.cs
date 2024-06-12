using MAUI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Repository;
    
public class AlunoServices : IAlunoRepository
{
    public async Task<Aluno> Login(string username, string password)
    {
        var client = new HttpClient();
        string url = "https://localhost:7029/api/Alunos/" + username + "/" + password;
        client.BaseAddress = new Uri(url);  
        HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Aluno aluno = JsonConvert.DeserializeObject<Aluno>(content);
            return await Task.FromResult(aluno);
        }
        return null!;


    }
}

