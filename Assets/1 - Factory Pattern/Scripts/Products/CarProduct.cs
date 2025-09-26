using UnityEngine;


public class CarProduct : MonoBehaviour, IProduct
{
    [SerializeField] private AudioSource audio_source;
    [SerializeField] private AudioClip start_engine_sfx;


    public void OnSpawned ()
    {
        audio_source.PlayOneShot ( start_engine_sfx );
    }
}