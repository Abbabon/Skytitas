
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
                var playerEntity = _contexts.game.CreateEntity();
                playerEntity.isPlayer = true;
                playerEntity.AddPosition(_contexts.meta.gameSettings.instance.InitialPlayerPosition);
                playerEntity.AddAsset(AssetType.Spaceship);
                
                var accelerationEntity = _contexts.game.CreateEntity();
                accelerationEntity.AddPlayerAcceleration(false);
                accelerationEntity.AddAsset(AssetType.RoadView);
            }
        }
    }
