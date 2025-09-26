using UnityEngine;

public class WalkState : IState
{
    private Player player;


    public WalkState ( Player player )
    {
        this.player = player;
    }

    public void Enter ()
    {
        player.animator.SetBool ( "IsWalking" , true );
    }


    public void Update ()
    {
        if ( Input.GetKey ( KeyCode.LeftControl ) )
        {
            player.MoveForward ( 3.5f );
        }

        if ( Input.GetKeyUp ( KeyCode.LeftControl ) )
        {
            player.ChangeState ( new IdleState ( player ) );
        }
    }


    public void Exit ()
    {
        player.animator.SetBool ( "IsWalking" , false );
    }
}
