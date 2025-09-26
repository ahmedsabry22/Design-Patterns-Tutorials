using UnityEngine;


public class TentSpawner : MonoBehaviour
{


    public ObjectPool tent_pool;


    private void Update ()
    {
        if ( Input.GetKeyDown ( KeyCode.X ) )
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
            RaycastHit hit;

            if ( Physics.Raycast ( ray , out hit , Mathf.Infinity ) )
            {
                PooledObject spawned_tent = tent_pool.GetPooledObject ();
                spawned_tent.transform.position = hit.point;
            }
        }
    }


}