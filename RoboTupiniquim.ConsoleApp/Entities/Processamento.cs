using RoboTupiniquim.ConsoleApp.Entities.Utils;
namespace RoboTupiniquim.ConsoleApp.Entities;
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
                Mensagens.Saindo();
                break;
            default:
                Mensagens.ErroOpcao();
                break;
        }
    }

    public static void IniciarRoboTupiniquim()
    {
        Mensagens.TituloIniciarRobo();

        Area.CapturarArea();

        List<string> posicoesFinais = new List<string>();
        List<int> robosForaDoCampo = new List<int>();
        List<int> robosColididos = new List<int>();

        while (true)
        {

            string nome = Mensagens.PedirNomeRobo();
            Robo ayrtonSenna = new Robo(nome);

            Mensagens.NomeRobo(ayrtonSenna.Nome);

            ayrtonSenna.CapturarCoordenadas(ayrtonSenna.Nome);

            if (Validacao.ConferirColisão(ayrtonSenna.xInicial, ayrtonSenna.yInicial, ayrtonSenna.Id, posicoesFinais, robosColididos))
            {
                break;
            }

            ayrtonSenna.CapturarComandos(ayrtonSenna.Id, posicoesFinais, robosColididos);

            Mensagens.Resultados(ayrtonSenna.xInicial, ayrtonSenna.yInicial, ayrtonSenna.direcaoInicial, Area.xLimite, Area.yLimite, ayrtonSenna.Id, ayrtonSenna.Nome, posicoesFinais, robosForaDoCampo, robosColididos);

            Mensagens.ForaDoCampo(ayrtonSenna.xInicial, ayrtonSenna.yInicial, Area.xLimite, Area.yLimite, robosForaDoCampo, ayrtonSenna.Nome);

            if (ayrtonSenna.Id == 2)
            {
                Mensagens.AnotacoesFinais(posicoesFinais, robosForaDoCampo, robosColididos, ayrtonSenna.Nome);
                break;
            }
        }


    }

}
