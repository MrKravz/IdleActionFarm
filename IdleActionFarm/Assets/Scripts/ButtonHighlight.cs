using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnTriggerEnter(Collider other)
    {
        button.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        button.gameObject.SetActive(false);
    }
}
