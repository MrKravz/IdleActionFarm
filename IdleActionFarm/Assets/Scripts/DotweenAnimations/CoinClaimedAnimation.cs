using Assets.Scripts.Managers;
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
        [SerializeField] private GameObject _currentMoney;
        [SerializeField] private GameObject _targetCanvas;
        [SerializeField] private Image _moneyFont;
        [SerializeField] private UpdateMoneyInfoManager _updateMoneyInfoManager;

        public IEnumerator ClaimCoins(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ClaimCoin();
                yield return new WaitForSecondsRealtime(0.7f);
            }
            _updateMoneyInfoManager.UpdateInfo();
        }

        public void ClaimCoin()
        {
            var instance = Instantiate(_coinPrefab, new Vector3(0, 0, 0), new Quaternion());
            instance.transform.SetParent(_targetCanvas.transform);
            var coinMove = DOTween.Sequence().Append(instance.transform.DOMove(_resultedPosition.transform.position, 1f));
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
            var yellowHighlight = DOTween.Sequence().Append(_moneyFont.DOColor(Color.yellow, 0.15f).SetLoops(2, LoopType.Yoyo));
            yellowHighlight.Play();
        }

        private void TextJump()
        {
            var textJump = DOTween.Sequence().Append(_currentMoney.transform.DOMove(new Vector3(_currentMoney.transform.position.x, _currentMoney.transform.position.y + 10), 0.2f).SetLoops(2, LoopType.Yoyo));
            textJump.Play();
            textJump.OnComplete(() => { });
        }
    }
}