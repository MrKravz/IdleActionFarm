using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.WheatInteractions
{
    public enum EWheatProgress
    {
        Seeds,
        Seedlings,
        Mature
    }
    public class WheatGrowthManager : MonoBehaviour
    {
        [field: SerializeField] public EWheatProgress CurrentProgress { get; private set; } = EWheatProgress.Seeds;
        public event Action OnCultureCollect;
        public event Action OnWheatStageChanged;
        private bool _isCanGrow = true;

        private void Awake()
        {
            OnCultureCollect += () => { StartCoroutine(StartGrowthCoroutine()); };
            StartCoroutine(StartGrowthCoroutine());
        }

        public bool TryResetWheatProgress()
        {
            if (CurrentProgress == EWheatProgress.Mature)
            {
                CurrentProgress = EWheatProgress.Seeds;
                _isCanGrow = true;
                OnCultureCollect?.Invoke();
                return true;
            }
            return false;
        }

        private IEnumerator StartGrowthCoroutine()
        {
            while (_isCanGrow && CurrentProgress != EWheatProgress.Mature)
            {
                yield return new WaitForSecondsRealtime(5);
                if (CurrentProgress == EWheatProgress.Seeds)
                {
                    CurrentProgress = EWheatProgress.Seedlings;
                    OnWheatStageChanged?.Invoke();
                }
                else if (CurrentProgress == EWheatProgress.Seedlings)
                {
                    CurrentProgress = EWheatProgress.Mature;
                    OnWheatStageChanged?.Invoke();
                    _isCanGrow = false;
                }
               
            }
        }
    }
}