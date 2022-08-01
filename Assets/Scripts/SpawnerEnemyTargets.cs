using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyTargets : MonoBehaviour
{
    private float time = 2;
    public GameObject _PrefabEnemyTarget;
    private ViewServices _viewServices = new ViewServices();

    void Start()
    {
        Enemy.CreateBuildEnemy(new Vector3(0, 0, 0));
        _viewServices.Generate(_PrefabEnemyTarget, 10);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            _viewServices.Create(_PrefabEnemyTarget);
            time = 2;
        }
    }

    public void DeleteEnemyTarget(GameObject gameObject)
    {
        _viewServices.Destroy(_PrefabEnemyTarget, gameObject);
    } 
}
