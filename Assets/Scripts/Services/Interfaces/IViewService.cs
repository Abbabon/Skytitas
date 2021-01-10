using Entitas;
using Types;

namespace Services.Interfaces
{
    public interface IViewService
    {
        void LoadAsset(Contexts contexts, IEntity entity, AssetType assetType);
    }
}