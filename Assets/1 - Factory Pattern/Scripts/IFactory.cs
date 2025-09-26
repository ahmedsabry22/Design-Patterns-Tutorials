using UnityEngine;

public interface IFactory
{
    public IProduct SpawnProduct ( Vector3 spawn_position , Quaternion spawn_rotation );
}
