using UnityEngine;

public class EnemyRagdollDeath : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] ragdollBodies;
    public Collider[] ragdollColliders;

    public MonoBehaviour[] aiScripts; // скрипты ИИ, которые нужно отключить

    void Start()
    {
        SetRagdollActive(false);
    }

    public void Die()
    {
        // отключаем AI и анимацию
        foreach (var script in aiScripts)
            script.enabled = false;

        animator.enabled = false;
        SetRagdollActive(true);
    }

    void SetRagdollActive(bool isActive)
    {
        foreach (var rb in ragdollBodies)
            rb.isKinematic = !isActive;

        foreach (var col in ragdollColliders)
            col.enabled = isActive;
    }

    // можно вызвать снаружи с импульсом
    public void DieWithForce(Vector3 force, Vector3 point)
    {
        Die();
        foreach (var rb in ragdollBodies)
            rb.AddForceAtPosition(force, point, ForceMode.Impulse);
    }
}
