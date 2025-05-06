using UnityEngine;
using TMPro;

public class PickupTextPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _text;

    public void Show(string text)
    {
        _panel.SetActive(true);
        _text.text = text;
    }

    public void Hide() => _panel.SetActive(false);
}
