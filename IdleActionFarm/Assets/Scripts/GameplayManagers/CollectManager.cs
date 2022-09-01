using Assets.Scripts.PlayerScripts;
using Assets.Scripts.UIScripts;
using Assets.Scripts.WheatInteractions;
using UnityEngine;

namespace Assets.Scripts.GameplayManagers
{
    public class CollectManager : Manager
    {
        [SerializeField] private PlayerModel _player;
        [SerializeField] private UpdateWheatInfo _updateWheatInfoManager;
        [SerializeField] private WheatGrowthManager _wheat;
        [SerializeField] private int _wheatValue;

        private void Awake()
        {
            _player.Wheat.OnComponentAdded += () => { _updateWheatInfoManager.UpdateInfo(); };
        }

        public override void PerformManagedOperation()
        {
            if (_wheat.TryResetWheatProgress())
            {
                _player.Wheat.Add(_wheatValue);
            }
        }
    }
}