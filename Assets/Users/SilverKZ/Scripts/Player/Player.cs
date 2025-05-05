using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth = 1;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private int _health;
    private int _aid;
    private int _bullet;
    private bool _key;
    private bool _flashlight;
    private bool _gun;
    private CharacterController _characterController;

    public int Health { get { return _health; } private set { } }
    public int Aid { get { return _aid; } private set { } }
    public int MaxHealth { get { return _maxHealth; } private set { } }
    public int Bullet { get { return _bullet; } private set { } }
    public bool Key { get { return _key; } private set { } }
    public bool Flashlight { get { return _flashlight; } private set { } }
    public bool Gun { get { return _gun; } private set { } }

    public static Action<int> onUpdateHealth;
    public static Action<int> onUpdateAid;
    public static Action<int> onUpdateBullet;
    public static Action<bool> onUpdateKey;
    public static Action<bool> onUpdateFlashlight;
    public static Action<bool> onUpdateGun;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Init();
    }

    private void Init()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>().SetPlayer(transform);
        }

        _characterController.enabled = false;
        //_health = _maxHealth;
        _health = _currentHealth;
        _aid = 0;
        _bullet = 0;
        _key = false;
        _gun = false;
        onUpdateHealth?.Invoke(_health);
        onUpdateAid?.Invoke(_aid);
        onUpdateBullet?.Invoke(_bullet);
        onUpdateKey?.Invoke(_key);
        onUpdateFlashlight?.Invoke(_flashlight);
        onUpdateGun?.Invoke(_gun);
        //gameObject.transform.position = Vector3.zero + new Vector3(0f, 1f, 0f); 
        _characterController.enabled = true;
    }

    public void UpdateAid(int amount)
    {
        _aid += amount;
        _aid = Mathf.Clamp(_aid, 0, 100);
        onUpdateAid?.Invoke(_aid);
    }

    public void UpdateHealth(int amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        onUpdateHealth?.Invoke(_health);

        if (_health <= 0) 
        {
            //Init();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _audioSource.PlayOneShot(_audioClip, 1f);
            StartCoroutine(LoadScene());
        }
    }

    public void UpdateBullet(int amount)
    {
        _bullet += amount; 
        _bullet = Mathf.Clamp(_bullet, 0, 100);
        onUpdateBullet?.Invoke(_bullet); 
    }

    public void UpdateKey(bool key)
    {
        _key = key;
        onUpdateKey?.Invoke(_key);
    }

    public void UpdateFlashlight(bool flashlight)
    {
        _flashlight = flashlight;
        onUpdateFlashlight?.Invoke(_flashlight);
    }

    public void UpdateGun(bool gun)
    {
        _gun = gun;
        onUpdateGun?.Invoke(_gun);
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.07f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
