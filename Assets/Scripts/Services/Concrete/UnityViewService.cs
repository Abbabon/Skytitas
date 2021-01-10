using Entitas;
using ScriptableObjects;
using Services.Interfaces;
using Types;
using UnityEngine;
using ViewControllers;
using Views.Interfaces;

namespace Services.Concrete
{
    public class UnityViewService : IViewService
    {
        private readonly AssetMapping _assetMapping;

        public UnityViewService(AssetMapping assetMapping)
        {
            _assetMapping = assetMapping;
        }
        
        public void LoadAsset(Contexts contexts, IEntity entity, AssetType assetType)
        {
            if (_assetMapping.AssetLookup.TryGetValue(assetType, out var prefab))
            {
                var gameObject = Object.Instantiate(prefab);
                if (gameObject == null)
                {
                    //TODO: log, handle
                    return;
                }
                var viewController = gameObject.GetComponent<IViewController>();
                if (viewController != null)
                {
                    //TODO: log, handle
                    viewController.InitializeView(contexts, entity);
                    
                    // except we add some lines to find and initialize any event listeners
                    var eventListeners = gameObject.GetComponents<IEventListener>();
                    foreach(var listener in eventListeners) {
                        listener.RegisterListeners(entity);
                    }
                }    
            }
        }
    }
}