using Entitas;
using Types;

namespace Components.GameComponents
{
    [Game]
    public class AssetComponent : IComponent
    {
        public AssetType Value;
    }
}