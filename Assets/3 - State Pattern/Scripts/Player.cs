using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    public float jump_force = 5;
    public Animator animator;


    public PlayerCamera player_camera;


    [Header ( "Ground Check" )]
    public Transform ground_check;
    public float ground_radius = 0.2f;
    public LayerMask ground_layer;


    private new Rigidbody rigidbody;


    private IState current_state;


    public bool IsGrounded
    {
        get
        {
            return Physics.CheckSphere ( ground_check.position , ground_radius , ground_layer ) && rigidbody.linearVelocity.y == 0;
        }
    }


    private void Awake ()
    {
        animator = GetComponent<Animator> ();
        rigidbody = GetComponent<Rigidbody> ();
    }


    private void Start ()
    {
        ChangeState ( new IdleState ( this ) );
    }


    private void Update ()
    {
        current_state.Update ();
    }


    public void ChangeState ( IState new_state )
    {
        if ( current_state != null )
        {
            current_state.Exit ();
        }

        current_state = new_state;
        current_state.Enter ();
    }


    public void MoveForward ( float move_speed )
    {
        rigidbody.MovePosition ( transform.position + transform.forward * move_speed * Time.deltaTime );
        rigidbody.rotation = player_camera.transform.rotation;
    }


    public void Jump ()
    {
        if ( IsGrounded )
        {
            rigidbody.AddForce ( Vector3.up * jump_force , ForceMode.Impulse );
        }
    }


    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere ( ground_check.position , ground_radius );
    }
}