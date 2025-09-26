using UnityEngine;


public class EnemyProduct : MonoBehaviour, IProduct
{
    [SerializeField] private ParticleSystem spawn_vfx;


    public void OnSpawned ()
    {
        spawn_vfx.Play ();
    }
}