using System;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public interface IEditableComponent : IComponent
    {
        public event Action OnComponentReseted;
        public int Reset();
    }
}
