namespace rocketGame2._0
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