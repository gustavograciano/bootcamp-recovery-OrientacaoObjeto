using EntendendoOO.Models;
using EntendendoOO.Models.FormaDePagamento;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

            Produto bolacha = new Produto(3, 
                   "alimento", 
                   2.55m, 
                   new DateTime(2021, 12, 31), 
                   "Bolacha Agua e Sal", 
                   "Bolacha Agua e Sal");

            if(!cafe.IsProdutoValido())
            {
                Console.WriteLine("Cafe vencido");
            }

            if (!leite.IsProdutoValido())
            {
                Console.WriteLine("Leite vencido");
            }

            if (!bolacha.IsProdutoValido())
            {
                Console.WriteLine("Bolacha Vencida");
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

            Console.WriteLine("Digite a forma de pagamento desejada: (1 - Credito, 2 - Debito, 3 - VA, 4 - Dinheiro, 5 - Pix)");

            try
            {
                var tipoDePagamentoString = Console.ReadLine();
                var tipoDePagamento = int.Parse(tipoDePagamentoString);

                FormaDePagamento pagamento;
                switch (tipoDePagamento)
                {
                    case 1:
                        pagamento = new FormaDePagamentoCreditoImpl();
                        break;
                    case 2:
                        pagamento = new FormaDePagamentoDebitoImpl();
                        break;
                    case 3:
                        pagamento = new FormaDePagamentoVAImpl();
                        break;
                    case 4:
                        pagamento = new FormaDePagamentoDinheiro();
                        break;
                    case 5:
                        pagamento = new FormaDePagamentoPix();
                        break;
                    default:
                        throw new Exception("Nenhuma forma de pagamento encontrada");
                }

                pagamento.EfetuarPagamento();
            }
            catch (FormatException)
            {
                Console.WriteLine("Forma de pagamento invalida erro na formatacao, refaca o procedimento");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Forma de pagamento invalida argumento nulo, refaca o procedimento");
            }
            catch (Exception)
            {
                Console.WriteLine("Forma de pagamento invalida qualquer erro, refaca o procedimento");
            }
            finally
            {
                Console.WriteLine("Terminou o Try/Catch");
            }

            IFormaDePagamentoCartao teste = new FormaDePagamentoCreditoImpl();
            teste.IsCartaoComSaldo();

            ValidationUtil<string> validation = new ValidationUtil<string>();
            validation.isValid("teste");

            ValidationUtil<int> validation2 = new ValidationUtil<int>();
            validation2.isValid(12);

            ValidationUtil<bool> validation3 = new ValidationUtil<bool>();
            validation3.isValid(true);

            //var client = new HttpClient();
            //var conteudoGoogle = await client.GetStringAsync("https://google.com");
            //Console.WriteLine(conteudoGoogle);
        }
    }
}
