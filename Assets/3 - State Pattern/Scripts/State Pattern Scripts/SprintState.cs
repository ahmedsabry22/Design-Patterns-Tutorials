using UnityEngine;

public class SprintState : IState
{
    private Player player;


    public SprintState ( Player player )
    {
        this.player = player;
    }


    public void Enter ()
    {
        player.animator.SetBool ( "IsSprinting" , true );
    }


    public void Update ()
    {
        if ( Input.GetKey ( KeyCode.W ) )
        {
            player.MoveForward ( 13 );
        }

        if ( Input.GetKeyUp ( KeyCode.W ) )
        {
            player.ChangeState ( new IdleState ( player ) );
        }
    }


    public void Exit ()
    {
        player.animator.SetBool ( "IsSprinting" , false );
    }
}
