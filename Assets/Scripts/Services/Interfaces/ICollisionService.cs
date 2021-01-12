using System;

namespace Services.Interfaces
{
    public interface ICollisionService
    {
        void RegisterPlayerCollisionListener(Action<GameEntity> callback);
        void PlayerCollidedWithAsteroid(GameEntity collidedAsteroid);
    }
}