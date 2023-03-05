//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Components.RemoveEntityComponent removeEntityComponent = new Components.RemoveEntityComponent();

    public bool isRemoveEntity {
        get { return HasComponent(GameComponentsLookup.RemoveEntity); }
        set {
            if (value != isRemoveEntity) {
                var index = GameComponentsLookup.RemoveEntity;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : removeEntityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherRemoveEntity;

    public static Entitas.IMatcher<GameEntity> RemoveEntity {
        get {
            if (_matcherRemoveEntity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RemoveEntity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRemoveEntity = matcher;
            }

            return _matcherRemoveEntity;
        }
    }
}
