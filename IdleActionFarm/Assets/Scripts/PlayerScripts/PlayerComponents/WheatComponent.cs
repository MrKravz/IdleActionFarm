using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    [CreateAssetMenu(fileName = "WheatComponent", menuName = "Configs/WheatComponent", order = 1)]
    public class WheatComponent : PlayerComponent, IEditableComponent
    {
        public event Action OnComponentAdded;
        public event Action OnComponentReseted;

        public void Add(int value)
        {
            if (CurrentValue + value <= MaxValue)
            {
                CurrentValue += value;
                OnComponentAdded?.Invoke();
                return;
            }
        }

        public int Reset()
        {
            int value = CurrentValue;
            CurrentValue = 0;
            OnComponentReseted?.Invoke();
            return value;
        }
    }
}