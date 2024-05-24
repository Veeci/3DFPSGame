using UnityEngine;

public class ChaseState : BaseState
{
    private Animator animator;

    public override void Enter()
    {
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("IsRunning", true);        // Start running animation
        enemy.Agent.speed = enemy.runSpeed;        // Set running speed
    }

    public override void Perform()
    {
        enemy.Agent.SetDestination(enemy.player.transform.position);  // Chase player
    }

    public override void Exit()
    {
        animator.SetBool("IsRunning", false);        // Stop running animation
    }
}
