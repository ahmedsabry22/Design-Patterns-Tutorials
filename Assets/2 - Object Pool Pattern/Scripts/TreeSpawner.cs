using UnityEngine;


public class TreeSpawner : MonoBehaviour
{


    public ObjectPool tree_pool;


    private void Update ()
    {
        if ( Input.GetKeyDown ( KeyCode.Z ) )
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
            RaycastHit hit;

            if ( Physics.Raycast ( ray , out hit , Mathf.Infinity ) )
            {
                PooledObject spawned_tree = tree_pool.GetPooledObject ();
                spawned_tree.transform.position = hit.point;
            }
        }
    }


}