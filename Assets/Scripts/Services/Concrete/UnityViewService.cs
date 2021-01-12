using ScriptableObjects;
using Services.Interfaces;
using Types;
using UnityEngine;
using Views.Concrete;
using Views.Interfaces;

namespace Services.Concrete
{
    public class UnityViewService : IViewService
    {
        private readonly AssetMapping _assetMapping;
        private readonly AsteroidView.Pool _asteroidPool;
        
        public UnityViewService(AssetMapping assetMapping, AsteroidView.Pool asteroidPool)
        {
            _assetMapping = assetMapping;
            _asteroidPool = asteroidPool;
        }
        
        public void CreateAndLinkView(GameEntity gameEntity, AssetType assetType)
        {
            if (_assetMapping.AssetLookup.TryGetValue(assetType, out var assetConfiguraiton))
            {
                var gameObject = SpawnObject(assetType, assetConfiguraiton);
                LinkEntityAndView(gameEntity, gameObject);
            }
        }
        
        private GameObject SpawnObject(AssetType assetType, AssetConfiguraiton assetConfiguraiton)
        {
            GameObject gameObject = null;
            if (assetConfiguraiton.IsPoolable)
            {
                switch (assetType)
                {
                    case AssetType.Asteroid:
                        gameObject = _asteroidPool.Spawn().gameObject;
                        break;
                    default:
                        //TODO: log, handle
                        break;
                }
            }
            else
            {
                //TODO: what about views that need zenject? they should use factories. How can we get them in an elegant manner?
                gameObject = Object.Instantiate(assetConfiguraiton.Prefab);
            }

            return gameObject;
        }
        
        private void LinkEntityAndView(GameEntity gameEntity, GameObject gameObject)
        {
            if (gameObject == null || gameEntity.hasView)
            {
                //TODO: log, handle
                return;
            }
            
            gameEntity.ReplaceView(gameObject);
            var eventListeners = gameObject.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.RegisterListeners(gameEntity);
            }
        }
        
        public void DisposeAndUnlinkView(GameEntity gameEntity)
        {
            var canDispose = gameEntity.hasView && gameEntity.hasAsset;
            if (canDispose)
            {
                if (_assetMapping.AssetLookup.TryGetValue(gameEntity.asset.Value, out var assetConfiguraiton))
                {
                    var gameObject = gameEntity.view.Value;
                    UnlinkView(gameEntity, gameObject);
                    DisposeOfView(gameEntity, assetConfiguraiton, gameObject);
                }   
            }
            else
            {
                //TODO: log, handle
            }
        }

        private void DisposeOfView(GameEntity gameEntity, AssetConfiguraiton assetConfiguraiton, GameObject gameObject)
        {
            if (assetConfiguraiton.IsPoolable)
            {
                switch (gameEntity.asset.Value)
                {
                    case AssetType.Asteroid:
                        var view = gameObject.GetComponent<AsteroidView>();
                        _asteroidPool.Despawn(view);
                        break;
                    default:
                        //TODO: log, handle
                        break;
                }
            }
            else
            {
                Object.Destroy(gameObject);
            }
        }

        private static void UnlinkView(GameEntity gameEntity, GameObject gameObject)
        {
            var eventListeners = gameObject.GetComponents<IEventListener>();
            foreach (var listener in eventListeners)
            {
                listener.RemoveListeners(gameEntity);
            }
            gameEntity.RemoveView();
        }
    }
}