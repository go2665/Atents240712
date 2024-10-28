using UnityEngine;

public class StateDie : IState
{
    /// <summary>
    /// 이 상태를 관리하는 상태머신
    /// </summary>
    private EnemyStateMachine stateMachine;

    // 애니메이터용 해시

    public StateDie(EnemyStateMachine enemyStateMachine)
    {
        stateMachine = enemyStateMachine;
    }

    public void Enter()
    {
        Debug.Log("상태 진입 - Die");
    }

    public void Exit()
    {
        Debug.Log("상태 나감 - Die");
    }

    public void Update()
    {
    }
}