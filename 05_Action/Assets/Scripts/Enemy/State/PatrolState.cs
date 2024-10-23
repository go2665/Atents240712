using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IState
{
    // 상태머신에게 받는 것들
    EnemyStateMachine stateMachine;
    Waypoints waypoints;
    NavMeshAgent agent;
    Animator animator;

    readonly int Move_Hash = Animator.StringToHash("Move");

    public PatrolState(EnemyStateMachine enemyStateMachine)
    {
        stateMachine = enemyStateMachine;
        waypoints = stateMachine.Waypoints;
        agent = stateMachine.Agent;
        animator = stateMachine.Animator;
    }


    public void Enter()
    {
        Debug.Log("Patrol 상태 진입");
        agent.isStopped = false;        // agent 다시 켜기
        agent.SetDestination(waypoints.NextTarget);  // 목적지 지정(웨이포인트 지점)
        animator.SetTrigger(Move_Hash);
    }

    public void Exit()
    {
        Debug.Log("Patrol 상태 나감");
    }

    public void Update()
    {
        if (stateMachine.SearchPlayer(out Vector3 target))
        {
            stateMachine.TransitionToChase();
        }
        else
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                waypoints.StepNextWaypoint();
                stateMachine.TransitionToWait();
            }
        }
    }
}
