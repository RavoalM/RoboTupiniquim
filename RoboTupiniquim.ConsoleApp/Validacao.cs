namespace RoboTupiniquim.ConsoleApp;
public class Validacao
{
    public static string CapturarEntrada(string mensagem, Func<string, bool> validador, string erro)
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
