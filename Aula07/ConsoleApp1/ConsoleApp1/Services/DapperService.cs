using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using ConsoleApp1.Models;
using System.Linq;

namespace ConsoleApp1.Services
{
    class DapperService
    {
        public static void ConsultarLinhas(string conexao)
        {
            using(var db = new SqlConnection(conexao))
            {
                var alunos = db.Query<Aluno>("Select ID, NOME, DATA_NASCIMENTO as DataNascimento, RG From TB_ALUNO").ToList();

                foreach(var aluno in alunos)
                {
                    Console.WriteLine($"Id {aluno.Id} - Aluno : {aluno.Nome} - Data de nascimento: {aluno.DataNascimento.ToShortDateString()} - RG: {aluno.Rg}");
                }
            }
        }
    }
}
