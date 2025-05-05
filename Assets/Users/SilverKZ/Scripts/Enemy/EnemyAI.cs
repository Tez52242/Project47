using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle, Patrol, Chase, Attack, Dead }

    [SerializeField] private State _currentState = State.Idle;
    [SerializeField] private Transform[] _patrolPoints; 

    [SerializeField] private float _detectionRange = 10f;
    [SerializeField] private float _attackRange = 2f;

    [SerializeField] private float _health = 100f;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _hitBox;
    //[SerializeField] private NavMeshAgent _agent;

    private int _patrolIndex;
    private NavMeshAgent _agent;
    private Animator _animator;
    private bool _isShoot;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        //_player = GameObject.FindGameObjectWithTag("Player");
        _patrolIndex = 0;
        //_currentState = State.Patrol;
        //SetNextPatrolPoint(); 
        _isShoot = false;
    }

    private void Update()
    {
        if (_player == null) return;

        switch (_currentState)
        {
            case State.Idle:
                HandleIdle();
                break;
            case State.Patrol:
                HandlePatrol();
                break;
            case State.Chase:
                HandleChase();
                break;
            case State.Attack:
                HandleAttack();
                break;
            case State.Dead:
                HandleDeath();
                break;
        }
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    private void HandleIdle()
    {
        _animator.SetBool("isWalking", false);

        if (Vector3.Distance(transform.position, _player.position) < _detectionRange)
            _currentState = State.Chase;
    }

    private void HandlePatrol()
    {
        _animator.SetBool("isWalking", true);

        if (Vector3.Distance(transform.position, _player.position) < _detectionRange)
        {
            _currentState = State.Chase;
            return;
        }

        if (_agent.remainingDistance < 0.5f)
            SetNextPatrolPoint();
    }

    private void HandleChase()
    {
        _animator.SetBool("isWalking", true);

        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance > _detectionRange && _isShoot == false)
        {
            _currentState = State.Patrol;
            return;
        }

        if (distance > _detectionRange * 2 && _isShoot == true)
        {
            _isShoot = false;
            return;
        }

        _agent.SetDestination(_player.position);

        if (distance <= _attackRange)
        {
            _currentState = State.Attack;
        }
    }

    private void HandleAttack()
    {
        _agent.SetDestination(transform.position);
        _animator.SetBool("isWalking", false);
        _animator.SetTrigger("attack");

        if (Vector3.Distance(transform.position, _player.position) > _attackRange)
        {
            _currentState = State.Chase;
        }
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        _currentState = State.Chase;
        _isShoot = true;

        if (_health <= 0f)
        {
            _currentState = State.Dead;
        }
    }

    private void HandleDeath()
    {
        _agent.enabled = false;
        //GetComponent<Collider>().enabled = false;
        //_animator.SetTrigger("die");
        //GetComponent<EnemyRagdollDeath>().Die();
        this.enabled = false;
        Destroy(gameObject);
    }

    private void SetNextPatrolPoint()
    {
        if (_patrolPoints.Length == 0) return;
        _agent.SetDestination(_patrolPoints[_patrolIndex].position);
        _patrolIndex = (_patrolIndex + 1) % _patrolPoints.Length;
    }

    // Вызывается из Animation Event
    public void EnableHitbox()
    {
        _hitBox.SetActive(true);
    }

    public void DisableHitbox()
    {
        _hitBox.SetActive(false);
    }
}
