using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target; // Объект, за которым следует камера
    [SerializeField] private float minX, maxX, minZ, maxZ; // Границы камеры

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        // Ограничиваем позицию камеры по X и Z (если top-down)
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedZ = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

        transform.position = new Vector3(clampedX, desiredPosition.y, clampedZ);
    }
}






    /*
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothing = 0.1f;
    [SerializeField] private Vector3 _minPosition;
    [SerializeField] private Vector3 _maxPosition;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        if (transform.position != _player.position)   
        {
            Vector3 targetPosition = new Vector3(_player.position.x, transform.position.y, _player.position.z);// + _offset;
            //Vector3 targetPosition = _player.transform.position;
            //targetPosition = _player.transform.position + _offset;
            //targetPosition.x = Mathf.Clamp(_player.position.x, _minPosition.x, _maxPosition.x);
            targetPosition.x = Mathf.Clamp(targetPosition.x, _minPosition.x, _maxPosition.x);
            //targetPosition.z = Mathf.Clamp(_player.position.z, _minPosition.z, _maxPosition.z);
            targetPosition.z = Mathf.Clamp(targetPosition.z, _minPosition.z, _maxPosition.z);
            //targetPosition = _player.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing);
        }
    }
}
    */
