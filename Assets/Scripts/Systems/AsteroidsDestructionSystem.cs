using Entitas;
using Services.Interfaces;

namespace Systems
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
                    //TODO: mark to destroy
                    asteroidEntity.isDestroyed = true;

                    //return view to pool :O
                }
            }
        }
    }
}