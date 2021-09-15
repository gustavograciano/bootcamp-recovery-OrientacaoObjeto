using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using ConsoleApp1.Models;
using System.Linq;
using ConsoleApp1.Utils;

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
                    Console.WriteLine($"Id {aluno.Id} - Aluno : {aluno.Nome} - Data de nascimento: {aluno.DataNascimento.FormatarDataSistema()} - RG: {aluno.Rg}");
                }
            }
        }

        public static void CriarAluno(string conexao)
        {
            var aluno = ObterDadosAluno();

            if (aluno == null)
            {
                return;
            }

            using (var db = new SqlConnection(conexao))
            {
                var query = @"INSERT INTO TB_ALUNO (NOME, DATA_NASCIMENTO, RG)
                                    VALUES (@Nome, @DataNascimento, @Rg)";
                db.Execute(query, aluno);

                Console.WriteLine("Aluno criado com sucesso!");
            }
        }

        public static void AtualizarAluno(string conexao)
        {
            int id = CapturarInformacoesInt("Id", null, null);
            if(id == 0) { return; }

            var aluno = ObterDadosAluno();

            if (aluno == null)
            {
                return;
            }

            aluno.Id = id;

            using (var db = new SqlConnection(conexao))
            {
                var query = @"UPDATE TB_ALUNO SET Nome=@Nome, DATA_NASCIMENTO=@DataNascimento,RG=@Rg Where ID=@Id";
                db.Execute(query, aluno);

                Console.WriteLine("Aluno atualizado com sucesso!");
            }
        }


        public static void RemoverAluno(string conexao)
        {
            int id = CapturarInformacoesInt("Id", null, null);
            if (id == 0) { return; }

            using (var db = new SqlConnection(conexao))
            {
                var query = @"DELETE FROM TB_ALUNO WHERE ID="+id;
                db.Execute(query);

                Console.WriteLine("Aluno removido com sucesso!");
            }
        }

        private static Aluno ObterDadosAluno()
        {
            Console.WriteLine("Informe qual o nome do aluno atualizado:");
            var nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome do Aluno e obrigatorio");
                return null;
            }

            var diaNascimento = CapturarInformacoesInt("dia de nascimento", 1, 31);
            if (diaNascimento == 0) { return null; }
            var mesNascimento = CapturarInformacoesInt("mes de nascimento", 1, 12);
            if (mesNascimento == 0) { return null; }
            var anoNascimento = CapturarInformacoesInt("ano de nascimento", 1901, 2100);
            if (anoNascimento == 0) { return null; }

            Console.WriteLine("Informe qual o rg do aluno a ser atualizado:");
            var rg = Console.ReadLine();

            var aluno = new Aluno()
            {
                Nome = nome,
                Rg = rg,
                DataNascimento = new DateTime(anoNascimento, mesNascimento, diaNascimento)
            };

            return aluno;
        }

        private static int CapturarInformacoesInt(string tipoDeInfo, int? valorMinimo, int? valorMaximo)
        {
            var mensagem = $"Informe qual o {tipoDeInfo} do usuario";
            if(valorMinimo != null || valorMaximo != null)
            {
                mensagem += $" ({valorMinimo} a {valorMaximo}):";
            }
            else
            {
                mensagem += ":";
            }

            Console.WriteLine(mensagem);
            var infoStr = Console.ReadLine();
            if (string.IsNullOrEmpty(infoStr) || string.IsNullOrWhiteSpace(infoStr))
            {
                Console.WriteLine($"{tipoDeInfo} do Aluno e obrigatorio");
                return 0;
            }

            int info;
            try
            {
                info = int.Parse(infoStr);

                if ((valorMinimo != null && info < valorMinimo) || 
                    (valorMaximo != null && info > valorMaximo))
                {
                    throw new Exception();
                }

                return info;
            }
            catch (Exception)
            {
                Console.WriteLine($"{tipoDeInfo} do Aluno nao e valido");
                return 0;
            }
        }
    }
}
