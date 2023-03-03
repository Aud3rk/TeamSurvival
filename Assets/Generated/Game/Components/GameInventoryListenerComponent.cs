//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InventoryListenerComponent inventoryListener { get { return (InventoryListenerComponent)GetComponent(GameComponentsLookup.InventoryListener); } }
    public bool hasInventoryListener { get { return HasComponent(GameComponentsLookup.InventoryListener); } }

    public void AddInventoryListener(System.Collections.Generic.List<IInventoryListener> newValue) {
        var index = GameComponentsLookup.InventoryListener;
        var component = (InventoryListenerComponent)CreateComponent(index, typeof(InventoryListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInventoryListener(System.Collections.Generic.List<IInventoryListener> newValue) {
        var index = GameComponentsLookup.InventoryListener;
        var component = (InventoryListenerComponent)CreateComponent(index, typeof(InventoryListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInventoryListener() {
        RemoveComponent(GameComponentsLookup.InventoryListener);
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

    static Entitas.IMatcher<GameEntity> _matcherInventoryListener;

    public static Entitas.IMatcher<GameEntity> InventoryListener {
        get {
            if (_matcherInventoryListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InventoryListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInventoryListener = matcher;
            }

            return _matcherInventoryListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddInventoryListener(IInventoryListener value) {
        var listeners = hasInventoryListener
            ? inventoryListener.value
            : new System.Collections.Generic.List<IInventoryListener>();
        listeners.Add(value);
        ReplaceInventoryListener(listeners);
    }

    public void RemoveInventoryListener(IInventoryListener value, bool removeComponentWhenEmpty = true) {
        var listeners = inventoryListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveInventoryListener();
        } else {
            ReplaceInventoryListener(listeners);
        }
    }
}