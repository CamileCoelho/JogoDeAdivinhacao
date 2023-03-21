using System.Reflection.Metadata.Ecma335;

namespace JogoDeAdivinhação.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nivelDificuldade, numeroChutes, suaPontuacao = 1000;
            // Random random = new Random();
            // numeroSecreto = random.Next(1, 21);
            int numeroSecreto = 15;
            string saida = "";
            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("      Seja muito bem vindo ao jogo de adivinhação da Camile!");
                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine();
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
                    numeroChutes = 15;
                else if (nivelDificuldade == 2)
                    numeroChutes = 10;
                else
                    numeroChutes = 5;

                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("      O jogo consiste em adivinhar um número aleatório entre 1 e 20. ");
                Console.WriteLine();

                for ( int i = 1; i <= numeroChutes; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine();
                    Console.WriteLine("      Qual {0}º seu chute? ",i );
                    Console.WriteLine();
                    Console.Write("      = ");
                    string chute = Console.ReadLine();
                    int numeroChute = Convert.ToInt32(chute);

                    if (numeroChute < 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("      Você não pode chutar números negativos. Tente novamente.");
                        i--;
                        continue;
                    }

                    Console.WriteLine();
                    Console.WriteLine("      Seu {0}º chute foi: {1} ",i ,chute);
                    
                    bool acertou = numeroChute == numeroSecreto;
                    bool perdeu = i == numeroChutes;
                    bool maior = numeroChute > numeroSecreto;
                    suaPontuacao = (suaPontuacao - Math.Abs((numeroChute - numeroSecreto) / 2)) ;

                    if (acertou)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("      Parabéns, você acertou! ");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("      Sua pontuação foi de " + suaPontuacao);
                        break;
                    }
                    else
                    {

                        if (maior)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("      Seu chute foi maior que o número secreto. Tente novamente. ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("      Sua pontuação é de " + suaPontuacao);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("      Seu chute foi menor que o número secreto. Tente novamente. ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("      Sua pontuação é de " + suaPontuacao);
                        }
                    }
                    if (perdeu)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("      Você perdeu :( ");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("      O número secreto era: " + numeroSecreto);
                        Console.WriteLine();
                        Console.WriteLine("__________________________________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("      Mas não desanime, jogue novamente!");
                        Console.WriteLine();
                        Console.WriteLine("      Sua pontuação foi de " + suaPontuacao);
                        break;
                    }
                }


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                Console.WriteLine("      Obrigada por jogar :) ");
                Console.WriteLine();
                Console.WriteLine("      Você deseja sair ou jogar outra vez? Digite \"SAIR\" caso queiras parar, ou qualquer tecla para continuar. ");
                Console.WriteLine();
                Console.Write("      ");
                saida = Console.ReadLine().ToUpper();
                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine();

            } while (saida != "SAIR");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}