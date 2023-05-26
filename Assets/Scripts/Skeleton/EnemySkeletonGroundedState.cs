using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonGroundedState : EnemyState
{
    protected EnemySkeleton enemy;
    public EnemySkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(enemy.IsPlayerDetected())
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
