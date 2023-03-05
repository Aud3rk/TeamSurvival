//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyActualTimerListenerComponent anyActualTimerListener { get { return (AnyActualTimerListenerComponent)GetComponent(GameComponentsLookup.AnyActualTimerListener); } }
    public bool hasAnyActualTimerListener { get { return HasComponent(GameComponentsLookup.AnyActualTimerListener); } }

    public void AddAnyActualTimerListener(System.Collections.Generic.List<IAnyActualTimerListener> newValue) {
        var index = GameComponentsLookup.AnyActualTimerListener;
        var component = (AnyActualTimerListenerComponent)CreateComponent(index, typeof(AnyActualTimerListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyActualTimerListener(System.Collections.Generic.List<IAnyActualTimerListener> newValue) {
        var index = GameComponentsLookup.AnyActualTimerListener;
        var component = (AnyActualTimerListenerComponent)CreateComponent(index, typeof(AnyActualTimerListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyActualTimerListener() {
        RemoveComponent(GameComponentsLookup.AnyActualTimerListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyActualTimerListener;

    public static Entitas.IMatcher<GameEntity> AnyActualTimerListener {
        get {
            if (_matcherAnyActualTimerListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyActualTimerListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyActualTimerListener = matcher;
            }

            return _matcherAnyActualTimerListener;
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

    public void AddAnyActualTimerListener(IAnyActualTimerListener value) {
        var listeners = hasAnyActualTimerListener
            ? anyActualTimerListener.value
            : new System.Collections.Generic.List<IAnyActualTimerListener>();
        listeners.Add(value);
        ReplaceAnyActualTimerListener(listeners);
    }

    public void RemoveAnyActualTimerListener(IAnyActualTimerListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyActualTimerListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyActualTimerListener();
        } else {
            ReplaceAnyActualTimerListener(listeners);
        }
    }
}