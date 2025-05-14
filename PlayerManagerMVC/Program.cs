using PlayerManagerMVC.Views;
using PlayerManagerMVC.Controllers;

namespace PlayerManagerMVC
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