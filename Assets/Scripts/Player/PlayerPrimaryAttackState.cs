using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;

    private float lastTimeAttacked;
    public float comboWindow = .5f;
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow) 
        {
            comboCounter = 0;
        }
        player.Animator.SetInteger("ComboCounter", comboCounter);

#region Attack direction
        float attackDirection = player.facingDirection;
        if (xInput != 0)
        {
            attackDirection = xInput;
        }
#endregion

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDirection, player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("BusyFor", .2f);

        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
