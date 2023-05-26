using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonBattleState : EnemyState
{
    private Transform player;
    private EnemySkeleton enemy;
    private int moveDirection;
    public EnemySkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();
        if (player.position.x > enemy.transform.position.x)
        {
            moveDirection = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        { 
            moveDirection = -1; 
        }
        
        if (enemy.IsPlayerDetected())
        {
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }

        }

        enemy.SetVelocity(enemy.moveSpeed * moveDirection, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    { 
        if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }    

        Debug.Log("Attack is on cooldown");
        return false;
    }

}
