using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAttackState : EnemyState
{
    private EnemySkeleton enemy;
    public EnemySkeletonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(0, 0);
        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeAttacked = Time.time;
    }

}
