using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : Enemy
{
    float speed = 3;
    float time;
    public bool Dead { get; set; }

    void Start()
    {
        time = Random.Range(0.5f,1f);
        Dead = false;
    }
    void Update()
    {
            if (!Dead)
            {
                if (time <= 0)
                { speed *= -1; time = Random.Range(0.5f, 1f); }
                transform.Translate(speed * Time.deltaTime, 0, 0);
                time -= Time.deltaTime;
            }
            else
            {
                transform.Rotate(-100 * Time.deltaTime, 0, 0);
                if (transform.rotation.eulerAngles.x < 280)
                {
                    GameObject.Find("Location2").GetComponent<SpawnerEnemyTargets>().DeleteEnemyTarget(gameObject);
                    Dead = false;
                    gameObject.SetActive(false);
                }
            }
    }
}
