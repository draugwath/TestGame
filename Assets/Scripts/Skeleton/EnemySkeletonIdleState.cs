using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonIdleState : EnemySkeletonGroundedState
{
    public EnemySkeletonIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animationBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
