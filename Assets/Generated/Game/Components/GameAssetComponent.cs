//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.GameComponents.AssetComponent asset { get { return (Components.GameComponents.AssetComponent)GetComponent(GameComponentsLookup.Asset); } }
    public bool hasAsset { get { return HasComponent(GameComponentsLookup.Asset); } }

    public void AddAsset(Types.AssetType newAssetType) {
        var index = GameComponentsLookup.Asset;
        var component = (Components.GameComponents.AssetComponent)CreateComponent(index, typeof(Components.GameComponents.AssetComponent));
        component.AssetType = newAssetType;
        AddComponent(index, component);
    }

    public void ReplaceAsset(Types.AssetType newAssetType) {
        var index = GameComponentsLookup.Asset;
        var component = (Components.GameComponents.AssetComponent)CreateComponent(index, typeof(Components.GameComponents.AssetComponent));
        component.AssetType = newAssetType;
        ReplaceComponent(index, component);
    }

    public void RemoveAsset() {
        RemoveComponent(GameComponentsLookup.Asset);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAsset;

    public static Entitas.IMatcher<GameEntity> Asset {
        get {
            if (_matcherAsset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Asset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAsset = matcher;
            }

            return _matcherAsset;
        }
    }
}
