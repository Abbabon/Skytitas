using System.Collections.Generic;
using Entitas;
using Services.Interfaces;

// inherit from MultiReactiveSystem using the IDestroyed interface defined above
namespace Systems
{
    public class MultiDestroySystem : MultiReactiveSystem<GameEntity, Contexts>
    {
        private readonly IViewService _viewService;

        // base class takes in all contexts, not just one as in normal ReactiveSystems
        public MultiDestroySystem(Contexts contexts, IViewService viewService) : base(contexts)
        {
            _viewService = viewService;
        }

        // return an ICollector[] with a collector from each context
        protected override ICollector[] GetTrigger(Contexts contexts)
        {
            return new ICollector[] {
                contexts.game.CreateCollector(GameMatcher.Destroyed),
            };
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var destroyableEntity in entities)
            {
                if (destroyableEntity.hasView)
                {
                    _viewService.DisposeAndUnlinkView(destroyableEntity);
                }
            
                destroyableEntity.Destroy();
            }
        }
    }
}