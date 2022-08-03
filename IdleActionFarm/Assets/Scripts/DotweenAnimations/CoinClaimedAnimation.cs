using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DotweenAnimations
{
    public class CoinClaimedAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private GameObject _resultedPosition;
        [SerializeField] private GameObject _currentMoney;
        [SerializeField] private GameObject _targetCanvas;
        [SerializeField] private Image _moneyFont;

        public void ClaimCoin()
        {
            var instance = Instantiate(_coinPrefab, new Vector3(0, 0, 0), new Quaternion());
            instance.transform.SetParent(_targetCanvas.transform);
            var coinMove = DOTween.Sequence().Append(instance.transform.DOMove(_resultedPosition.transform.position, 2));
            coinMove.Play();
            coinMove.OnComplete(() => { CoinReceived(instance); });
        }

        private void CoinReceived(GameObject instance)
        {
            Destroy(instance);
            BackgroundYellowHighlight();
            TextJump();
        }

        private void BackgroundYellowHighlight()
        {
            var coinMove = DOTween.Sequence().Append(_moneyFont.DOColor(Color.yellow, 0.15f).SetLoops(2, LoopType.Yoyo));
            coinMove.Play();
        }

        private void TextJump()
        {
            var coinMove = DOTween.Sequence().Append(_currentMoney.transform.DOMove(new Vector3(_currentMoney.transform.position.x, _currentMoney.transform.position.y + 10), 0.2f).SetLoops(2, LoopType.Yoyo));
            coinMove.Play();
        }
    }
}