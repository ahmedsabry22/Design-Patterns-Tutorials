using UnityEngine;


public class EnemyFactory : MonoBehaviour, IFactory
{
    public GameObject enemy_prefab;


    public IProduct SpawnProduct ( Vector3 spawn_position , Quaternion spawn_rotation )
    {
        GameObject spawned_enemy = Instantiate ( enemy_prefab , spawn_position , spawn_rotation );

        IProduct product = spawned_enemy.GetComponent<IProduct> ();

        product.OnSpawned ();

        return product;
    }


    private void Update ()
    {
        if ( Input.GetMouseButtonDown ( 0 ) )
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
            RaycastHit hit;

            if ( Physics.Raycast ( ray , out hit , Mathf.Infinity ) )
            {
                SpawnProduct ( hit.point , Quaternion.Euler ( Vector3.up * ( Random.value * 360 ) ) );
            }
        }
    }
}