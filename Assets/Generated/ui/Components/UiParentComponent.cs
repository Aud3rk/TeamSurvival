//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public ParentComponent parent { get { return (ParentComponent)GetComponent(UiComponentsLookup.Parent); } }
    public bool hasParent { get { return HasComponent(UiComponentsLookup.Parent); } }

    public void AddParent(UnityEngine.GameObject newGameObject) {
        var index = UiComponentsLookup.Parent;
        var component = (ParentComponent)CreateComponent(index, typeof(ParentComponent));
        component.gameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceParent(UnityEngine.GameObject newGameObject) {
        var index = UiComponentsLookup.Parent;
        var component = (ParentComponent)CreateComponent(index, typeof(ParentComponent));
        component.gameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveParent() {
        RemoveComponent(UiComponentsLookup.Parent);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity : IParentEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherParent;

    public static Entitas.IMatcher<UiEntity> Parent {
        get {
            if (_matcherParent == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.Parent);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherParent = matcher;
            }

            return _matcherParent;
        }
    }
}
