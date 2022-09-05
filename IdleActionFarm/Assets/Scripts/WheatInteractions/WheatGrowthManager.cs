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
        public bool IsCanGrow { get; private set; } = true;

        private void Awake()
        {
            OnCultureCollect += () => { StartCoroutine(StartGrowthCoroutine()); };
            StartCoroutine(StartGrowthCoroutine());
        }

        public void ResetWheatProgress()
        {
            if (CurrentProgress == EWheatProgress.Mature)
            {
                CurrentProgress = EWheatProgress.Seeds;
                IsCanGrow = true;
                OnCultureCollect?.Invoke();
            }
        }

        private IEnumerator StartGrowthCoroutine()
        {
            while (IsCanGrow && CurrentProgress != EWheatProgress.Mature)
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
                    IsCanGrow = false;
                }
               
            }
        }
    }
}