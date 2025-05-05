using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _textAid;
    [SerializeField] private TMPro.TextMeshProUGUI _textHealth;
    [SerializeField] private TMPro.TextMeshProUGUI _textBullet;
    [SerializeField] private TMPro.TextMeshProUGUI _textKey;
    [SerializeField] private TMPro.TextMeshProUGUI _textFlashlight;
    [SerializeField] private TMPro.TextMeshProUGUI _textGun;

    /*
    private void Start()
    {
        _armorSlider.maxValue = _armorMaxValue;
        _armorSlider.value = _armorMaxValue;

        _healthSlider.maxValue = _healthMaxValue;
        _healthSlider.value = _healthMaxValue;
    }
    */

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

    private void SetAid(int aid)
    {
        _textAid.text = "Аптечки: " + aid.ToString();
    }

    private void SetHealth(int health)
    {
        _textHealth.text = "Здоровье: " + health.ToString();
    }

    private void SetBullet(int bullet)
    {
        _textBullet.text = "Патроны: " + bullet.ToString();
    }

    private void SetKey(bool key)
    {
        _textKey.text = "Ключ: ";
        _textKey.text += key ? "есть" : "нет";
    }

    private void SetFlashlight(bool flashlight)
    {
        _textFlashlight.text = "Фонарик: ";
        _textFlashlight.text += flashlight ? "есть" : "нет";
    }

    private void SetGun(bool gun)
    {
        _textGun.text = "Пистолет: ";
        _textGun.text += gun ? "есть" : "нет";
    }
} 
