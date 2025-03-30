using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static bool executando = true;
    static void Main(string[] args)
    {
        while (executando)
        {
            string opcao = ExibirMenu();
            ProcessarOpcaoMenu(opcao);
        }
    }

    static void ProcessarOpcaoMenu(string opcao)
    {
        switch (opcao)
        {
            case "1":
                Console.Clear();
                IniciarRoboTupiniquim();
                break;
            case "2":
                Console.Clear();
                MostrarInstrucoes();
                break;
            case "3":
                Console.WriteLine("Saindo...");
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

    static string ExibirMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(". * : , . * * * . , : *.");
        Console.WriteLine("+=- ROBÔ TUPINIQUIM -=+");
        Console.WriteLine(". * : , . * * * . , : *.");
        Console.WriteLine("\n=== MENU PRINCIPAL ===");
        Console.WriteLine("1 - Começar Simulação");
        Console.WriteLine("2 - Instruções do Funcionário");
        Console.WriteLine("3 - Sair");
        Console.Write("Escolha uma opção: ");

        string opcao = Console.ReadLine();
        return opcao;

    }

    static void IniciarRoboTupiniquim()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Início da Simulação ---");
        Console.ResetColor();

        string limiteInput = CapturarEntrada("Informe o limite do campo de pesquisa (Ex: 5 5): ",
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

            string spawnInput = CapturarEntrada($"Informe as coordenadas do robô {i + 1}: ",
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

            string comandosInput = CapturarEntrada("Informe o comando: ",
        input => Regex.IsMatch(input, @"^[MDE]+$"), "Erro! Comandos inválidos.");

            foreach (char comando in comandosInput)
            {
                if (comando == 'D' || comando == 'E')
                {
                    direcaoInicial = Virar(direcaoInicial, comando);
                }
                else if (comando == 'M')
                {
                    (xInicial, yInicial) = MovimentarRobo(xInicial, yInicial, direcaoInicial);

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

            Resultados(xInicial, yInicial, direcaoInicial, xLimite, yLimite, i, posicoesFinais, robosForaDoCampo, robosColididos);

            ForaDoCampo(xInicial, yInicial, xLimite, yLimite, i, robosForaDoCampo);
        }

        PosicaoFinal(posicoesFinais, robosForaDoCampo, robosColididos);
    }

    static void MostrarInstrucoes()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== INSTRUÇÕES DO FUNCIONÁRIO ===");
        Console.ResetColor();
        Console.WriteLine("Prezado Funcionário da  Agência Espacial Brasileira (AEB),");
        Console.WriteLine("Gostaríamos de informar que existem protocolos estabelecidos que devem ser rigorosamente seguidos para garantir o pleno funcionamento do sistema e otimizar seu desempenho. A adesão a essas diretrizes é fundamental para a eficiência das operações e para o sucesso das nossas missões.");
        Thread.Sleep(15000);
        Console.Clear();
        Console.WriteLine("=== INSTRUÇÕES ===");
        Console.WriteLine("- O campo de pesquisa deve ser informado com um espaço entre os dois valores inteiros.");
        Console.WriteLine("- O sistema aceita tanto letras maiúsculas quanto minúsculas.");
        Console.WriteLine("- As coordenadas iniciais dos robôs devem ser informadas com um espaço entre os valores e devem ser inteiros.");
        Console.WriteLine("- Os comandos devem ser inseridos em sequência.");
        Console.WriteLine("- O robô irá girar conforme sua perspectiva.");
        Console.WriteLine("- Em hipótese alguma utilize a combinação Ctrl+Z, pois isso pode comprometer o funcionamento do sistema.");
        Console.WriteLine("- Qualquer dano às propriedades da AEB sob sua supervisão poderá resultar em desconto salarial.");
        Console.WriteLine("\n- Os comandos disponíveis são os seguintes:\nM: Movimentar\nD: Virar 90° à direita\nE: Virar 90° à esquerda");
        Console.WriteLine("\n- As direções disponíveis são as seguintes:\nN: Norte\nS: Sul\nL: Leste\nO: Oeste");
        Console.WriteLine("\n- Modelos \nModelo de inserção do campo de pesquisa: 5 5 \nModelo de Inserção de coordenas: 1 2 N \nModelo de inserção de comando: EMEMEMEMM");
        Console.WriteLine("\nPressione ENTER para retornar ao menu...");
        Console.ReadLine();

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

    static void Resultados(int xInicial, int yInicial, char direcaoInicial, int xLimite, int yLimite, int i, List<string> posicoesFinais, List<int> robosForaDoCampo, List<int> robosColididos)
    {
        string posicaoFinal = $"{xInicial} {yInicial} {direcaoInicial}";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Posição final do robô {i + 1}: {posicaoFinal}");
        Console.ResetColor();

        if (xInicial < 0 || xInicial > xLimite || yInicial < 0 || yInicial > yLimite)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"O robô {i + 1} saiu do campo de pesquisa.");
            robosForaDoCampo.Add(i + 1);
            Console.ResetColor();
        }
        else if (posicoesFinais.Contains($"{xInicial} {yInicial}"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Colisão detectada! O robô {i + 1} colidiu com outro robô na posição {xInicial} {yInicial}.");
            robosColididos.Add(i + 1);
            Console.ResetColor();
        }
        else
        {
            posicoesFinais.Add(posicaoFinal);
        }
    }

    static void ForaDoCampo(int xInicial, int yInicial, int xLimite, int yLimite, int i, List<int> robosForaDoCampo)
    {
        if (xInicial < 0 || xInicial > xLimite || yInicial < 0 || yInicial > yLimite)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n** Robôs Fora do Campo **");
            foreach (var robo in robosForaDoCampo)
            {
                Console.WriteLine($"Robô {robo}");
            }
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTodos os robôs estão dentro do campo de pesquisa.");
            Console.ResetColor();
        }
    }

    static void PosicaoFinal(List<string> posicoesFinais, List<int> robosForaDoCampo, List<int> robosColididos)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== RESULTADOS FINAIS ===");
        Console.ResetColor();

        if (robosColididos.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n** COLISÕES DETECTADAS **");
            foreach (var robo in robosColididos)
            {
                Console.WriteLine($"Robô {robo} envolvido em colisão.");
            }
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nNenhuma colisão foi detectada.");
            Console.ResetColor();
        }


        if (robosForaDoCampo.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n** ROBÔS FORA DO CAMPO **");
            foreach (var robo in robosForaDoCampo)
            {
                Console.WriteLine($"Robô {robo} saiu do campo de pesquisa.");
            }
            Console.ResetColor();
        }

        Console.WriteLine("\nPosições finais dos robôs:");
        foreach (var posicao in posicoesFinais)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(posicao);
            Console.ResetColor();
        }

        Console.Write("Pressione qualquer tecla para fechar...");
        Console.ReadLine();
    }

    static string CapturarEntrada(string mensagem, Func<string, bool> validador, string erro)
    {
        Console.Write(mensagem);
        string input = Console.ReadLine().ToUpper();

        while (!validador(input))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erro);
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Write(mensagem);
            input = Console.ReadLine().ToUpper();
        }

        return input;
    }


}


