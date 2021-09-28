using LoonaTest.Game.GameActors.Penguins;

namespace LoonaTest.Game.GameEventHandlers
{
    public interface IGameEventsHandler
    {
        void SetDependencies(PenguinsContainer penguinsContainer, Game game, GameData gameData);
        void OnPenguinOutOfBorder(Penguin penguin);
        void OnTimeIsOver();
    }
}