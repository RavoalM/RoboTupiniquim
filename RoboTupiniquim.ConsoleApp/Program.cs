namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Informe o limite do campo de pesquisa: ");
            char[] Limite = Console.ReadLine().Replace(" ", "").ToCharArray();

            int xLimite = int.Parse(Limite[0].ToString());
            int yLimite = int.Parse(Limite[1].ToString());

            Console.Write("Informe o spawn do robo (use o modelo 1 2 N): ");
            char[] spawn = Console.ReadLine().Replace(" ", "").ToUpper().ToCharArray();

            int xInicial = int.Parse(spawn[0].ToString());
            int yInicial = int.Parse(spawn[1].ToString());
            char direcaoInicial = spawn[2];

            Console.Write("Informe o comando: ");
            char[] listaComando = Console.ReadLine().Replace(" ", "").ToUpper().ToCharArray();


            foreach (char comando in listaComando)
            {
                if (direcaoInicial == 'N')
                {
                    if (comando == 'D')
                    {
                        direcaoInicial = 'L';
                    }
                    if (comando == 'E')
                    {
                        direcaoInicial = 'O';
                    }
                }

                else if (direcaoInicial == 'S')
                {
                    if (comando == 'D')
                    {
                        direcaoInicial = 'O';
                    }
                    if (comando == 'E')
                    {
                        direcaoInicial = 'L';
                    }
                }

                else if (direcaoInicial == 'O')
                {
                    if (comando == 'D')
                    {
                        direcaoInicial = 'N';
                    }
                    if (comando == 'E')
                    {
                        direcaoInicial = 'S';
                    }
                }

                else if (direcaoInicial == 'L')
                {
                    if (comando == 'D')
                    {
                        direcaoInicial = 'S';
                    }
                    if (comando == 'E')
                    {
                        direcaoInicial = 'N';
                    }
                }

                if (comando == 'M')
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
                Console.WriteLine("O robo saiu do campo de pesquisa");
            }
            else
            {

                Console.WriteLine($"Posição final do robo: {xInicial} {yInicial} {direcaoInicial}");
            }

        }

    }
}
