using System.Collections.Generic;
using Entitas;
using Services.Interfaces;
using UnityEngine;
using Views.Interfaces;
using Zenject;

namespace Views
{
    public class RoadView : MonoBehaviour, IEventListener, IPlayerAccelerationListener
    {
        [SerializeField] private Material _roadMaterial;
        [SerializeField] private List<string> _scrolledTextureNames;
        
        private IGameSettingsService _gameSettingsService;
        private bool _playerIsAccelerating;
        private GameEntity _entity;
        
        [Inject]
        private void Initialize(IGameSettingsService gameSettingsService)
        {
            _gameSettingsService = gameSettingsService;
        }
        
        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.AddPlayerAccelerationListener(this);
        }

        public void RemoveListeners(IEntity entity)
        {
            _entity = (GameEntity) entity;
            _entity.RemovePlayerAccelerationListener(this);
        }

        public void OnPlayerAcceleration(GameEntity entity, bool turnedOn)
        {
            _playerIsAccelerating = turnedOn;
        }
        
        private void Update()
        {
            if (_roadMaterial != null)
            {
                foreach (var textureName in _scrolledTextureNames)
                {
                    var textureOffset = _roadMaterial.GetTextureOffset(textureName);
                    var offsetDelta = _gameSettingsService.UVScrollSpeed * 
                                      (_playerIsAccelerating ? _gameSettingsService.AccelerationSpeedFactor : 1f) *
                                      Time.deltaTime;
                    
                    textureOffset += new Vector2(0, offsetDelta);
                    _roadMaterial.SetTextureOffset(textureName, textureOffset);
                }
            }
        }
    }
}
