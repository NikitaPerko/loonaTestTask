using LoonaTest.Game.GameActors.Penguins;

namespace LoonaTest.Game.GameEventHandlers
{
    public class GameEventsHandler : IGameEventsHandler
    {
        private IPenguinOutOfBorderHandler _penguinOutOfBorderHandler;
        private IPenguinsAreOverHandler _penguinsAreOverHandler;
        private ITimeIsOverHandler _timeIsOverHandler;
        private GameData _gameData;

        public void SetDependencies(PenguinsContainer penguinsContainer, Game game, GameData gameData)
        {
            _gameData = gameData;
            _penguinsAreOverHandler = new PenguinsAreOverHandler(gameData);
            _penguinOutOfBorderHandler = new PenguinOutOfBorderHandler(penguinsContainer.Penguins, _penguinsAreOverHandler);
            _timeIsOverHandler = new TimeIsOverHandler(_gameData);
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