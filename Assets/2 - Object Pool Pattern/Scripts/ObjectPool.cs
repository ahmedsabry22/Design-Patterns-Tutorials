using UnityEngine;
using System.Collections.Generic;


public class ObjectPool : MonoBehaviour
{


    public int pool_size;
    public PooledObject object_to_pool;


    private Stack<PooledObject> pool_stack;


    private void Start ()
    {
        SetupPool ();
    }


    private void SetupPool ()
    {
        pool_stack = new Stack<PooledObject> ();
        PooledObject new_pooled_object = null;


        for ( int i = 0 ; i < pool_size ; i++ )
        {
            new_pooled_object = Instantiate ( object_to_pool );
            new_pooled_object.gameObject.SetActive ( false );

            new_pooled_object.pool = this;

            pool_stack.Push ( new_pooled_object );
        }
    }


    public PooledObject GetPooledObject ()
    {
        if ( pool_stack.Count == 0 )
        {
            PooledObject new_pooled_object = Instantiate ( object_to_pool );
            new_pooled_object.pool = this;

            pool_stack.Push ( new_pooled_object );

            return new_pooled_object;
        }

        PooledObject object_to_activate = pool_stack.Pop ();
        object_to_activate.gameObject.SetActive ( true );

        return object_to_activate;
    }


    public void ReturnToPool ( PooledObject object_to_return )
    {
        pool_stack.Push ( object_to_return );
        object_to_return.gameObject.SetActive ( false );
    }


}