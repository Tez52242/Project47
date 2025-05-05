using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _fireRate = 5f; // выстрелов в секунду

    [SerializeField] private Transform _shotPoint;
    [SerializeField] private ParticleSystem _muzzleFlash; // Ёффект вспышки
    [SerializeField] private GameObject _impactEffect; // Ёффект попадани€
    [SerializeField] private GameObject _bulletTracerPrefab;
    [SerializeField] private Recoil _recoilScript; // Ёффект отдачи
    [SerializeField] private Player _player;

    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private AudioClip _audioClip;

    private float _nextTimeToFire = 0f;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_player.Bullet <= 0) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        _player.UpdateBullet(-1);

        _recoilScript.ApplyRecoil();
        _audioSource.PlayOneShot(_audioClip, 1f);

        if (_muzzleFlash != null)
        {
            _muzzleFlash.Play();
        }
            
        RaycastHit hit;
        
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            // Ёффект трассировки пули
            StartCoroutine(SpawnTracer(_shotPoint.position, hit.point));

            /*
            // ”рон цели
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                Debug.Log("ѕопадание в: " + hit.transform.name);
                target.TakeDamage(_damage);
            }
            */

            float damageToApply = _damage;
            BodyPart part = hit.collider.GetComponent<BodyPart>();

            if (part != null)
            {
                damageToApply *= part.DamageMultiplier;
            }

            EnemyAI enemyAI = hit.transform.GetComponentInParent<EnemyAI>();

            if (enemyAI != null)
            {
                enemyAI.TakeDamage(damageToApply);

                GameObject blood = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(blood, 1.5f);
            }
        }
        else // Ќа всю дистанцию
        {
            Vector3 hitPoint = _camera.transform.position + _camera.transform.forward * _range;
            StartCoroutine(SpawnTracer(_shotPoint.position, hitPoint)); 
        }
    }

    private IEnumerator SpawnTracer(Vector3 start, Vector3 end)
    {
        GameObject tracer = Instantiate(_bulletTracerPrefab);
        LineRenderer lr = tracer.GetComponent<LineRenderer>();
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        yield return new WaitForSeconds(0.02f); // или 0.1f дл€ дольше

        Destroy(tracer);
    }
}
