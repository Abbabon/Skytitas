using Entitas;
using Types;

namespace Systems.GameplaySystems
{
    public class PlayerScoreSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public PlayerScoreSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddScore(0);
            entity.AddAsset(AssetType.HudCanvas);
        }
    }
}