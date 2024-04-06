using rocketGame2._0;

namespace rocketGameMenu
{
    class Program
    {
        public static async Task Main()
        {
            GameMenu gameMenu = new GameMenu();
            gameMenu.gameStart();

            Game game = new Game();
            var gameTask = game.Run();
            await gameTask;

            gameMenu.gameEnd(game);
        }
    }
}