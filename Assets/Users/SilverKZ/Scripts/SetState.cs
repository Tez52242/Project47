using UnityEngine;

public class SetState : MonoBehaviour
{
    [SerializeField] private PlayerMovement _component1;
    [SerializeField] private RuntimeAnimatorController _animatorController1;
    [SerializeField] private PlayerGunMovement _component2;
    [SerializeField] private RuntimeAnimatorController _animatorController2;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _component1.enabled = true;
        _animator.runtimeAnimatorController = _animatorController1;
        _component2.enabled = false;
    }

    private void Update()
    {
        bool key1 = Input.GetKeyDown("1");
        bool key2 = Input.GetKeyDown("2");

        if (key1 == true)
        {
            _component2.enabled = false;
            _animator.runtimeAnimatorController = _animatorController1;
            _component1.enabled = true;
        }

        if (key2 == true)
        {
            _component1.enabled = false;
            _animator.runtimeAnimatorController = _animatorController2;
            _component2.enabled = true;
        }
    }
}
