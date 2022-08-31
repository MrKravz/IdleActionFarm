using System;
using System.Collections;
using System.Threading.Tasks;
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

        public void ResetWheatProgress()
        {
            CurrentProgress = EWheatProgress.Seeds;
            OnCultureCollect?.Invoke();
        }

        private IEnumerator StartGrowthCoroutine()
        {
            while (_isCanGrow && CurrentProgress != EWheatProgress.Mature)
            {
                if (CurrentProgress == EWheatProgress.Seeds)
                {
                    yield return new WaitForSecondsRealtime(5);
                    CurrentProgress = EWheatProgress.Seedlings;
                    OnWheatStageChanged?.Invoke();
                }
                if (CurrentProgress == EWheatProgress.Seedlings)
                {
                    yield return new WaitForSecondsRealtime(5);
                    CurrentProgress = EWheatProgress.Mature;
                    OnWheatStageChanged?.Invoke();

                }
            }
        }
    }
}