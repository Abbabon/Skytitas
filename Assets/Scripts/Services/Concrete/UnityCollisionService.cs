using System;
using System.Collections.Generic;
using Services.Interfaces;

namespace Services.Concrete
{
    public class UnityCollisionService : ICollisionService
    {
        //if the systems are created in zenject can I just reference it here? is it cool?
        private List<Action<GameEntity>> _playerCollisionsListeners;

        public UnityCollisionService()
        {
            _playerCollisionsListeners = new List<Action<GameEntity>>();
        }
        
        public void RegisterPlayerCollisionListener(Action<GameEntity> callback)
        {
            _playerCollisionsListeners.Add(callback);
        }

        public void PlayerCollidedWithAsteroid(GameEntity collidedAsteroid)
        {
            foreach (var playerCollisionsListener in _playerCollisionsListeners)
            {
                playerCollisionsListener.Invoke(collidedAsteroid);
            }
        }
    }
}