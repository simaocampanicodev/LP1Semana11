using PlayerManagerMVC2.Views;
using PlayerManagerMVC2.Controllers;

namespace PlayerManagerMVC2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            PlayerView view = new PlayerView();
            PlayerController controller = new PlayerController(view);
            controller.Start();
        }
    }
}