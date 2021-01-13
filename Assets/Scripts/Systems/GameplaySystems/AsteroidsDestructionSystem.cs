using Entitas;
using Services.Interfaces;

namespace Systems.GameplaySystems
{
    public class AsteroidsDestructionSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGameSettingsService _gameSettingsService;
        private IGroup<GameEntity> _asteroidsGroup;

        public AsteroidsDestructionSystem(Contexts contexts, IGameSettingsService gameSettingsService)
        {
            _contexts = contexts;
            _gameSettingsService = gameSettingsService;
            _asteroidsGroup = _contexts.game.GetGroup(GameMatcher.Asteroid);
        }

        public void Execute()
        {
            foreach (var asteroidEntity in _asteroidsGroup)
            {
                if (asteroidEntity.position.Value.z <= _gameSettingsService.AsteroidsTerminalPosition.z)
                {
                    asteroidEntity.isDestroyed = true;

                    if (_contexts.game.hasScore)
                    {
                        var newScore = _contexts.game.score.Value + 1;
                        _contexts.game.ReplaceScore(newScore);
                    }
                }
            }
        }
    }
}