using Assets.Scripts.DotweenAnimations;
using Assets.Scripts.PlayerScripts;
using Assets.Scripts.UIScripts;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GameplayManagers
{
    public class SellManager : Manager
    {
        [SerializeField] private PlayerModel _player;
        [SerializeField] private UpdateMoneyInfo _updateMoneyInfoManager;
        [SerializeField] private CoinClaimedAnimation _animation;
        [SerializeField] private UpdateWheatInfo _updateWheatInfoManager;
        [SerializeField] private int _priceOfHaystack;
        private AudioSource _sellWheatAudio;

        private void Awake()
        {
            _sellWheatAudio = GetComponent<AudioSource>();
            _player.Money.OnComponentAdded += () => { _updateMoneyInfoManager.UpdateInfo(); };
            _player.Wheat.OnComponentReseted += () => { _updateWheatInfoManager.UpdateInfo(); };
        }

        public override void PerformManagedOperation()
        {
            if (_player.Wheat.CurrentValue > 0)
            {
                _sellWheatAudio.Play();
                var resetedQuantity = _player.Wheat.Reset();
                StartCoroutine(CoinAnimationCoroutine(resetedQuantity));
            }
        }

        public IEnumerator CoinAnimationCoroutine(int value)
        {
            for (int i = 0; i < value; i++)
            {
                _animation.ClaimCoin();
                _player.Money.Add(1);
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
    }
}