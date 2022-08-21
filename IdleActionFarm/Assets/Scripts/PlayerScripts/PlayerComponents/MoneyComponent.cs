using System;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class MoneyComponent : PlayerComponent, IOnlyAddableComponent
    {
        public event Action OnMoneyAdded;
        
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