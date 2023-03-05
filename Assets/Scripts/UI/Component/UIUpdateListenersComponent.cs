using Entitas;
using UI.Abstractions;

namespace UI.Component
{
    [ApplicationSurvive]
    public class UIUpdateListenersComponent : IComponent
    {
        public IUpdateListeners updateListeners;
    }
}