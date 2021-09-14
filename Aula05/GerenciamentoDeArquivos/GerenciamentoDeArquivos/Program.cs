using System;
using System.IO;

namespace GerenciamentoDeArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Favor informe o nome do arquivo que vai ser gerenciado (ex. nome.txt / teste.csv)");
                var nome = Console.ReadLine();

                if(string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome) ||
                    nome.Length < 5 || (!nome.Contains(".txt") && !nome.Contains(".csv")))
                {
                    Console.WriteLine("Nome invalido, favor refaca a operacao");
                    return;
                }

                Console.WriteLine("Favor informe a operacao a realizar: (1 - deletar, 2 - criar, 3 - atualizar e 4 - selecionar)");
                var operacaoTxt = Console.ReadLine();
                int operacao = int.Parse(operacaoTxt);

                var arquivo = new ArquivoCRUD(nome);
                switch (operacao)
                {
                    case 1:
                        arquivo.DeletarArquivo();
                        break;
                    case 2:
                        arquivo.CriarArquivo();
                        break;
                    case 3:
                        arquivo.AtualizarArquivo();
                        break;
                    case 4:
                        arquivo.ListarArquivo();
                        break;
                    default:
                        throw new ArgumentException("valor informado nao e um dos numeros disponiveis, favor refaca a operacao");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Numero informado nulo, favor refaca a operacao");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Numero informado nao e um inteiro, favor refaca a operacao");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numero informado e maior que um inteiro, favor refaca a operacao");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
