using UnityEngine;

public class AttackState : BaseState
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private float attackTimer = 0f;
    public float attackCooldown = 2f;
    private bool hasAttacked = false;

    private Collider attackCollider;
    private MonoBehaviour monoBehaviour; // Added for Invoke and GetComponentInChildren

    public override void Enter()
    {
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("IsAttacking", true);
        attackTimer = 0f;  // Reset attack timer
        hasAttacked = false; // Reset attack flag

        // Find the PlayerHealth component of the player object
        playerHealth = enemy.player.GetComponent<PlayerHealth>();

        // Get the MonoBehaviour component to access GetComponent and Invoke
        monoBehaviour = enemy.GetComponent<MonoBehaviour>();
        attackCollider = monoBehaviour.GetComponentInChildren<Collider>();
        if (attackCollider != null)
        {
            attackCollider.enabled = false; // Disable initially
        }
    }

    public override void Perform()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            if (enemy.CanSeePlayer())
            {
                stateMachine.ChangeState(stateMachine.chaseState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.patrolState);
            }

            attackTimer = 0f;
        }
    }

    public override void Exit()
    {
        animator.SetBool("IsAttacking", false);
        hasAttacked = false;
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }

    public void OnAttackHitEvent()
    {
        if (!hasAttacked && playerHealth != null)
        {
            if (attackCollider != null)
            {
                attackCollider.enabled = true;

                // Manually check if player is in attack range
                if (Vector3.Distance(enemy.transform.position, playerHealth.transform.position) <= enemy.attackRange)
                {
                    playerHealth.TakeDamage(enemy.attackDamage);
                    hasAttacked = true;
                }

                monoBehaviour.Invoke("DisableAttackCollider", 0.1f); // Use MonoBehaviour for Invoke
            }
        }
    }

    private void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }
}
