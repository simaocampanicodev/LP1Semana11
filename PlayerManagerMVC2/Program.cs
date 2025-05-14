using PlayerManagerMVC2.Views;
using PlayerManagerMVC2.Controllers;
using System;

namespace PlayerManagerMVC2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Adicione um nome de ficheiro");
                return;
            }

            string filename = args[0];
            PlayerView view = new PlayerView();
            PlayerController controller = new PlayerController(view, filename);
            controller.Start();
        }
    }
}