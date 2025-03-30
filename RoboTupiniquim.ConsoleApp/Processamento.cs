using System.Text.RegularExpressions;
namespace RoboTupiniquim.ConsoleApp;
public class Processamento
{
    static bool executando = true;
    public static void ProcessarOpcaoMenu(string opcao)
    {
        switch (opcao)
        {
            case "1":
                Console.Clear();
                IniciarRoboTupiniquim();
                break;
            case "2":
                Console.Clear();
                Mensagens.MostrarInstrucoes();
                break;
            case "3":
                Console.WriteLine("Saindo...");
                Thread.Sleep(3000);
                Environment.Exit(0);
                executando = false;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida! Pressione ENTER para tentar novamente.");
                Console.ResetColor();
                Console.ReadLine();
                break;
        }
    }

    static void IniciarRoboTupiniquim()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Início da Simulação ---");
        Console.ResetColor();

        string limiteInput = Validacao.CapturarEntrada("Informe o limite do campo de pesquisa: ",
        input => Regex.IsMatch(input, @"^\d+\s\d+$"), "Erro! Informe o limite corretamente.");

        string[] limiteArray = limiteInput.Split(' ');
        int xLimite = int.Parse(limiteArray[0]);
        int yLimite = int.Parse(limiteArray[1]);

        List<string> posicoesFinais = new List<string>();
        List<int> robosForaDoCampo = new List<int>();
        List<int> robosColididos = new List<int>();

        for (int i = 0; i < 2; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- Robo {i + 1} ---");
            Console.ResetColor();

            string spawnInput = Validacao.CapturarEntrada($"Informe as coordenadas do robô {i + 1}: ",
            input => Regex.IsMatch(input, @"^\d+\s\d+\s[N|S|L|O]$"),
            "Erro! Informe a posição inicial corretamente.");

            string[] spawnArray = spawnInput.Split(' ');
            int xInicial = int.Parse(spawnArray[0]);
            int yInicial = int.Parse(spawnArray[1]);
            char direcaoInicial = char.Parse(spawnArray[2]);

            string posicaoInicial = $"{xInicial} {yInicial} {direcaoInicial}";

            if (posicoesFinais.Any(pos => pos.StartsWith($"{xInicial} {yInicial}")))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Colisão detectada! O robô {i + 1} tentou se mover para a posição {xInicial} {yInicial}, que já está ocupada.");
                robosColididos.Add(i + 1);
                break;
            }

            string comandosInput = Validacao.CapturarEntrada("Informe o comando: ",
        input => Regex.IsMatch(input, @"^[MDE]+$"), "Erro! Comandos inválidos.");

            foreach (char comando in comandosInput)
            {
                if (comando == 'D' || comando == 'E')
                {
                    direcaoInicial = Movimentacao.Virar(direcaoInicial, comando);
                }
                else if (comando == 'M')
                {
                    (xInicial, yInicial) = Movimentacao.MovimentarRobo(xInicial, yInicial, direcaoInicial);

                    string novaPosicao = $"{xInicial} {yInicial} {direcaoInicial}";

                    if (posicoesFinais.Any(pos => pos.StartsWith($"{xInicial} {yInicial}")))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Colisão detectada! O robô {i + 1} tentou se mover para a posição {xInicial} {yInicial} {direcaoInicial}, que já está ocupada.");
                        robosColididos.Add(i + 1);
                        break;
                    }

                }
            }

            Mensagens.Resultados(xInicial, yInicial, direcaoInicial, xLimite, yLimite, i, posicoesFinais, robosForaDoCampo, robosColididos);

            Mensagens.ForaDoCampo(xInicial, yInicial, xLimite, yLimite, i, robosForaDoCampo);
        }

        Mensagens.PosicaoFinal(posicoesFinais, robosForaDoCampo, robosColididos);
    }
}
