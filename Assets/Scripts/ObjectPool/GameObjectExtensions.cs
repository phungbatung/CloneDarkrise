using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static GameObject Spawn(this GameObject prefab)
    {
        return PoolManager.Spawn(prefab, Vector3.zero);
    }

    public static GameObject Spawn(this GameObject prefab, Vector3 position)
    {
        return PoolManager.Spawn(prefab, position);
    }

    public static GameObject Spawn(this GameObject prefab, Transform parent)
    {
        return PoolManager.Spawn(prefab, Vector3.zero, parent);
    }
    public static GameObject Spawn(this GameObject prefab, Vector3 position, Transform parent)
    {
        return PoolManager.Spawn(prefab, position, parent);
    }

    public static void Despawn(this GameObject prefab)
    {
        PoolManager.Despawn(prefab);
    }
}
