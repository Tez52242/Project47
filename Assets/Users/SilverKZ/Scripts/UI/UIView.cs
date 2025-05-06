using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIView : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearts;

    [SerializeField] private TextMeshProUGUI _textAid;
    [SerializeField] private TextMeshProUGUI _textBullet;
    [SerializeField] private TextMeshProUGUI _textKey;
    [SerializeField] private TextMeshProUGUI _textFlashlight;
    [SerializeField] private TextMeshProUGUI _textGun;

    [field: SerializeField] public Image MirrorArtImage { get; private set; }
    [field: SerializeField] public Image SafeArtImage { get; private set; }
    [field: SerializeField] public Image NoteArtImage { get; private set; }
    [field: SerializeField] public TextMeshProUGUI SafeArtText { get; private set; }

    private void OnEnable()
    {
        Player.onUpdateAid += SetAid;
        Player.onUpdateHealth += SetHealth;
        Player.onUpdateBullet += SetBullet;
        Player.onUpdateKey += SetKey;
        Player.onUpdateFlashlight += SetFlashlight;
        Player.onUpdateGun += SetGun;
    }

    private void OnDisable()
    {
        Player.onUpdateAid -= SetAid;
        Player.onUpdateHealth -= SetHealth;
        Player.onUpdateBullet -= SetBullet;
        Player.onUpdateKey -= SetKey;
        Player.onUpdateFlashlight -= SetFlashlight;
        Player.onUpdateGun -= SetGun;
    }

    private void SetAid(int aid) => _textAid.text = $"{TextsData.AidText} {aid}";

    private void SetHealth(int health)
    {
        Debug.Log($"SetHealth: {health}");
        
        for (int i = 0; i < _hearts.Length; i++)
        {
            // 0 1 2
            //currentHealth = 2 
            
            if (health-- >= i) _hearts[i].SetActive(true);  // 1 >= 0    1 >= 1    1 >= 2
            else _hearts[i].SetActive(false);
        }
    }

    private void SetBullet(int bullet) => _textBullet.text = $"{TextsData.BulletText} {bullet}";

    private void SetKey(bool key) => _textKey.text = $"{TextsData.KeyText} {(key ? "Да" : "Нет")}";

    private void SetFlashlight(bool flashlight) => _textFlashlight.text = $"{TextsData.FlashlightText} {(flashlight ? "Да" : "Нет")}";

    private void SetGun(bool gun) =>  _textGun.text = $"{TextsData.GunText} {(gun ? "Да" : "Нет")}";
}
