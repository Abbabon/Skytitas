using System.Collections.Generic;
using Entitas;
using Services.Interfaces;

namespace Systems.GameplaySystems
{
    public class LoadAssetSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private Contexts _contexts;
        private IViewService _viewService;
        
        public LoadAssetSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            _viewService = _contexts.meta.viewService.instance;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Asset));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAsset && !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var assetType = gameEntity.asset.Value;
                _viewService.LinkView(gameEntity, assetType);
            }
        }
        
    }
}