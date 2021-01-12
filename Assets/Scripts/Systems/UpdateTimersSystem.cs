using Entitas;
using UnityEngine;

namespace Systems
{
    public class UpdateTimersSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private IGroup<GameEntity> _timersGroup;

        public UpdateTimersSystem(Contexts contexts)
        {
            _contexts = contexts;
            _timersGroup = contexts.game.GetGroup(GameMatcher.Timer);
        }
        
        public void Execute()
        {
            foreach (var timerEntity in _timersGroup)
            {
                var newTimerValue = timerEntity.timer.Value - Time.deltaTime;
                timerEntity.ReplaceTimer(newTimerValue);
            }
        }
    }
}