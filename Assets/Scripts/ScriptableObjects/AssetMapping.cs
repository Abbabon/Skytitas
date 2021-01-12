using System.Collections.Generic;
using System.Linq;
using Types;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AssetMapping", menuName = "ScriptableObjects/AssetMapping")]
    public class AssetMapping : ScriptableObject
    {
        public List<AssetConfiguraiton> AssetMaps;

        private Dictionary<AssetType, AssetConfiguraiton> _assetLookup;

        public Dictionary<AssetType, AssetConfiguraiton> AssetLookup
        {
            get
            {
                if (_assetLookup == null)
                {
                    _assetLookup = AssetMaps.ToDictionary(key => key.AssetType, value => value);
                }
                
                return _assetLookup;
            }
        }
    }
}