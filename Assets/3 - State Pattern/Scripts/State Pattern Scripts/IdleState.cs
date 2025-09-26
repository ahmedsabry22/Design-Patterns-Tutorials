using NUnit.Framework.Interfaces;
using UnityEngine;


public class IdleState : IState
{
    private Player player;


    public IdleState ( Player player )
    {
        this.player = player;
    }


    public void Enter ()
    {
        player.animator.SetBool ( "IsWalking" , false );
        player.animator.SetBool ( "IsRunning" , false );
        player.animator.SetBool ( "IsJumping" , false );
        player.animator.SetBool ( "IsSprinting" , false );
        player.animator.SetBool ( "IsCrouching" , false );
    }


    public void Update ()
    {
        if ( Input.GetKeyDown ( KeyCode.LeftControl ) )
        {
            player.ChangeState ( new WalkState ( player ) );
        }

        if ( Input.GetKeyDown ( KeyCode.LeftShift ) )
        {
            player.ChangeState ( new RunState ( player ) );
        }

        if ( Input.GetKeyDown ( KeyCode.Space ) )
        {
            player.ChangeState ( new JumpState ( player ) );
        }

        if ( Input.GetKeyDown ( KeyCode.W ) )
        {
            player.ChangeState ( new SprintState ( player ) );
        }

        if ( Input.GetKeyDown ( KeyCode.LeftAlt ) )
        {
            player.ChangeState ( new CrouchState ( player ) );
        }
    }


    public void Exit ()
    {

    }
}
