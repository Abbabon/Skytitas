using Types;

namespace Services.Interfaces
{
    public interface IViewService
    {
        void LinkView(GameEntity gameEntity, AssetType assetType);
        void UnlinkView(GameEntity gameEntity);
    }
}