using UnityEngine;


public class PooledObject : MonoBehaviour
{


    public ObjectPool pool;


    public void Deactivate ()
    {
        pool.ReturnToPool ( this );
    }


}