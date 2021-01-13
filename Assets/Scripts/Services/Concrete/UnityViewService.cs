using ScriptableObjects;
using Services.Interfaces;
using Types;
using UnityEngine;
using Views;
using Views.Concrete;
using Views.Interfaces;
using Views.UI;

namespace Services.Concrete
{
    public class UnityViewService : IViewService
    {
        private readonly AssetMapping _assetMapping;
        private readonly AsteroidView.Pool _asteroidPool;
        private readonly ShipView.Factory _shipFactory;
        
        private readonly UiCanvasView _uiCanvasView;
        private readonly RoadView _roadView;

        public UnityViewService(
            AssetMapping assetMapping, 
            AsteroidView.Pool asteroidPool,
            ShipView.Factory shipFactory,
            UiCanvasView uiCanvasView,
            RoadView roadView)
        {
            _assetMapping = assetMapping;
            _asteroidPool = asteroidPool;
            _shipFactory = shipFactory;
            _uiCanvasView = uiCanvasView;
            _roadView = roadView;
        }
        
        public void LinkView(GameEntity gameEntity, AssetType assetType)
        {
            if (_assetMapping.AssetLookup.TryGetValue(assetType, out var assetConfiguraiton))
            {
                var gameObject = GetObject(assetType, assetConfiguraiton);
                LinkEntityAndView(gameEntity, gameObject);
            }
        }
        
        private GameObject GetObject(AssetType assetType, AssetConfiguraiton assetConfiguraiton)
        {
            GameObject gameObject = null;
            if (assetConfiguraiton.IsPoolable)
            {
                switch (assetType)
                {
                    case AssetType.Asteroid:
                        gameObject = _asteroidPool.Spawn().gameObject;
                        break;
                }
            }
            else if (assetConfiguraiton.IsIntantiatable)
            {
                //TODO: what about views that need zenject? they should use factories. How can we get them in an elegant manner?
                switch (assetType)
                {
                    case AssetType.Spaceship:
                        gameObject = _shipFactory.Create().gameObject;
                        break;
                    default:
                        //TODO: log
                        gameObject = Object.Instantiate(assetConfiguraiton.Prefab);
                        break;
                }
            }
            else
            {
                switch (assetType)
                {
                    case AssetType.HudCanvas:
                        gameObject = _uiCanvasView.gameObject;
                        break;
                    case AssetType.RoadView:
                        gameObject = _roadView.gameObject;
                        break;
                }
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
        
        public void UnlinkView(GameEntity gameEntity)
        {
            var canDispose = gameEntity.hasView && gameEntity.hasAsset;
            if (canDispose)
            {
                if (_assetMapping.AssetLookup.TryGetValue(gameEntity.asset.Value, out var assetConfiguraiton))
                {
                    var gameObject = gameEntity.view.Value;
                    UnlinkEntityAndView(gameEntity, gameObject);
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

        private void UnlinkEntityAndView(GameEntity gameEntity, GameObject gameObject)
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