using rocketGame2._0;
using System.Security.Cryptography.X509Certificates;

namespace rocketGame
{
    class Program
    {
        public static async Task Main()
        {
            Game game = new Game();
            var gameTask = game.Run();
            await gameTask;
        }
    }
}