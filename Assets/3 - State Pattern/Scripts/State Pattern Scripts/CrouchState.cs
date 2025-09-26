using UnityEngine;

public class CrouchState : IState
{
    private Player player;


    public CrouchState ( Player player )
    {
        this.player = player;
    }


    public void Enter ()
    {
        player.animator.SetBool ( "IsCrouching" , true );
    }


    public void Update ()
    {
        if ( Input.GetKeyUp ( KeyCode.LeftAlt ) )
        {
            player.ChangeState ( new IdleState ( player ) );
        }
    }


    public void Exit ()
    {
        player.animator.SetBool ( "IsCrouching" , false );
    }
}
