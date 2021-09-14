using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerenciamentoDeArquivos
{
    class ArquivoCRUD
    {
        private string CaminhoPadrao = @"C:\teste-arquivos\";
        private string Nome;
        private string CaminhoCompleto;

        public ArquivoCRUD(string nome)
        {
            Nome = nome;
            CaminhoCompleto = CaminhoPadrao + Nome;
        }

        public void DeletarArquivo()
        {
            if (File.Exists(CaminhoCompleto))
            {
                File.Delete(CaminhoCompleto);
                if (!File.Exists(CaminhoCompleto))
                {
                    Console.WriteLine($"Arquivo {Nome} deletado com sucesso");
                }
                else
                {
                    Console.WriteLine($"Arquivo {Nome} nao pode ser deletado");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
            }
        }

        public void ListarArquivo()
        {
            if (File.Exists(CaminhoCompleto))
            {
                using(StreamReader sr = File.OpenText(CaminhoCompleto))
                {
                    string linha;
                    int index = 1;

                    Console.WriteLine($"");
                    Console.WriteLine($"");
                    Console.WriteLine($"Arquivo {Nome} iniciando leitura");
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"linha: {index++} - conteudo: {linha}");
                    }

                    Console.WriteLine($"Arquivo {Nome} lido com sucesso");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe na pasta de gerenciamento");
            }
        }

        public void CriarArquivo()
        {
            if (!File.Exists(CaminhoCompleto))
            {
                EfetuarCapturaLinhasParaArquivo(null);
                Console.WriteLine($"Arquivo {Nome} criado e preenchido com sucesso");
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} ja existe no gerenciamento de arquivos");
            }
        }

        public void AtualizarArquivo()
        {
            if (File.Exists(CaminhoCompleto))
            {
                List<string> jaExistentes = new List<string>();
                using (StreamReader sr = File.OpenText(CaminhoCompleto))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        jaExistentes.Add(linha);
                    }
                }
                EfetuarCapturaLinhasParaArquivo(jaExistentes);
                Console.WriteLine($"Arquivo {Nome} atualizado com sucesso");
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} nao existe no gerenciamento de arquivos");
            }
        }

        private void EfetuarCapturaLinhasParaArquivo(List<string> jaExistentes)
        {
            List<string> linhas;
            if (jaExistentes != null && jaExistentes.Count > 0)
            {
                linhas = jaExistentes;
            }
            else
            {
                linhas = new List<string>();
            }

            string linha;
            string concluiuProcessamento;
            bool pararProcessamento = false;

            do
            {
                Console.WriteLine("Favor informe a linha a ser incluida no arquivo (termine a digitacao com enter para a proxima instrucao)");
                linha = Console.ReadLine();

                if (!string.IsNullOrEmpty(linha) && !string.IsNullOrEmpty(linha))
                {
                    Console.WriteLine("Concluiu o preenchimento do arquivo? (S - Sim e N - Nao)");
                    concluiuProcessamento = Console.ReadLine();

                    if (concluiuProcessamento.Trim().ToUpper() == "S" || concluiuProcessamento.Trim().ToUpper() == "SIM")
                    {
                        pararProcessamento = true;
                    }

                    linhas.Add(linha);
                }
            } while (pararProcessamento == false);

            using (StreamWriter sw = File.CreateText(CaminhoCompleto))
            {
                foreach (var l in linhas)
                {
                    sw.WriteLine(l);
                }
            }
        }
    }
}
