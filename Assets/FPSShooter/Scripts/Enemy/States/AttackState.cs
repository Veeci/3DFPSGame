using UnityEngine;

public class AttackState : BaseState
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private float attackTimer = 0f;
    public float attackCooldown = 2f;
    private bool hasAttacked = false;

    public override void Enter()
    {
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("IsAttacking", true);
        attackTimer = 0f;
        hasAttacked = false;

        // Ensure the player reference is valid
        if (enemy.player != null)
        {
            playerHealth = enemy.player.GetComponent<PlayerHealth>();
            Debug.Log("PlayerHealth component found and referenced.");
        }
        else
        {
            Debug.LogWarning("Player not found in AttackState!");
        }

        // Ensuring the Rigidbody is kinematic
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public override void Perform()
    {
        if (playerHealth == null) 
        {
            stateMachine.ChangeState(stateMachine.chaseState);
            return;
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown && !hasAttacked)
        {
            // Check if player is still in range to attack
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, playerHealth.transform.position);
            Debug.Log($"Distance to player: {distanceToPlayer}");
            if (distanceToPlayer <= enemy.attackRange)
            {
                animator.SetTrigger("Attack");
                attackTimer = 0f;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.chaseState);
            }
        }
    }

    public override void Exit()
    {
        animator.SetBool("IsAttacking", false);
        hasAttacked = false;
    }

    // Animation Event method 
    public void OnAttackHitEvent()
    {
        if (!hasAttacked && playerHealth != null)
        {
            // Manually check if player is in attack range (again, in case player moved during animation)
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, playerHealth.transform.position);
            Debug.Log($"OnAttackHitEvent triggered. Distance to player: {distanceToPlayer}");
            if (distanceToPlayer <= enemy.attackRange)
            {
                Debug.Log($"Player within attack range. Dealing {enemy.attackDamage} damage.");
                playerHealth.TakeDamage(enemy.attackDamage);
                hasAttacked = true;
            }
            else
            {
                // Player moved out of attack range during animation, transition back to chase state
                stateMachine.ChangeState(stateMachine.chaseState);
            }
        }
    }
}