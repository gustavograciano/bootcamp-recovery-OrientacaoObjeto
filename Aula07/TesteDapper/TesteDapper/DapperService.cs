using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TesteDapper
{
    class DapperService
    {
        public static void ConsultarLinhas (string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {

                var clientes = db.Query<Cliente>("Select Top 10 ClienteId,Nome,Idade,Pais From ClientesCursoImpacta");
                
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(new string('*', 20));
                    Console.WriteLine("\nID: " + cliente.ClienteId.ToString());
                    Console.WriteLine("Nome : " + cliente.Nome);
                    Console.WriteLine("Idade: " + cliente.Idade.ToString());
                    Console.WriteLine("Pais : " + cliente.Pais + "\n");
                    Console.WriteLine(new string('*', 20));
                }
                Console.ReadLine();
            }
        }
    }
}
