using RoboTupiniquim.ConsoleApp.Entities.Utils;
using System.Text.RegularExpressions;


namespace RoboTupiniquim.ConsoleApp.Entities
{
    public class Robo : Entitie
    {
        public static int id = 0;
        public string Nome = "";

        public Robo(string nomeRobo)
        {
            Nome = nomeRobo;
            Id = ++id;
        }

        public char VirarDireita(char direcaoAtual)
        {
            switch (direcaoAtual)
            {
                case 'N':
                    return 'L';
                case 'L':
                    return 'S';
                case 'S':
                    return 'O';
                case 'O':
                    return 'N';
                default:
                    return direcaoAtual;
            }
        }

        public char VirarEsquerda(char direcaoAtual)
        {
            switch (direcaoAtual)
            {
                case 'N':
                    return 'O';
                case 'O':
                    return 'S';
                case 'S':
                    return 'L';
                case 'L':
                    return 'N';
                default:
                    return direcaoAtual;
            }
        }

        public (int, int) MovimentarRobo(int xInicial, int yInicial, char direcaoInicial)
        {
            if (direcaoInicial == 'N') yInicial++;
            else if (direcaoInicial == 'S') yInicial--;
            else if (direcaoInicial == 'L') xInicial++;
            else if (direcaoInicial == 'O') xInicial--;
            return (xInicial, yInicial);
        }

        public void CapturarCoordenadas(string nome)
        {
            string spawnInput = Validacao.CapturarEntrada($"Informe as coordenadas do {nome.ToUpper()}: ",
            input => Regex.IsMatch(input, @"^\d+\s\d+\s[N|S|L|O]$"),
            "Erro! Informe a posição inicial corretamente.");

            string[] spawnArray = spawnInput.Split(' ');
            xInicial = int.Parse(spawnArray[0]);
            yInicial = int.Parse(spawnArray[1]);
            direcaoInicial = char.Parse(spawnArray[2]);

            posicaoInicial = $"{xInicial} {yInicial} {direcaoInicial}";
        }

        public void CapturarComandos(int id, List<string> posicoesFinais, List<int> robosColididos)
        {
            string comandosInput = Validacao.CapturarEntrada("Informe o comando: ",
           input => Regex.IsMatch(input, @"^[MDE]+$"), "Erro! Comandos inválidos.");

            foreach (char comando in comandosInput)
            {
                if (comando == 'D')
                {
                    direcaoInicial = VirarDireita(direcaoInicial);
                }
                if (comando == 'E')
                {
                   direcaoInicial = VirarEsquerda(direcaoInicial);
                }
                else if (comando == 'M')
                {
                    (xInicial, yInicial) = MovimentarRobo(xInicial, yInicial, direcaoInicial);

                    string novaPosicao = $"{xInicial} {yInicial} {direcaoInicial}";

                    if (Validacao.ConferirColisão(xInicial, yInicial, id, posicoesFinais, robosColididos))
                    {
                        break;
                    }
                }
            }
        }
    }
}
