using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class RoadView : MonoBehaviour
    {
        [SerializeField] private Material _roadMaterial;
        [SerializeField] private List<string> _scrolledTextureNames;
        [SerializeField] private float _uvScrollSpeed;

        private void Update()
        {
            if (_roadMaterial != null)
            {
                foreach (var textureName in _scrolledTextureNames)
                {
                    var textureOffset = _roadMaterial.GetTextureOffset(textureName);
                    textureOffset += new Vector2(0, _uvScrollSpeed * Time.deltaTime);
                    _roadMaterial.SetTextureOffset(textureName, textureOffset);
                }
            }
        }
    }
}
