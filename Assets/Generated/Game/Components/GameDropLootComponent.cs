//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DropLootComponent dropLoot { get { return (DropLootComponent)GetComponent(GameComponentsLookup.DropLoot); } }
    public bool hasDropLoot { get { return HasComponent(GameComponentsLookup.DropLoot); } }

    public void AddDropLoot(Loot newLoot) {
        var index = GameComponentsLookup.DropLoot;
        var component = (DropLootComponent)CreateComponent(index, typeof(DropLootComponent));
        component.loot = newLoot;
        AddComponent(index, component);
    }

    public void ReplaceDropLoot(Loot newLoot) {
        var index = GameComponentsLookup.DropLoot;
        var component = (DropLootComponent)CreateComponent(index, typeof(DropLootComponent));
        component.loot = newLoot;
        ReplaceComponent(index, component);
    }

    public void RemoveDropLoot() {
        RemoveComponent(GameComponentsLookup.DropLoot);
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

    static Entitas.IMatcher<GameEntity> _matcherDropLoot;

    public static Entitas.IMatcher<GameEntity> DropLoot {
        get {
            if (_matcherDropLoot == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DropLoot);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDropLoot = matcher;
            }

            return _matcherDropLoot;
        }
    }
}
