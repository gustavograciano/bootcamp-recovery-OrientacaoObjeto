using System;
using System.Collections.Generic;

namespace EntendendoOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var validade = new DateTime(2021, 9, 1);
            Produto cafe = new Produto() 
            { 
                Id = 1,
                Nome = "Cafe 3 coracoes",
                Descricao = "Cafe premium torrado embalado a vacuo",
                Tipo = "alimento",
                Valor = 9.75m
            };
            cafe.AtualizarDataValidade(validade);

            Produto leite = new Produto();
            leite.Id = 2;
            leite.Nome = "Leite UHT Integral";
            leite.Descricao = "Leite integral UHT pasteurizado";
            leite.Tipo = "alimento";
            leite.Valor = 4.85m;
            leite.AtualizarDataValidade(new DateTime(2021,9,13));

            if(!cafe.IsProdutoValido())
            {
                Console.WriteLine("Cafe vencido");
            }

            if (!leite.IsProdutoValido())
            {
                Console.WriteLine("Leite vencido");
            }

            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "Rafael Thomazelli",
                IsMaiorDeIdade = true
            };

            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nome = "Administrador",
                Demissao = null
            };

            Pessoa[] pessoas = new Pessoa[] { cliente, usuario};
            //List<Pessoa> pessoas = new List<Pessoa>();
            //pessoas.Add(cliente);
            //pessoas.Add(usuario);

            foreach(var p in pessoas)
            {
                if(p is Cliente)
                {
                    Console.WriteLine($"Cliente: {p.Nome}, e maior de idade? {((Cliente)p).IsMaiorDeIdade}");
                }
                else if(p is Usuario)
                {
                    Console.WriteLine($"Usuario: {p.Nome}, e foi demitido? {((Usuario)p).Demissao}");
                }
                else
                {
                    Console.WriteLine($"Pessoa: {p.Nome}");
                }
            }
        }
    }
}
