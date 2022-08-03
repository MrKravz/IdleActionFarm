using Assets.Scripts.DotweenAnimations;
using Assets.Scripts.Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class WheatComponent : MonoBehaviour, IEditableComponent
    {
        [SerializeField] private int _currentValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private HayClaimedAnimation _coinAnimation;
        [SerializeField] private UpdateWheatInfoManager _updateWheatInfoManager;
        public Action OnWheatAdded;
        public Action OnWheatReseted;

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
             OnWheatAdded += () => _updateWheatInfoManager.UpdateInfo(this);
             OnWheatReseted += () => _updateWheatInfoManager.UpdateInfo(this);
        }

        public void Add(int value)
        {
            if (_currentValue + value <= _maxValue)
            {
                _currentValue += value;
                OnWheatAdded?.Invoke();
                return;
            }
            _currentValue = _maxValue;
            OnWheatAdded?.Invoke();
        }

        public int Reset()
        {
            int value = _currentValue;
            _currentValue = 0;
            OnWheatReseted?.Invoke();
            return value;
        }

    }
}