using Assets.Scripts.DotweenAnimations;
using Assets.Scripts.PlayerScripts.PlayerComponents;
using Assets.Scripts.UIScripts;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{

    [RequireComponent(typeof(AudioSource))]
    public class SellManager : MonoBehaviour
    {
        [SerializeField] private WheatComponent _wheatComponent;
        [SerializeField] private MoneyComponent _moneyComponent;
        [SerializeField] private CoinClaimedAnimation _coinAnimation;
        [SerializeField] private UpdateUiInfo _updateWheatInfoManager;
        [SerializeField] private int _priceOfHaystack;
        private AudioSource _sellWheatAudio;
        public event Action OnSellPerformed;

        private void Awake()
        {
            _sellWheatAudio = GetComponent<AudioSource>();
            OnSellPerformed += () => { _coinAnimation.ClaimCoin(); };
        }

        public void SellAllWheat()
        {
            if (_wheatComponent.CurrentValue > 0)
            {
                _sellWheatAudio.Play();
                var currentWheat = _wheatComponent.Reset();
                _updateWheatInfoManager.UpdateInfo();
                StartCoroutine(SellWheatCoroutine(currentWheat));
            }
        }

        public IEnumerator SellWheatCoroutine(int value)
        {
            while (value > 0)
            {
                OnSellPerformed?.Invoke();
                _moneyComponent.Add(_priceOfHaystack);
                value--;
                yield return new WaitForSecondsRealtime(0.35f);
            }
        }
    }
}