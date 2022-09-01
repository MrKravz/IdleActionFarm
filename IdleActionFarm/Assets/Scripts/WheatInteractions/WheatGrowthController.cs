using UnityEngine;

namespace Assets.Scripts.WheatInteractions
{
    public class WheatGrowthController : MonoBehaviour
    {
        [SerializeField] private GameObject _wheatSeedsStage;
        [SerializeField] private GameObject _wheatSeedlingsStage;
        [SerializeField] private GameObject _wheatMatureStage;
        [SerializeField] private WheatGrowthManager _wheatGrowthManager;

        private void Awake()
        {
            _wheatGrowthManager.OnCultureCollect += () => { UpdateVisual(); };
            _wheatGrowthManager.OnWheatStageChanged += () => { UpdateVisual(); };
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (_wheatGrowthManager.CurrentProgress == EWheatProgress.Seeds)
            {
                _wheatSeedsStage.SetActive(true);
                _wheatSeedlingsStage.SetActive(false);
                _wheatMatureStage.SetActive(false);
                return;
            }
            else if (_wheatGrowthManager.CurrentProgress == EWheatProgress.Seedlings)
            {

                _wheatSeedlingsStage.SetActive(true);
                _wheatSeedsStage.SetActive(false);
                _wheatMatureStage.SetActive(false);
                return;
            }
            _wheatSeedsStage.SetActive(false);
            _wheatMatureStage.SetActive(true);
            _wheatSeedlingsStage.SetActive(false);
        }
    }
}