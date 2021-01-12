using Types;

namespace Services.Interfaces
{
    public interface IViewService
    {
        void CreateAndLinkView(GameEntity gameEntity, AssetType assetType);
        void DisposeAndUnlinkView(GameEntity gameEntity);
    }
}