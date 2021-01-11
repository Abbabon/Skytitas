
    using Entitas;
    using Types;

    namespace Systems.InitializationSystems
    {
        public class InitializePlayerSystem : IInitializeSystem
        {
            private readonly Contexts _contexts;

            public InitializePlayerSystem(Contexts contexts)
            {
                _contexts = contexts;
            }
            
            public void Initialize()
            {
                var entity = _contexts.game.CreateEntity();
                entity.isPlayer = true;
                entity.AddPosition(_contexts.meta.gameSettings.instance.InitialPlayerPosition);
                entity.AddAsset(AssetType.Spaceship);
            }
        }
    }
