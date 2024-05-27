using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }

    [SerializeField]
    private string currentState;
    public Path path;

    public GameObject player;
    public float sightDistance = 30f;
    public float fieldOfView = 85f;

    public float walkSpeed = 3f;  // Adjust as needed
    public float runSpeed = 4f;   // Add running speed
    public float attackRange = 2f;  // Distance at which enemy attacks
    public float attackDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer())
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                stateMachine.ChangeState(stateMachine.attackState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.chaseState);
            }
        }
        else if (stateMachine.activeState == stateMachine.chaseState || stateMachine.activeState == stateMachine.attackState)
        {
            stateMachine.ChangeState(stateMachine.patrolState);
        }
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position, targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }
        }
        return false;
    }
}