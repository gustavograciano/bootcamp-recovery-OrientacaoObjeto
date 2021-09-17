using Dapper;
using ListagemDeProdutos.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace ListagemDeProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

                var configuration = builder.Build();
                var conexao = configuration["ConnectionStrings:DefaultConnection"];

                if (string.IsNullOrEmpty(conexao) || string.IsNullOrWhiteSpace(conexao))
                {
                    Console.WriteLine($"String de conexao nao encontrada");
                    return;
                }

                var produtos = ExecutarConsulta(conexao);

                // Filtrar, Ordenar, Agrupar, Selecionar
                Console.WriteLine("Favor informe a operacao a ser feita (1 - Filtrar, 2 - Ordenar, 3 - Agrupar e 4 - Selecionar):");
                var operacao = CapturarInformacoesInt("operacao", 1, 4);

                // Id, Nome, Data de Valida , Valor
                Console.WriteLine("Favor informe o campo a ser feita a operacao (1 - Id, 2 - Nome, 3 - Validade e 4 - Valor):");
                var campo = CapturarInformacoesInt("operacao", 1, 4);

                List<Produto> produtosFinal = new List<Produto>();
                switch (operacao)
                {
                    case 1:
                        produtosFinal = FiltrarLista(produtos, campo);
                        ExibirResultadoFinal(produtosFinal);
                        break;
                    case 2:
                        produtosFinal = OrdernarLista(produtos, campo);
                        ExibirResultadoFinal(produtosFinal);
                        break;
                    case 3:
                        AgruparLista(produtos, campo);
                        return;
                    case 4:
                        SelecionarLista(produtos, campo);
                        return;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu erro ao executar operacao, tente novamente");
            }
        }

        private static void AgruparLista(IEnumerable<Produto> produtos, int campo)
        {

            switch (campo)
            {
                case 1:
                    var group = produtos.GroupBy(produto => produto.Id).ToList();
                    group.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Id: {resultado.Key}, Total de Registro: {resultado.Count()}");
                    });
                    break;
                case 2:
                    var group2 = produtos.GroupBy(produto => produto.Nome).ToList();
                    group2.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Nome: {resultado.Key}, Total de Registro: {resultado.Count()}");
                    });
                    break;
                case 3:
                    var group3 = produtos.GroupBy(produto => produto.DataValidade).ToList();
                    group3.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Validade: {resultado.Key}, Total de Registro: {resultado.Count()}");
                    });
                    break;
                case 4:
                    var group4 = produtos.GroupBy(produto => produto.Valor).ToList();
                    group4.ForEach(resultado =>
                    {
                        Console.WriteLine($"Agrupado por Valor: {resultado.Key}, Total de Registro: {resultado.Count()}");
                    });
                    break;
                default: return;
            }
        }

        private static void SelecionarLista(IEnumerable<Produto> produtos, int campo)
        {
            switch (campo)
            {
                case 1:
                    var result = produtos.Select(produto => produto.Id).ToList();
                    result.ForEach(resultado =>
                    {
                        Console.WriteLine($"Id: {resultado}");
                    });
                    break;
                case 2:
                    var result2 = produtos.Select(produto => produto.Nome).ToList();
                    result2.ForEach(resultado =>
                    {
                        Console.WriteLine($"Nome: {resultado}");
                    });
                    break;
                case 3:
                    var result3 = produtos.Select(produto => produto.DataValidade).ToList();
                    result3.ForEach(resultado =>
                    {
                        Console.WriteLine($"Validade: {resultado.ToShortDateString()}");
                    });
                    break;
                case 4:
                    var result4 = produtos.Select(produto => produto.Valor).ToList();
                    result4.ForEach(resultado =>
                    {
                        Console.WriteLine($"Valor: {resultado}");
                    });
                    break;
                default: return;
            }
        }

        private static List<Produto> FiltrarLista(IEnumerable<Produto> produtos, int campo)
        {
            Console.WriteLine("Favor informe o valor a ser filtrado:");
            var valor = Console.ReadLine();

            switch (campo)
            {
                case 1:
                    var valorInt = int.Parse(valor);

                    //return produtos.Where(produto => produto.Id == valorInt).ToList();
                    return (from produto in produtos
                            where produto.Id == valorInt
                            select produto).ToList();
                case 2:
                    //return produtos.Where(produto => produto.Nome.Contains(valor)).ToList();
                    return (from produto in produtos
                            where produto.Nome.Contains(valor)
                            select produto).ToList();
                case 3:
                    var valorDateTime = DateTime.Parse(valor);

                    //return produtos.Where(produto => produto.DataValidade == valorDateTime).ToList();
                    return (from produto in produtos
                            where produto.DataValidade == valorDateTime
                            select produto).ToList();
                case 4:
                    var valorDecimal = decimal.Parse(valor);

                    //return produtos.Where(produto => produto.Valor == valorDecimal).ToList();
                    return (from produto in produtos
                            where produto.Valor == valorDecimal
                            select produto).ToList();
                default: return null;
            }
        }

        private static List<Produto> OrdernarLista(IEnumerable<Produto> produtos, int campo)
        {
            Console.WriteLine("Favor informe o tipo de ordenacaoo (1 - Crescente, 2 - Decrescente):");
            var tipoDeOrdenacao = CapturarInformacoesInt("operacao", 1, 2);

            switch (campo)
            {
                case 1:
                    if(tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.Id).ToList();
                    }else
                    {
                        return produtos.OrderByDescending(p => p.Id).ToList();
                    }
                case 2:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.Nome).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.Nome).ToList();
                    }
                case 3:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.DataValidade).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.DataValidade).ToList();
                    }
                case 4:
                    if (tipoDeOrdenacao == 1)
                    {
                        return produtos.OrderBy(p => p.Valor).ToList();
                    }
                    else
                    {
                        return produtos.OrderByDescending(p => p.Valor).ToList();
                    }
                default: return null;
            }
        }

        private static IEnumerable<Produto> ExecutarConsulta(string conexao)
        {
            using (var db = new SqlConnection(conexao))
            {
                return db.Query<Produto>("Select ID, NOME, DATA_VALIDADE as DataValidade, VALOR From TB_PRODUTO");
            }
        }

        private static void ExibirResultadoFinal(List<Produto> listaFinal)
        {
            listaFinal.ForEach(produto =>
            {
                Console.WriteLine($"Id: {produto.Id} - nome: {produto.Nome}" +
                        $" - validade: {produto.DataValidade.ToShortDateString()}" +
                        $" - valor : R${produto.Valor}");
            });
        }

        private static int CapturarInformacoesInt(string tipoDeInfo, int? valorMinimo, int? valorMaximo)
        {
            var infoStr = Console.ReadLine();
            if (string.IsNullOrEmpty(infoStr) || string.IsNullOrWhiteSpace(infoStr))
            {
                Console.WriteLine($"{tipoDeInfo} e obrigatorio");
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
                Console.WriteLine($"{tipoDeInfo} nao e valido");
                return 0;
            }
        }
    }
}
