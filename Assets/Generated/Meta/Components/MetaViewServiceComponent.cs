//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity viewServiceEntity { get { return GetGroup(MetaMatcher.ViewService).GetSingleEntity(); } }
    public Components.MetaComponents.ViewServiceComponent viewService { get { return viewServiceEntity.viewService; } }
    public bool hasViewService { get { return viewServiceEntity != null; } }

    public MetaEntity SetViewService(Services.Interfaces.IViewService newInstance) {
        if (hasViewService) {
            throw new Entitas.EntitasException("Could not set ViewService!\n" + this + " already has an entity with Components.MetaComponents.ViewServiceComponent!",
                "You should check if the context already has a viewServiceEntity before setting it or use context.ReplaceViewService().");
        }
        var entity = CreateEntity();
        entity.AddViewService(newInstance);
        return entity;
    }

    public void ReplaceViewService(Services.Interfaces.IViewService newInstance) {
        var entity = viewServiceEntity;
        if (entity == null) {
            entity = SetViewService(newInstance);
        } else {
            entity.ReplaceViewService(newInstance);
        }
    }

    public void RemoveViewService() {
        viewServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    public Components.MetaComponents.ViewServiceComponent viewService { get { return (Components.MetaComponents.ViewServiceComponent)GetComponent(MetaComponentsLookup.ViewService); } }
    public bool hasViewService { get { return HasComponent(MetaComponentsLookup.ViewService); } }

    public void AddViewService(Services.Interfaces.IViewService newInstance) {
        var index = MetaComponentsLookup.ViewService;
        var component = (Components.MetaComponents.ViewServiceComponent)CreateComponent(index, typeof(Components.MetaComponents.ViewServiceComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceViewService(Services.Interfaces.IViewService newInstance) {
        var index = MetaComponentsLookup.ViewService;
        var component = (Components.MetaComponents.ViewServiceComponent)CreateComponent(index, typeof(Components.MetaComponents.ViewServiceComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveViewService() {
        RemoveComponent(MetaComponentsLookup.ViewService);
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
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherViewService;

    public static Entitas.IMatcher<MetaEntity> ViewService {
        get {
            if (_matcherViewService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.ViewService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherViewService = matcher;
            }

            return _matcherViewService;
        }
    }
}
