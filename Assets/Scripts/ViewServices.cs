using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewServices
{
    private readonly Dictionary<int, ObjectPool> _viewCache
    = new Dictionary<int, ObjectPool>(2);

    public void Create(GameObject prefab)
    {
        if (!_viewCache.TryGetValue(prefab.GetInstanceID(), out ObjectPool viewPool))
        {
            viewPool = new ObjectPool(prefab);
            _viewCache[prefab.GetInstanceID()] = viewPool;
        }
        viewPool.Pop();
        Debug.Log("Количество префабов в стеке=" + viewPool._stack.Count);
    }

    public void Generate(GameObject prefab, int CountET)
    {
       ObjectPool viewPool = new ObjectPool(prefab);
       _viewCache[prefab.GetInstanceID()] = viewPool;

        for (int i = 0; i < CountET; i++)
        {viewPool.Generate();}
        Debug.Log("Резерв мишеней в сцене=" + viewPool._stack.Count);
    }

    public void Destroy(GameObject prefab, GameObject go)
    {
        _viewCache[prefab.GetInstanceID()].Push(go);
    }
}
