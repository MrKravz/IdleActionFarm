using Assets.Scripts.UIScripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DotweenAnimations
{
    public class CoinClaimedAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _coinPrefab;
        [SerializeField] private Transform _resultedPosition;
        [SerializeField] private Transform _currentMoney;
        [SerializeField] private Transform _targetCanvas;
        [SerializeField] private Image _moneyFont;

        public void ClaimCoin()
        {
            var instance = Instantiate(_coinPrefab, Vector3.zero, new Quaternion());
            instance.SetParent(_targetCanvas);
            var coinMove = DOTween.Sequence().Append(instance.DOMove(_resultedPosition.position, 0.65f).SetEase(Ease.Linear));
            coinMove.Play();
            coinMove.OnComplete(() => { CoinReceived(instance.gameObject); });
        }

        private void CoinReceived(GameObject instance)
        {
            Destroy(instance);
            BackgroundYellowHighlight();
            TextJump();
        }

        private void BackgroundYellowHighlight()
        {
            var yellowHighlight = DOTween.Sequence().Append(_moneyFont.DOColor(Color.yellow, 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear));
            yellowHighlight.Play();
        }

        private void TextJump()
        {
            var textJump = DOTween.Sequence().Append(_currentMoney.DOMove(new Vector3(_currentMoney.position.x, _currentMoney.position.y + 10), 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear));
            textJump.Play();
        }
    }
}