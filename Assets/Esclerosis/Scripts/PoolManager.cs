using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton_Template<PoolManager>
{
    Dictionary<string, List<GameObject>> pool;
    Transform poolParent;

    private void Awake()
    {
        pool = new Dictionary<string, List<GameObject>>();
        poolParent = new GameObject("Pool Parent").transform;
    }

    public void Load(GameObject prefab, int quantity = 1)
    {
        var goName = prefab.name;
        if (!pool.ContainsKey(goName))
        {
            pool[goName] = new List<GameObject>();
        }

        for (int i = 0; i < quantity; i++)
        {
            var go = Instantiate(prefab);
            go.name = goName;
            go.transform.parent = poolParent;
            go.SetActive(false);
            pool[go.name].Add(go);
        }
    }

    public GameObject Spawn(GameObject prefab)
    {
        if (!pool.ContainsKey(prefab.name) || pool[prefab.name].Count == 0)
        {
            Load(prefab, 1);
        }
        var l = pool[prefab.name];
        var go = l[0];
        l.RemoveAt(0);
        go.SetActive(true);
        go.transform.parent = null;
        return go;
    }

    public void Despawn(GameObject go)
    {
        if (!pool.ContainsKey(go.name))
        {
            pool[go.name] = new List<GameObject>();
        }
        go.SetActive(false);
        go.transform.parent = poolParent;
        pool[go.name].Add(go);
    }
}