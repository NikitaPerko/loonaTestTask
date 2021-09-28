using LoonaTest.Game.GameActors.Penguins;

namespace LoonaTest.Game.GameEventHandlers
{
    public interface IGameEventsHandler
    {
        void SetDependencies(PenguinsContainer penguinsContainer, Game game);
        void OnPenguinOutOfBorder(Penguin penguin);
        void OnTimeIsOver();
    }
}