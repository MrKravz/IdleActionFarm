using Assets.Scripts.DotweenAnimations;
using Assets.Scripts.Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class MoneyComponent : MonoBehaviour, IOnlyAddableComponent
    {
        [SerializeField] private int _currentValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private CoinClaimedAnimation _coinAnimation;
        [SerializeField] private UpdateMoneyInfoManager _updateMoneyInfoManager;
        public Action OnMoneyAdded;

        public int CurrentValue
        {
            get
            {
                return _currentValue;
            }
        }

        public int MaxValue
        {
            get
            {
                return _maxValue;
            }
        }

        private void Awake()
        {
            OnMoneyAdded += () => _coinAnimation.ClaimCoin();
            OnMoneyAdded += () => _updateMoneyInfoManager.UpdateInfo(this);
        }
        
        public void Add(int value)
        {
            if (_currentValue + value <= _maxValue)
            {
                _currentValue += value;
                OnMoneyAdded?.Invoke();
                return;
            }
            _currentValue = _maxValue;
            OnMoneyAdded?.Invoke();
        }

    }
}