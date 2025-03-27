namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

        }

    }
}
