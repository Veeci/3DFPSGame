using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;

    private Animator animator;  // Reference to the Animator component

    public override void Enter()
    {
        animator = enemy.GetComponent<Animator>();  // Get the Animator
        animator.SetBool("IsWalking", true);       // Start walking animation
        enemy.Agent.speed = enemy.walkSpeed;       // Set walking speed
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public override void Exit()
    {
        animator.SetBool("IsWalking", false);       // Stop walking animation
    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            animator.SetBool("IsWalking", false);   // Stop walking animation
            animator.SetBool("IsIdle", true);       // Start idle animation

            waitTimer += Time.deltaTime;
            if (waitTimer > 3)
            {
                animator.SetBool("IsIdle", false);  // Stop idle animation
                animator.SetBool("IsWalking", true); // Start walking animation

                if (waypointIndex < enemy.path.wayPoints.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.wayPoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
