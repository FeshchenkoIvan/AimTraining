using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//internal class ObjectPool
public class ObjectPool
{
    public readonly Stack<GameObject> _stack = new Stack<GameObject>();
    private readonly GameObject _prefab;
    
    public ObjectPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public void Push(GameObject go)
    {
        _stack.Push(go);
        go.SetActive(false);
    }

    public void Generate()
    {
        var gameObject = Enemy.CreateEnemyTarget(_prefab, new Vector3(0, 0, 0));//?
        _stack.Push(gameObject);
        gameObject.SetActive(false);
    }

    public void Pop()
    {
        if (_stack.Count > 0)
        {
            GameObject go = _stack.Pop();
            go.transform.position = new Vector3(Random.Range(-47, 47), 0, Random.Range(-109, -12));
            go.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -60) - go.transform.position);
            go.SetActive(true);
            //return go;
        }
        //else return null;
    }


}