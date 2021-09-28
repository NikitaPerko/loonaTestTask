namespace LoonaTest.Game.GameEventHandlers
{
    public class TimeIsOverHandler
    {
        private readonly Game _game;

        public TimeIsOverHandler(Game game)
        {
            _game = game;
        }

        public void OnTimeIsOver()
        {
            _game.DeinitGame();
        }
    }
}