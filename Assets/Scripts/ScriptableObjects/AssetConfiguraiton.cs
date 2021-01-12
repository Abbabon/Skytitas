using System;
using Types;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class AssetConfiguraiton
    {
        public AssetType AssetType;
        public GameObject Prefab;
        public bool IsPoolable;
    }
}