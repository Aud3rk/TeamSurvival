//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ApplicationSurviveContext {

    public ApplicationSurviveEntity uIConfigEntity { get { return GetGroup(ApplicationSurviveMatcher.UIConfig).GetSingleEntity(); } }
    public UIConfigComponent uIConfig { get { return uIConfigEntity.uIConfig; } }
    public bool hasUIConfig { get { return uIConfigEntity != null; } }

    public ApplicationSurviveEntity SetUIConfig(Data.UIConfig newValue) {
        if (hasUIConfig) {
            throw new Entitas.EntitasException("Could not set UIConfig!\n" + this + " already has an entity with UIConfigComponent!",
                "You should check if the context already has a uIConfigEntity before setting it or use context.ReplaceUIConfig().");
        }
        var entity = CreateEntity();
        entity.AddUIConfig(newValue);
        return entity;
    }

    public void ReplaceUIConfig(Data.UIConfig newValue) {
        var entity = uIConfigEntity;
        if (entity == null) {
            entity = SetUIConfig(newValue);
        } else {
            entity.ReplaceUIConfig(newValue);
        }
    }

    public void RemoveUIConfig() {
        uIConfigEntity.Destroy();
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
public partial class ApplicationSurviveEntity {

    public UIConfigComponent uIConfig { get { return (UIConfigComponent)GetComponent(ApplicationSurviveComponentsLookup.UIConfig); } }
    public bool hasUIConfig { get { return HasComponent(ApplicationSurviveComponentsLookup.UIConfig); } }

    public void AddUIConfig(Data.UIConfig newValue) {
        var index = ApplicationSurviveComponentsLookup.UIConfig;
        var component = (UIConfigComponent)CreateComponent(index, typeof(UIConfigComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUIConfig(Data.UIConfig newValue) {
        var index = ApplicationSurviveComponentsLookup.UIConfig;
        var component = (UIConfigComponent)CreateComponent(index, typeof(UIConfigComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUIConfig() {
        RemoveComponent(ApplicationSurviveComponentsLookup.UIConfig);
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
public sealed partial class ApplicationSurviveMatcher {

    static Entitas.IMatcher<ApplicationSurviveEntity> _matcherUIConfig;

    public static Entitas.IMatcher<ApplicationSurviveEntity> UIConfig {
        get {
            if (_matcherUIConfig == null) {
                var matcher = (Entitas.Matcher<ApplicationSurviveEntity>)Entitas.Matcher<ApplicationSurviveEntity>.AllOf(ApplicationSurviveComponentsLookup.UIConfig);
                matcher.componentNames = ApplicationSurviveComponentsLookup.componentNames;
                _matcherUIConfig = matcher;
            }

            return _matcherUIConfig;
        }
    }
}