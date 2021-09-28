using LoonaTest.Game.GameActors.Penguins;

namespace LoonaTest.Game.GameEventHandlers
{
    public interface IPenguinOutOfBorderHandler
    {
        void OnPenguinOutOfBorder(Penguin penguin);
    }
}