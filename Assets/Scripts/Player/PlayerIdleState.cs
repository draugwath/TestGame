using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public float slideStopSpeed = 0.05f;
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

//        rb.velocity = new Vector2 (0, 0); // resetting velocity after entering Idle state to avoid sliding
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput == player.facingDirection && player.IsWallDetected())
        {
            return;
        }

        if (xInput != 0 && !player.isBusy)
            stateMachine.ChangeState(player.moveState);
        player.rb.velocity = new Vector2(Mathf.Lerp(player.rb.velocity.x, 0, slideStopSpeed), player.rb.velocity.y);
    }
}
