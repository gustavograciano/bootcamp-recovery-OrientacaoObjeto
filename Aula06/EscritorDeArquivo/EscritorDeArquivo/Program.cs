using System;
using System.Collections.Generic;
using System.IO;

namespace EscritorDeArquivo
{
    class Program
    {
        static string NomeGenericoArquivo = "{{NOME_DO_ARQUIVO}}";
        static string DiretorioPadrao = @"C:\teste-arquivo-txt";
        static string CaminhoFinal = DiretorioPadrao + @"\" + NomeGenericoArquivo + ".txt";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Informe o nome do arquivo que vai ser criado (teste, arquivo01 ...):");
                var nomeDoArquivo = Console.ReadLine();

                if (string.IsNullOrEmpty(nomeDoArquivo) || string.IsNullOrWhiteSpace(nomeDoArquivo))
                {
                    Console.WriteLine("Nome do arquivo invalido, tente novamente.");
                    return;
                }

                var arquivoFinal = CaminhoFinal.Replace(NomeGenericoArquivo, nomeDoArquivo);
                if (File.Exists(arquivoFinal))
                {
                    Console.WriteLine($"Arquivo {nomeDoArquivo} ja existe na base de repositorio");
                    return;
                }
                else if (!Directory.Exists(DiretorioPadrao))
                {
                    Directory.CreateDirectory(DiretorioPadrao);
                }

                string linha;
                string conclusaoStr;
                var conclusao = false;
                List<string> linhas = new List<string>();
                do
                {
                    Console.WriteLine("Informe o texto a ser inserido no arquivo:");
                    linha = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(linha) && !string.IsNullOrEmpty(linha))
                    {
                        linhas.Add(linha);
                    }

                    Console.WriteLine("Concluiu a digitacao do arquivo? (S - Sim / N - Nao)");
                    conclusaoStr = Console.ReadLine();

                    if (conclusaoStr.Trim().ToUpper() == "S" || conclusaoStr.Trim().ToUpper() == "SIM")
                    {
                        conclusao = true;
                    }
                } while (conclusao == false);

                if(linhas.Count > 0)
                {
                    using (StreamWriter sw = File.CreateText(arquivoFinal))
                    {
                        foreach (var ln in linhas)
                        {
                            sw.WriteLine(ln);
                        }
                    }

                    Console.WriteLine($"Arquivo {nomeDoArquivo} criado com sucesso");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Ocorreu erro ao escrever dados no arquivo informado: " + e.Message);
            }
        }
    }
}
