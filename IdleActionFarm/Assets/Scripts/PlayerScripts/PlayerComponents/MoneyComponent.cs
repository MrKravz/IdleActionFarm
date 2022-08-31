using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    [CreateAssetMenu(fileName = "MoneyComponent", menuName = "Configs/MoneyComponent", order = 2)]
    public class MoneyComponent : PlayerComponent, IComponent
    {
        public event Action OnComponentAdded;

        public void Add(int value)
        {
            if (CurrentValue + value <= MaxValue)
            {
                CurrentValue += value;
                OnComponentAdded?.Invoke();
                return;
            }
        }
    }

}