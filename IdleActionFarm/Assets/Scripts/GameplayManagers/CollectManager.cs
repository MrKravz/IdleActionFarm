using Assets.Scripts.PlayerScripts;
using Assets.Scripts.UIScripts;
using UnityEngine;

namespace Assets.Scripts.GameplayManagers
{
    public class CollectManager : Manager
    {
        [SerializeField] private PlayerModel _player;
        [SerializeField] private UpdateWheatInfo _updateWheatInfoManager;

        private void Awake()
        {
            _player.Money.OnComponentAdded += () => { _updateWheatInfoManager.UpdateInfo(); };
        }

        public override void PerformManagedOperation()
        {
            _player.Wheat.Add(1);
        }
    }
}