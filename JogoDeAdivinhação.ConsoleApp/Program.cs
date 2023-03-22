using System;
using System.Reflection.Metadata.Ecma335;

namespace JogoDeAdivinhação.ConsoleApp
{
    internal class Program
    {
        static int i, nivelDificuldade, numeroTotalChutes, suaPontuacao = 1000;
        static string saida = "";
        static string chute;
        static Random random = new Random();
        static int numeroSecreto = random.Next(1, 21);

        static void MostrarTitulo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("      Seja muito bem vindo ao jogo de adivinhação da Camile!");
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
        }
        static void EscolhaNivelDeDificuldade()
        {
            Console.WriteLine("      Escolha o nível de dificuldade do seu jogo:");
            Console.WriteLine();
            Console.WriteLine("      Fácil (1)      Médio (2)      Difícil (3)    ");
            Console.WriteLine();
            Console.Write("      = ");
            nivelDificuldade = Convert.ToInt32(Console.ReadLine());

            while (nivelDificuldade != 1 && nivelDificuldade != 2 && nivelDificuldade != 3)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("      Opção inexistente. Favor digitar um número de 1 a 3. ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("      = ");
                nivelDificuldade = Convert.ToInt32(Console.ReadLine());
            }

            if (nivelDificuldade == 1)
                numeroTotalChutes = 15;
            else if (nivelDificuldade == 2)
                numeroTotalChutes = 10;
            else
                numeroTotalChutes = 5;
        }
        static void MostrarNomeDoJogo()
        {
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("      O jogo consiste em adivinhar um número aleatório entre 1 e 20. ");
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
        }
        static string ValoresChutes()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("      Qual seu {0}º chute? ", i);
            Console.WriteLine();
            Console.Write("      = ");
            string chute = Console.ReadLine();

            return chute;
        }        
        static void ValidaçãoNumerosMenoresOuIguaisZero()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("      Você não pode chutar zero ou números negativos. Tente novamente.");
        }
        static void LeituraQuantidadeChutes(int ordemChute)
        {
            Console.WriteLine();
            Console.WriteLine("      Seu {0}º chute foi: {1} ", ordemChute, chute);
        }
        static void VisualizarMensagemValorPontuacao(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("      Sua pontuação é de " + suaPontuacao);
        }
        static void VisualizarMensagemPerdeu()
        {
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("      Você perdeu :( ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("      O número secreto era " + numeroSecreto);
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("      Mas não desanime, jogue novamente!");
        }
        static void VisualizarMensagemAcertou()
        {
            Console.WriteLine();
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("      Parabéns, você acertou! ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("      Sua pontuação foi de " + suaPontuacao);
        }
        static void PerguntarSeDesejaSairOuContinuarJoagndo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("      Obrigada por jogar :) ");
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("      Você deseja sair ou jogar outra vez? Digite \"SAIR\" \n      caso queira parar, ou qualquer tecla para continuar. ");
            Console.WriteLine();
            Console.Write("      ");
            saida = Console.ReadLine().ToUpper();
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
        }
        static void Main(string[] args)
        { 
            do
            {
                Random random = new Random();
                int numeroSecreto = random.Next(1, 21);

                Console.Clear();

                MostrarTitulo();

                EscolhaNivelDeDificuldade();

                MostrarNomeDoJogo();

                for ( i = 1; i <= numeroTotalChutes; i++)
                {
                    chute = ValoresChutes();
                    int numeroChute = Convert.ToInt32(chute);

                    if (numeroChute <= 0)
                    {
                        ValidaçãoNumerosMenoresOuIguaisZero();
                        i--;
                        continue;
                    }
                    LeituraQuantidadeChutes(i);

                    bool acertou = numeroChute == numeroSecreto;
                    bool perdeu = i == numeroTotalChutes;
                    bool maior = numeroChute > numeroSecreto;
                    suaPontuacao = (suaPontuacao - Math.Abs((numeroChute - numeroSecreto) / 2));

                    if (acertou)
                    {
                        VisualizarMensagemAcertou();
                        break;
                    }
                    else
                    {
                        if (maior)
                        {
                            VisualizarMensagemValorPontuacao("      Seu chute foi maior que o número secreto. Tente novamente. ", ConsoleColor.DarkGray);
                        }
                        else
                        {
                            VisualizarMensagemValorPontuacao("      Seu chute foi menor que o número secreto. Tente novamente. ", ConsoleColor.DarkGray);
                        }
                    }
                    if (perdeu)
                    {
                        VisualizarMensagemPerdeu();
                        break;
                    }
                }
                PerguntarSeDesejaSairOuContinuarJoagndo();
                
            } while (saida != "SAIR");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}