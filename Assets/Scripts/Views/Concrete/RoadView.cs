using System.Collections.Generic;
using Services.Concrete;
using UnityEngine;

namespace Views
{
    public class RoadView : MonoBehaviour
    {
        [SerializeField] private Material _roadMaterial;
        [SerializeField] private List<string> _scrolledTextureNames;
        [SerializeField] private float _uvScrollSpeed;
        [SerializeField] private GameSettingsService _gameSettingsService;
        
        
        private void Update()
        {
            if (_roadMaterial != null)
            {
                foreach (var textureName in _scrolledTextureNames)
                {
                    var textureOffset = _roadMaterial.GetTextureOffset(textureName);
                    textureOffset += new Vector2(0, _gameSettingsService.UVScrollSpeed * Time.deltaTime);
                    _roadMaterial.SetTextureOffset(textureName, textureOffset);
                }
            }
        }
    }
}
