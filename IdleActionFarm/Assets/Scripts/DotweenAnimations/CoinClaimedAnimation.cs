using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DotweenAnimations
{
    public class CoinClaimedAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private GameObject _resultedPosition;
        [SerializeField] private Image _moneyFont;
        [SerializeField] private GameObject _currentMoney;
        [SerializeField] private GameObject _targetCanvas;

        public void ClaimCoin()
        {
            TextJump();
            YellowHighlight();
        }

        private IEnumerator CoinFly()
        {

            var instance = Instantiate(_coinPrefab, new Vector3(0, 0, 0), new Quaternion());
            Debug.Log(_resultedPosition.transform.position.x + " " + _resultedPosition.transform.position.y + " " + _resultedPosition.transform.position.z);
            instance.transform.SetParent(_targetCanvas.transform);
            instance.transform.DOMove(_resultedPosition.transform.position, 5);
            Debug.Log(instance.transform.position.x + " " + instance.transform.position.y + " " + instance.transform.position.z);
            yield return new WaitForSecondsRealtime(1);
        }

        private void YellowHighlight()
        {
            _moneyFont.DOColor(Color.yellow, 0.15f).SetLoops(2, LoopType.Yoyo);
        }


        private void TextJump()
        {
            _currentMoney.transform.DOMove(new Vector3(_currentMoney.transform.position.x, _currentMoney.transform.position.y + 10), 0.2f).SetLoops(2, LoopType.Yoyo);
        }
    }
}