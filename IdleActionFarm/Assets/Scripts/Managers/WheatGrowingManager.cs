using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{

    public enum EWheatProgress
    {
        Seeds,
        Seedlings,
        Mature
    }

    public class WheatGrowingManager : MonoBehaviour
    {
        [SerializeField] private EWheatProgress _currentProgress;

        private void Awake()
        {
            StartCoroutine(StartGrowthCoroutine());
        }

        public void CutWheat()
        {
            _currentProgress = EWheatProgress.Seeds;
            StartCoroutine(StartGrowthCoroutine());
        }
        
        private IEnumerator GrowSeedsCoroutine()
        {
            while (_currentProgress != EWheatProgress.Mature)
            {
                if (_currentProgress == EWheatProgress.Seeds)
                {
                    _currentProgress = EWheatProgress.Seedlings;
                }
                else if (_currentProgress == EWheatProgress.Seedlings)
                {
                    _currentProgress = EWheatProgress.Mature;
                }
                yield return new WaitForSecondsRealtime(5);
            }
        }

        private IEnumerator StartGrowthCoroutine()
        {
            yield return new WaitForSecondsRealtime(5);
            StartCoroutine(GrowSeedsCoroutine());
        }
    }
}