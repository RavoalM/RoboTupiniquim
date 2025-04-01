namespace RoboTupiniquim.ConsoleApp.Entities.Utils;
public class Validacao
{
    public static string CapturarEntrada(string mensagem, Func<string, bool> validador, string erro)
    {
        Console.Write(mensagem);
        string input = Console.ReadLine()!.ToUpper();

        while (!validador(input))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erro);
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Write(mensagem);
            input = Console.ReadLine()!.ToUpper();
        }

        return input;
    }

    public static bool ConferirColisão(int xInicial, int yInicial, int id, List<string> posicoesFinais, List<int> robosColididos)
    {
        if (posicoesFinais.Any(pos => pos.StartsWith($"{xInicial} {yInicial}")))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Colisão detectada! O robô {id} tentou se mover para a posição {xInicial} {yInicial}, que já está ocupada.");
            robosColididos.Add(id);

            return true;
        }
        return false;
    }
}
