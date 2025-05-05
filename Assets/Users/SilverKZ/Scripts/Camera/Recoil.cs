using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] private Vector3 _recoilAmount = new Vector3(-2f, 1f, 0f); // вверх + случайный поворот
    [SerializeField] private float _recoilSpeed = 10f;
    [SerializeField] private float _returnSpeed = 15f;

    private Vector3 _currentRotation;
    private Vector3 _targetRotation;

    void Update()
    {
        _targetRotation = Vector3.Lerp(_targetRotation, Vector3.zero, _returnSpeed * Time.deltaTime);
        _currentRotation = Vector3.Lerp(_currentRotation, _targetRotation, _recoilSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(_currentRotation);
    }

    public void ApplyRecoil()
    {
        _targetRotation += new Vector3(
            Random.Range(_recoilAmount.x * 0.8f, _recoilAmount.x * 1.2f),
            Random.Range(-_recoilAmount.y, _recoilAmount.y),
            0f);
    }
}
