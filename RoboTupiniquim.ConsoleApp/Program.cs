using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Informe o limite do campo de pesquisa: ");
        string limiteInput = Console.ReadLine();

        while (!ValidarString(limiteInput))
        {
            Console.Clear();
            Console.WriteLine("Erro! Informe o limite corretamente.");
            Thread.Sleep(2000);
            Console.Write("Informe o limite do campo de pesquisa: ");
            limiteInput = Console.ReadLine();
        }

        string[] limiteArray = limiteInput.Split(' ');
        int xLimite = int.Parse(limiteArray[0]);
        int yLimite = int.Parse(limiteArray[1]);

        List<string> posicoesFinais = new List<string>();
        List<int> robosForaDoCampo = new List<int>();

        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Informe o spawn do robo {i + 1} (Ex: 1 2 N): ");
            string spawnInput = Console.ReadLine().ToUpper();

            while (!Regex.IsMatch(spawnInput, @"^\d+\s\d+\s[N|S|L|O]$"))
            {
                Console.Clear();
                Console.WriteLine("Erro! Informe a posição inicial corretamente (Ex: '1 2 N').");
                Thread.Sleep(2000);
                Console.Write($"Informe o spawn do robo {i + 1} (Ex: 1 2 N): ");
                spawnInput = Console.ReadLine().ToUpper();
            }

            string[] spawnArray = spawnInput.Split(' ');
            int xInicial = int.Parse(spawnArray[0]);
            int yInicial = int.Parse(spawnArray[1]);
            char direcaoInicial = char.Parse(spawnArray[2]);

            Console.Write("Informe o comando (Apenas M, D ou E): ");
            string comandosInput = Console.ReadLine().ToUpper().Trim();

            while (!Regex.IsMatch(comandosInput, @"^[MDE]+$"))
            {
                Console.Clear();
                Console.WriteLine("Erro! Comandos inválidos. Use apenas M, D ou E.");
                Thread.Sleep(2000);
                Console.Write("Informe o comando (Apenas M, D ou E): ");
                comandosInput = Console.ReadLine().ToUpper().Trim();
            }

            foreach (char comando in comandosInput)
            {
                if (comando == 'D' || comando == 'E')
                {
                    direcaoInicial = Virar(direcaoInicial, comando);
                }
                else if (comando == 'M')
                {
                    (xInicial, yInicial) = MovimentarRobo(xInicial, yInicial, direcaoInicial);
                }
            }

            Resultados(xInicial, yInicial, direcaoInicial, xLimite, yLimite, i, posicoesFinais, robosForaDoCampo);

            ForaDoCampo(xInicial, yInicial, xLimite, yLimite, i, robosForaDoCampo);
        }

        PosicaoFinal(posicoesFinais);
    }
    static bool ValidarString(string input)
    {
        return Regex.IsMatch(input, @"^\d+\s\d+$");
    }

    static char Virar(char direcaoAtual, char comando)
    {
        if (comando == 'D')
        {
            if (direcaoAtual == 'N') return 'L';
            if (direcaoAtual == 'L') return 'S';
            if (direcaoAtual == 'S') return 'O';
            if (direcaoAtual == 'O') return 'N';
        }
        else if (comando == 'E')
        {
            if (direcaoAtual == 'N') return 'O';
            if (direcaoAtual == 'O') return 'S';
            if (direcaoAtual == 'S') return 'L';
            if (direcaoAtual == 'L') return 'N';
        }

        return direcaoAtual;
    }

    static (int, int) MovimentarRobo(int xInicial, int yInicial, char direcaoInicial)
    {
        if (direcaoInicial == 'N') yInicial++;
        else if (direcaoInicial == 'S') yInicial--;
        else if (direcaoInicial == 'L') xInicial++;
        else if (direcaoInicial == 'O') xInicial--;
        return (xInicial, yInicial);
    }

    static void Resultados(int xInicial, int yInicial, char direcaoInicial, int xLimite, int yLimite, int i, List<string> posicoesFinais, List<int> robosForaDoCampo)
    {
        string posicaoFinal = $"{xInicial} {yInicial} {direcaoInicial}";

        if (xInicial < 0 || xInicial > xLimite || yInicial < 0 || yInicial > yLimite)
        {
            Console.WriteLine($"O robô {i + 1} saiu do campo de pesquisa.");
            robosForaDoCampo.Add(i + 1);
        }
        else if (posicoesFinais.Contains($"{xInicial} {yInicial}"))
        {
            Console.WriteLine("Colisão detectada! Dois robôs não podem ocupar a mesma posição.");
        }
        else
        {
            posicoesFinais.Add(posicaoFinal);
            Console.WriteLine($"Posição final do robô {i + 1}: {posicaoFinal}");
        }
    }

    static void ForaDoCampo(int xInicial, int yInicial, int xLimite, int yLimite, int i, List<int> robosForaDoCampo)
    {
        if (xInicial < 0 || xInicial > xLimite || yInicial < 0 || yInicial > yLimite)
        {
            if (robosForaDoCampo.Count > 0)
            {
                Console.WriteLine("\nOs seguintes robôs saíram do campo de pesquisa:");
                foreach (var robo in robosForaDoCampo)
                {
                    Console.WriteLine($"Robô {robo}");
                }
            }
            else
            {
                Console.WriteLine("\nNenhum robô saiu do campo de pesquisa.");
            }
        }
    }

    static void PosicaoFinal(List<string> posicoesFinais)
    {
        Console.WriteLine("\nAs posições dos robôs são:");
        foreach (var posicao in posicoesFinais)
        {
            Console.WriteLine(posicao);
        }

        Console.Write("Pressione qualquer tecla para fechar...");
        Console.ReadLine();
    }
}


