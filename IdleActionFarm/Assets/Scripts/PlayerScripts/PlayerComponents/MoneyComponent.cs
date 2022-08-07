using Assets.Scripts.DotweenAnimations;
using Assets.Scripts.Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class MoneyComponent : PlayerComponent, IOnlyAddableComponent
    {
        public Action OnMoneyAdded;
        
        public void Add(int value)
        {
            if (CurrentValue + value <= MaxValue)
            {
                CurrentValue += value;
                OnMoneyAdded?.Invoke();
                return;
            }
            CurrentValue = MaxValue;
            OnMoneyAdded?.Invoke();
        }

    }
}