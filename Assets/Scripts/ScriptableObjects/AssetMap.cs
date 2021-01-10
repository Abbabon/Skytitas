using System;
using Types;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class AssetMap
    {
        public AssetType AssetType;
        public GameObject Prefab;
    }
}