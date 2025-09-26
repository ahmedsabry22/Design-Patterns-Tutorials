using UnityEngine;


public class JumpState : IState
{
    private Player player;

    private float jump_start_time;


    public JumpState ( Player player )
    {
        this.player = player;
    }


    public void Enter ()
    {
        player.animator.SetBool ( "IsJumping" , true );
        jump_start_time = Time.time;
        player.Jump ();
    }


    public void Update ()
    {
        if ( player.IsGrounded && Time.time > jump_start_time + 0.1f )
        {
            player.ChangeState ( new IdleState ( player ) );
        }
    }


    public void Exit ()
    {
        player.animator.SetBool ( "IsJumping" , false );
    }
}