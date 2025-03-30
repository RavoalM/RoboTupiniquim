namespace RoboTupiniquim.ConsoleApp;
internal class Program
{
   
    static void Main(string[] args)
    {
        bool executando = true;
        while (executando)
        {
            string opcao = Mensagens.ExibirMenu();
            Processamento.ProcessarOpcaoMenu(opcao);
        }
    }
}


