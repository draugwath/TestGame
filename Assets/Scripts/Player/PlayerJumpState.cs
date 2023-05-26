using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    protected float airControlMultiplier = 0.8f;
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);

        if (xInput != 0)
        {
            player.SetVelocity(player.moveSpeed * xInput * airControlMultiplier, rb.velocity.y);
        }
    }
}
