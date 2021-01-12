using Entitas;
using UnityEngine;
using Views.Interfaces;
using Zenject;

namespace Views.Concrete
{
    public class AsteroidView : MonoBehaviour, IEventListener, IPositionListener
    {
        private GameEntity _entity;
        public GameEntity Entity => _entity;
        
        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddPositionListener(this);
        }

        public void RemoveListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.RemovePositionListener();
        }

        public void OnPosition(GameEntity entity, Vector3 position)
        {
            transform.position = position;
        }
        
        public class Pool : MemoryPool<AsteroidView>
        {
            protected override void OnCreated(AsteroidView item)
            {
                item.gameObject.SetActive(false);
            }

            protected override void OnDespawned(AsteroidView item)
            {
                item.gameObject.SetActive(false);
            }

            protected override void OnSpawned(AsteroidView item)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}