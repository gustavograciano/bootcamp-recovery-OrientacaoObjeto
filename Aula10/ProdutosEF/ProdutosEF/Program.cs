using ProdutosEF.Models;
using ProdutosEF.Repositories;
using ProdutosEF.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProdutosEF
{
    class Program
    {
        private static ProdutoRepository _produtoRepository;
        private static VendaItemRepository _vendaItemRepository;
        private static VendaRepository _vendaRepository;
        private static UsuarioRepository _usuarioRepository;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Informe qual operacao voce quer realizar no banco: (" +
                    "1 - listar produtos, " +
                    "2 - criar venda, " +
                    "3 - obter vendas por usuario " +
                    "4 - total de itens vendidos do produto)");
                var opcaoStr = Console.ReadLine();
                var opcao = int.Parse(opcaoStr);

                using (var context = new ProdutosEFDBContext())
                {
                    _produtoRepository = new ProdutoRepositoryImpl(context);
                    _vendaItemRepository = new VendaItemRepositoryImpl(context);
                    _vendaRepository = new VendaRepositoryImpl(context);
                    _usuarioRepository = new UsuarioRepositoryImpl(context);

                    switch (opcao)
                    {
                        case 1:
                            var produtos = _produtoRepository.ObterProdutos();
                            ExibirProdutos(produtos);
                            break;
                        case 2:
                            SolicitarProdutosEUsuario();
                            break;
                        case 3:
                            ObterVendasPorUsuario();
                            break;
                        case 4:
                            ObterItensPorProduto();
                            break;
                        default:
                            Console.WriteLine("Opcao informada nao e valida, tente novamente!");
                            break;
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Voce informou um numero invalido, tente novamente!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Voce informou um numero invalido, tente novamente!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu erro ao processar dados via EF: " + e.Message);
            }
        }

        private static void ObterItensPorProduto()
        {
            var resultado = _produtoRepository.ObterItensPorProduto();
            foreach (var dto in resultado)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Produto: {dto.Nome} foi vendido {dto.ItensDoProdutoVendido.Sum(e => e.Quantidade)} itens");
                foreach (var item in dto.ItensDoProdutoVendido)
                {
                    Console.WriteLine($"Item: {item.Id} quantidade: {item.Quantidade}");
                }
            }
        }

        private static void ObterVendasPorUsuario()
        {
            var resultado = _vendaRepository.ObterVendasPorUsuario();
            foreach (var dto in resultado)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Usuario: {dto.Nome} vendeu {dto.QtdDeVendas} vendas no valor total de R$ {dto.ValorToralVendas}");
                foreach(var venda in dto.Vendas)
                {
                    Console.WriteLine($"Venda: {venda.Id} valor R$ {venda.Total}");
                }
            }
        }

        private static void SolicitarProdutosEUsuario()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Compra inicidada:");
            
            var idUsuario = CapturarInformacoesInt("Id o usuario", null, null);
            var usuario = _usuarioRepository.SelecionarPorId(idUsuario);
            if(usuario == null)
            {
                Console.WriteLine("Usuario informado nao encontrado! ");
                return;
            }

            bool permanecerRodando = true;
            int idProduto;
            int qtdItem;
            Produto produto;
            Venda venda = null;
            VendaItem item;
            do
            {
                idProduto = CapturarInformacoesInt("Id do produto", null, null);
                produto = _produtoRepository.SelecionarProdutoPorId(idProduto);
                if (produto == null)
                {
                    Console.WriteLine("Produto informado nao encontrado! ");
                    return;
                }

                qtdItem = CapturarInformacoesInt("Quantidade de itens vendidos", 1, 100);
                if (qtdItem == 0)
                {
                    Console.WriteLine("Quantidade invalida ");
                    return;
                }

                if(venda == null)
                {
                    venda = new Venda();
                    venda.IdUsuario = idUsuario;
                    _vendaRepository.Salvar(venda);
                }
                
                item = new VendaItem()
                {
                    IdProduto = idProduto,
                    Quantidade = qtdItem,
                    IdVenda = venda.Id
                };

                _vendaItemRepository.Salvar(item);

                venda.Total += produto.Valor * qtdItem;

                Console.WriteLine("Compra concluida? (S - Sim / N - Nao)");
                var compraConcluida = Console.ReadLine();
                if(compraConcluida.Trim().ToUpper() == "S" || compraConcluida.Trim().ToUpper() == "SIM"){
                    permanecerRodando = false;
                }

            } while (permanecerRodando == true);

            _vendaRepository.Atualizar(venda);

            Console.WriteLine("Compra concluida");
            Console.WriteLine("--------------------------------------------------");
        }

        private static void ExibirProdutos(List<Produto> produtos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Produtos Disponiveis:");
            produtos.ForEach(produto => Console.WriteLine($"Id = {produto.Id}, " +
                $"Nome = {produto.Nome}, " +
                $"Valor = {produto.Valor}, " +
                $"Validade = {produto.Validade.ToShortDateString()}"));

            Console.WriteLine("--------------------------------------------------");
        }

        private static int CapturarInformacoesInt(string tipoDeInfo, int? valorMinimo, int? valorMaximo)
        {
            var mensagem = $"Informe qual o {tipoDeInfo}";
            if (valorMinimo != null || valorMaximo != null)
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
