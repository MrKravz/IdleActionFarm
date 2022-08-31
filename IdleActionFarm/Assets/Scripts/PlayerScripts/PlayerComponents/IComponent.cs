using System;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public interface IComponent
    {
        public event Action OnComponentAdded;
        public void Add(int value);
    }
}
