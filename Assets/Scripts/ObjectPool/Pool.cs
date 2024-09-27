using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private int initialPoolSize;

    private Stack<GameObject> pooledInstances = new Stack<GameObject>();
    private List<GameObject> aliveInstances = new List<GameObject>();
    private void Awake()
    {
        for(int i=0; i<initialPoolSize; i++)
        {
            GameObject instance = Instantiate(prefab);
            instance.transform.SetParent(transform);
            instance.transform.localPosition = Vector3.zero;
            instance.SetActive(false);
            pooledInstances.Push(instance);
        }
    }

    public GameObject Spawn(Vector3 position, Transform parent)
    {
        if (pooledInstances.Count < 0)
        {
            GameObject newInstance = Instantiate(prefab);
            pooledInstances.Push(newInstance);
        }


        GameObject obj = pooledInstances.Pop();
        obj.transform.SetParent(parent);
        obj.transform.position = position;
        obj.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        obj.SetActive(true);
        aliveInstances.Add(obj);
        return obj;
    }

    public void Despawn(GameObject obj)
    {
        int indexInstance = aliveInstances.FindIndex(o => obj == o);
        if (indexInstance == -1)
        {
            Destroy(obj);
            return;
        }

        obj.SendMessage("OnPreDisable", SendMessageOptions.DontRequireReceiver);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;

        aliveInstances.RemoveAt(indexInstance);
        pooledInstances.Push(obj);
    }

    public bool IsResponsibleForObject(GameObject obj)
    {
        return aliveInstances.Contains(obj);
    }
}
