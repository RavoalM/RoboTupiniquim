using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Informe o limite do campo de pesquisa: ");
            string limiteInput = Console.ReadLine();

            if (!ValidarString(limiteInput))
            {
                Console.Clear();
                Console.WriteLine("Erro! Informe o limite corretamente.");
                Thread.Sleep(2000);
                continue;
            }

            string[] limiteArray = limiteInput.Split(' ');
            int xLimite = int.Parse(limiteArray[0]);
            int yLimite = int.Parse(limiteArray[1]);

            Console.Write("Informe o spawn do robo (Ex: 1 2 N): ");
            string spawnInput = Console.ReadLine().ToUpper();

            if (!Regex.IsMatch(spawnInput, @"^\d+\s\d+\s[N|S|L|O]$"))
            {
                Console.Clear();
                Console.WriteLine("Erro! Informe a posição inicial corretamente (Ex: '1 2 N').");
                Thread.Sleep(2000);
                continue;
            }

            string[] spawnArray = spawnInput.Split(' ');
            int xInicial = int.Parse(spawnArray[0]);
            int yInicial = int.Parse(spawnArray[1]);
            char direcaoInicial = char.Parse(spawnArray[2]);

            Console.Write("Informe o comando (Apenas M, D ou E): ");
            string comandosInput = Console.ReadLine().ToUpper().Trim();

            if (!Regex.IsMatch(comandosInput, @"^[MDE]+$"))
            {
                Console.Clear();
                Console.WriteLine("Erro! Comandos inválidos. Use apenas M, D ou E.");
                Thread.Sleep(2000);
                continue;
            }

            foreach (char comando in comandosInput)
            {
                if (comando == 'D')
                {
                    if (direcaoInicial == 'N')
                    {
                        direcaoInicial = 'L';
                    }
                    else if (direcaoInicial == 'L')
                    {
                        direcaoInicial = 'S';
                    }
                    else if (direcaoInicial == 'S')
                    {
                        direcaoInicial = 'O';
                    }
                    else if (direcaoInicial == 'O')
                    {
                        direcaoInicial = 'N';
                    }
                }
                else if (comando == 'E')
                {
                    if (direcaoInicial == 'N')
                    {
                        direcaoInicial = 'O';
                    }
                    else if (direcaoInicial == 'O')
                    {
                        direcaoInicial = 'S';
                    }
                    else if (direcaoInicial == 'S')
                    {
                        direcaoInicial = 'L';
                    }
                    else if (direcaoInicial == 'L')
                    {
                        direcaoInicial = 'N';
                    }
                }
                else if (comando == 'M')
                {
                    if (direcaoInicial == 'N')
                    {
                        yInicial++;
                    }
                    else if (direcaoInicial == 'S')
                    {
                        yInicial--;
                    }
                    else if (direcaoInicial == 'O')
                    {
                        xInicial--;
                    }
                    else if (direcaoInicial == 'L')
                    {
                        xInicial++;
                    }
                }
            }

            if (xInicial < 0 || xInicial > xLimite || yInicial < 0 || yInicial > yLimite)
            {
                Console.WriteLine("O robo saiu do campo de pesquisa.");
                break;
            }
            else
            {
                Console.WriteLine($"Posição final do robo: {xInicial} {yInicial} {direcaoInicial}");
                break;
            }
        }
    }

    static bool ValidarString(string input)
    {
        return Regex.IsMatch(input, @"^\d+\s\d+$");
    }
}
