using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public static GameObject CreateEnemyTarget(GameObject gameObject, Vector3 position)
    {
        var enemy = Instantiate(gameObject, position, Quaternion.LookRotation(new Vector3(0,0,-60)- position));
        return enemy;
    }

    public static GameObject CreateBuildEnemy(Vector3 position)
    {
        var BuildObject = new GameObject().SetName("TestBuilderEnemy").AddBoxCollider().AddMesh();//.AddRigidbody(50.0f);
        BuildObject.transform.position = position;
        return BuildObject;
    }
}
