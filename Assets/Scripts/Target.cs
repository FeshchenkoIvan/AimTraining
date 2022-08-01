using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetLifetime = 0.5f;
    private float timer = 0;
    void Start()
    {
        Destroy(gameObject, targetLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        //timer = Time.fixedTime;
    }

    public float Delate()
    {
        Destroy(gameObject);
        //Debug.Log("Мишень: " + timer);
        return timer;
    }

    public void SetTLT(float value)
    {
        targetLifetime = value;
    }
}
