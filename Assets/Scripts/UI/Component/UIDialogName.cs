using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace UI.Component
{
    [ApplicationSurvive]
    public class UIDialogName : IComponent
    {
        [EntityIndex] public string indexer;
    }
}