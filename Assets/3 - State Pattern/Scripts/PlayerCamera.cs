using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    public float rotation_speed;
    public float follow_speed;


    public Transform player_to_follow;


    private float mouse_x;


    private void Start ()
    {
    }


    private void LateUpdate ()
    {
        mouse_x = Input.GetAxis ( "Mouse X" );
        transform.position = Vector3.Lerp ( transform.position , player_to_follow.position , follow_speed * Time.deltaTime );

        transform.rotation *= Quaternion.Euler ( 0 , mouse_x * rotation_speed * Time.deltaTime , 0 );
    }
}