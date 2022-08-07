using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class WheatComponent : PlayerComponent, IEditableComponent
    {
        [SerializeField] private HayClaimedAnimation _coinAnimation;
        public Action OnWheatAdded;
        public Action OnWheatReseted;

        public void Add(int value)
        {
            if (CurrentValue + value <= MaxValue)
            {
                CurrentValue += value;
                OnWheatAdded?.Invoke();
                return;
            }
            CurrentValue = MaxValue;
            OnWheatAdded?.Invoke();
        }

        public int Reset()
        {
            int value = CurrentValue;
            CurrentValue = 0;
            OnWheatReseted?.Invoke();
            return value;
        }

    }
}