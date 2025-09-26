using UnityEngine;

public class RunState : IState
{
    private Player player;


    public RunState ( Player player )
    {
        this.player = player;
    }


    public void Enter ()
    {
        player.animator.SetBool ( "IsRunning" , true );
    }


    public void Update ()
    {
        if ( Input.GetKey ( KeyCode.LeftShift ) )
        {
            player.MoveForward ( 7f );
        }

        if ( Input.GetKeyUp ( KeyCode.LeftShift ) )
        {
            player.ChangeState ( new IdleState ( player ) );
        }
    }


    public void Exit ()
    {
        player.animator.SetBool ( "IsRunning" , false );
    }
}
