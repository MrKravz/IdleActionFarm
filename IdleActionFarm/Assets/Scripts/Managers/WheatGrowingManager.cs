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
        [SerializeField] private EWheatProgress _currentProgress = EWheatProgress.Seeds;
        [SerializeField] private GameObject _hayPrefab;

        private void Awake()
        {
            StartCoroutine(StartGrowthCoroutine());
        }

        public void RefreshState()
        {
            _currentProgress = EWheatProgress.Seeds;
        }

        public void CutWheat()
        {
            if (_currentProgress == EWheatProgress.Mature)
            {
                Instantiate(_hayPrefab, transform.position, new Quaternion());
                RefreshState();
                StartCoroutine(StartGrowthCoroutine());
            }
        }

        private IEnumerator StartGrowthCoroutine()
        {
            yield return new WaitForSecondsRealtime(5);
            _currentProgress = EWheatProgress.Seedlings;
            Debug.Log(1);
            yield return new WaitForSecondsRealtime(5);
            _currentProgress = EWheatProgress.Mature;
            Debug.Log(2);
        }

    }
}