using Assets.Scripts.DotweenAnimations;
using Assets.Scripts.PlayerScripts.PlayerComponents;
using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SellManager : MonoBehaviour
    {
        [SerializeField] private WheatComponent _wheatComponent;
        [SerializeField] private MoneyComponent _moneyComponent;
        [SerializeField] private CoinClaimedAnimation _coinAnimation;
        [SerializeField] private int _priceOfHaystack;
        public Action<int> OnMoneyAdded;

        private void Awake()
        {
            OnMoneyAdded += (int value) => { StartCoroutine(_coinAnimation.ClaimCoins(value)); };
        }

        public void SellWheat()
        {
            var count = _wheatComponent.Reset();
            _moneyComponent.Add(count * _priceOfHaystack);
            OnMoneyAdded?.Invoke(count);
        }
    }
}