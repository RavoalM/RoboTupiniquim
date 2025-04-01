using RoboTupiniquim.ConsoleApp.Entities.Utils;
using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp.Entities
{
    public class Area
    {
        public static int xLimite;
        public static int yLimite;
        public static void CapturarArea()
        {
            string limiteInput = Validacao.CapturarEntrada("Informe o limite do campo de pesquisa: ",
            input => Regex.IsMatch(input, @"^\d+\s\d+$"), "Erro! Informe o limite corretamente.");

            string[] limiteArray = limiteInput.Split(' ');
            xLimite = int.Parse(limiteArray[0]);
            yLimite = int.Parse(limiteArray[1]);
        }
    }
}
