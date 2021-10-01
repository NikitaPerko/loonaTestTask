using LoonaTest.Game.GameActors;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.GameDeinitializers;
using LoonaTest.Game.GameEventHandlers;
using LoonaTest.Game.GameInitializers;
using LoonaTest.Game.Settings;
using LoonaTest.Game.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LoonaTest.Game
{
    public class GlobalLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private GameSettings _gameSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            DontDestroyOnLoad(this);
            builder.RegisterEntryPoint<Game>(Lifetime.Scoped).AsSelf();
            builder.Register<GameData>(Lifetime.Scoped);
            builder.Register<GameFieldFactory>(Lifetime.Scoped);
            builder.Register<GameFieldDeinitializer>(Lifetime.Scoped);
            builder.Register<PenguinsInitializer>(Lifetime.Scoped);
            builder.Register<PenguinsDeinitializer>(Lifetime.Scoped);
            builder.Register<CharactersInitializer>(Lifetime.Scoped);
            builder.Register<CharactersDeinitializer>(Lifetime.Scoped);
            builder.Register<PenguinsContainer>(Lifetime.Scoped);
            builder.Register<CharactersContainer>(Lifetime.Scoped);
            builder.Register<GameFieldContainer>(Lifetime.Scoped);
            builder.Register<TimeService>(Lifetime.Scoped).As<ITimeService>();
            builder.Register<TimeIsOverService>(Lifetime.Scoped);
            builder.Register<UIManager>(Lifetime.Scoped);
            builder.Register<WindowsFactory>(Lifetime.Singleton);
            builder.Register<TimeIsOverHandler>(Lifetime.Scoped).As<ITimeIsOverHandler>();
            builder.Register<PenguinsAreOverHandler>(Lifetime.Scoped).As<IPenguinsAreOverHandler>();
            builder.Register<PenguinOutOfBorderHandler>(Lifetime.Scoped).As<IPenguinOutOfBorderHandler>();
            builder.Register(_ => _gameSettings, Lifetime.Scoped);
            builder.Register(_ => _gameSettings.CharactersSettings, Lifetime.Scoped);
            builder.Register(_ => _gameSettings.PenguinsSettings, Lifetime.Scoped);
            builder.Register(_ => _gameSettings.WindowsSettings, Lifetime.Scoped);
        }
    }
}