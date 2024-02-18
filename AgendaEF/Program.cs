using AgendaEF.Logs;

namespace AgendaEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogApp.LogInfo("Programa agenda foi inciado!");
            var menu = new AppManager();
            menu.MenuAplicacao();
        }
    }
}
