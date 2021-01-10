using Entitas;
using UnityEngine;
using Views.Interfaces;

namespace Views.Listeners
{
    public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
    {
        private GameEntity _entity;
        
        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddPositionListener(this);
        }

        public void OnPosition(GameEntity entity, Vector3 position)
        {
            transform.position = position;
        }
    }
}