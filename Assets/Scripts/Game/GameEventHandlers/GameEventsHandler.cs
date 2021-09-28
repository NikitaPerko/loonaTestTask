using LoonaTest.Game.GameActors.Penguins;

namespace LoonaTest.Game.GameEventHandlers
{
    public class GameEventsHandler
    {
        private PenguinOutOfBorderHandler _penguinOutOfBorderHandler;
        private PenguinsAreOverHandler _penguinsAreOverHandler;
        private TimeIsOverHandler _timeIsOverHandler;

        public void SetDependencies(PenguinsContainer penguinsContainer, Game game)
        {
            _penguinsAreOverHandler = new PenguinsAreOverHandler(game);
            _penguinOutOfBorderHandler = new PenguinOutOfBorderHandler(penguinsContainer.Penguins, _penguinsAreOverHandler);
            _timeIsOverHandler = new TimeIsOverHandler(game);
        }

        public void OnPenguinOutOfBorder(Penguin penguin)
        {
            _penguinOutOfBorderHandler.OnPenguinOutOfBorder(penguin);
        }

        public void OnTimeIsOver()
        {
            _timeIsOverHandler.OnTimeIsOver();
        }
    }
}