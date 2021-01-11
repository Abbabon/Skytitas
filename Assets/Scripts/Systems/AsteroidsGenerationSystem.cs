using System.Collections.Generic;
using Entitas;
using Services.Interfaces;
using Types;
using UnityEngine;

namespace Systems
{
    public class AsteroidGenerationSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGameSettingsService _gameSettingsService;

        public AsteroidGenerationSystem(Contexts contexts, IGameSettingsService gameSettingsService) : base(contexts.game)
        {
            _contexts = contexts;
            _gameSettingsService = gameSettingsService;
        }
        
        public void Initialize()
        {
            GenerateAsteroid();
            CreateAsteroidGenerationTimer();
        }

        private void GenerateAsteroid()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddPosition(GetRandomAsteroidStartPosition());
            entity.AddAsset(AssetType.Asteroid);
            entity.isAsteroid = true;
        }

        private Vector3 GetRandomAsteroidStartPosition()
        {
            return _gameSettingsService.AsteroidSpawnPositions[
                Random.Range(0, _gameSettingsService.AsteroidSpawnPositions.Count)];
        }

        private void CreateAsteroidGenerationTimer()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddTimer(_contexts.meta.gameSettings.instance.InitialTimeBetweenGenerations);
            entity.isAsteroidGenerationTimer = true;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Timer));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isAsteroidGenerationTimer && entity.hasTimer && entity.timer.Value <= 0f;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var asteroidTimerEntity in entities)
            {
                //asteroidTimerEntity.view ? 
                asteroidTimerEntity.isDestroyed = true;
            }
            
            GenerateAsteroid();
            CreateAsteroidGenerationTimer();
        }
    }
}