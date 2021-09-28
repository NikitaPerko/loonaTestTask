namespace LoonaTest.Game.GameEventHandlers
{
    public class PenguinsAreOverHandler : IPenguinsAreOverHandler
    {
        private readonly Game _game;

        public PenguinsAreOverHandler(Game game)
        {
            _game = game;
        }

        public void OnPenguinsAreOver()
        {
            _game.DeinitGame();
        }
    }
}