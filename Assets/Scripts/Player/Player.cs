using System.Collections;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { get; private set; }

    [Header("Move")]
    public float moveSpeed = 8f;
    public float jumpForce;



    [Header("Dash")]
    [SerializeField] public float dashCooldown;
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashDuration;

    [Header("Combat")]
    public Vector2[] attackMovement;


    public float dashDirection { get; private set; }
    public float dashUseTimer;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }


    public PlayerPrimaryAttackState primaryAttackState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

        CheckForDashInput();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        dashUseTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUseTimer < 0 && !IsWallDetected())
        {
            dashUseTimer = dashCooldown;
            dashDirection = Input.GetAxisRaw("Horizontal");

            if (dashDirection == 0)
            {
                dashDirection = facingDirection;
            }
            stateMachine.ChangeState(dashState);
        }

    }
}
