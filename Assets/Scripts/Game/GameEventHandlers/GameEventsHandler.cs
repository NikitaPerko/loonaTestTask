namespace LoonaTest.Game.GameEventHandlers
{
    public class GameEventsHandler
    {
        private readonly PenguinOutOfBorderHandler _penguinOutOfBorderHandler;

        public GameEventsHandler()
        {
            _penguinOutOfBorderHandler = new PenguinOutOfBorderHandler();
        }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            _penguinOutOfBorderHandler.OnPenguinOutOfBorder(penguin);
        }
    }
}