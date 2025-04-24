using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _сlips;
    [SerializeField] private float _walkStepDistance = 0.5f;
    [SerializeField] private float _runStepDistance = 0.3f;

    private CharacterController _controller;
    private float _stepDistance;
    private float _distanceMoved = 0f;
    private Vector3 _lastPosition;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 movement = transform.position - _lastPosition;
        movement.y = 0f; // Игнорируем вертикальное движение
        float distance = movement.magnitude;

        if (_controller.isGrounded && distance > 0.001f)
        {
            _distanceMoved += distance;
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            _stepDistance = isRunning ? _runStepDistance : _walkStepDistance;

            if (_distanceMoved > _stepDistance)
            {
                PlayFootstep(isRunning);
                _distanceMoved = 0f;
            }
        }

        _lastPosition = transform.position;
    }

    void PlayFootstep(bool isRunning)
    {
        AudioClip clip = _сlips[Random.Range(0, _сlips.Length)];
        _audioSource.PlayOneShot(clip);
    }
}
