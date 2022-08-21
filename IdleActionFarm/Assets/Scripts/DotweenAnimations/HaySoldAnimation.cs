using Assets.Scripts.UIScripts;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.DotweenAnimations
{
    public class HaySoldAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _wheatPrefab;
        [SerializeField] private GameObject _resultedPosition;
        [SerializeField] private GameObject _targetCanvas;
        [SerializeField] private UpdateUiInfo _updateWheatInfoManager;

        public IEnumerator SoldHays(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SoldHay();
                yield return new WaitForSecondsRealtime(0.7f);
            }
            _updateWheatInfoManager.UpdateInfo();
        }

        public void SoldHay()
        {
            var instance = Instantiate(_wheatPrefab, _resultedPosition.transform.position, new Quaternion());
            instance.transform.SetParent(_targetCanvas.transform);
            var coinMove = DOTween.Sequence().Append(instance.transform.DOMove(Vector3.zero, 1f));
            coinMove.Play();
            coinMove.OnComplete(() => { Destroy(instance); });
        }

    }
}