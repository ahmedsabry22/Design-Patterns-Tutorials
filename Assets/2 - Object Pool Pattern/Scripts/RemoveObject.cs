using UnityEngine;


public class RemoveObject : MonoBehaviour
{


    private PooledObject pooled_object_component;


    private void Awake ()
    {
        pooled_object_component = GetComponent<PooledObject> ();
    }


    private void OnMouseDown ()
    {
        pooled_object_component.Deactivate ();
    }


}