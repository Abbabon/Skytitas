//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Asset = 0;
    public const int Player = 1;
    public const int Position = 2;
    public const int View = 3;
    public const int PlayerListener = 4;
    public const int PositionListener = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Asset",
        "Player",
        "Position",
        "View",
        "PlayerListener",
        "PositionListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Components.GameComponents.AssetComponent),
        typeof(Components.GameComponents.PlayerComponent),
        typeof(Components.GameComponents.PositionComponent),
        typeof(Components.GameComponents.ViewComponent),
        typeof(PlayerListenerComponent),
        typeof(PositionListenerComponent)
    };
}
