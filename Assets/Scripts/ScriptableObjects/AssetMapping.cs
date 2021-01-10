using System.Collections.Generic;
using System.Linq;
using Types;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AssetMapping", menuName = "ScriptableObject/AssetMapping")]
    public class AssetMapping : ScriptableObject
    {
        public List<AssetMap> AssetMaps;

        private Dictionary<AssetType, GameObject> _assetLookup;

        public Dictionary<AssetType, GameObject> AssetLookup
        {
            get
            {
                if (_assetLookup != null)
                {
                    _assetLookup = AssetMaps.ToDictionary(key => key.AssetType, value => value.Prefab);
                }
                
                return _assetLookup;
            }
        }
    }
}