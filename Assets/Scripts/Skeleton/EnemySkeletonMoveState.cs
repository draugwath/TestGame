using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonMoveState : EnemySkeletonGroundedState
{
    public EnemySkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animationBoolName, enemy)
    {
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
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, rb.velocity.y);

        if(enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
