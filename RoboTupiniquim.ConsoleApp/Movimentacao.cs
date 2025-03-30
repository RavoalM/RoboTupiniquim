
namespace RoboTupiniquim.ConsoleApp;
public class Movimentacao
{
    public static char Virar(char direcaoAtual, char comando)
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

    public static (int, int) MovimentarRobo(int xInicial, int yInicial, char direcaoInicial)
    {
        if (direcaoInicial == 'N') yInicial++;
        else if (direcaoInicial == 'S') yInicial--;
        else if (direcaoInicial == 'L') xInicial++;
        else if (direcaoInicial == 'O') xInicial--;
        return (xInicial, yInicial);
    }
}
