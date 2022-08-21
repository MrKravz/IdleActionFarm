using TMPro;
using UnityEngine;


namespace Assets.Scripts.UIScripts
{
    public abstract class UpdateUiInfo : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _valueText;

        public abstract void UpdateInfo();
    }
}