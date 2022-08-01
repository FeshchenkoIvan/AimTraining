using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    private AudioSource _audioShot = GameObject.Find("Player").GetComponent<AudioSource>();
    private AudioSource _audioTarget = GameObject.Find("Spawner").GetComponent<AudioSource>();
    public int CountShots=0;
    public int CountTargets=0;
    public List<float> TimeHitTargets = new List<float>();
    RaycastHit hit;

    void Start()
    {

    }

    public void CheckShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audioShot.Play();
            CountShots++;
            var rayCast = Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit, 100f);
            if (rayCast)
            {
                Debug.Log("Попал в: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Target")
                {
                    _audioTarget.Play();
                    CountTargets++;
                    TimeHitTargets.Add(GameObject.Find(hit.collider.gameObject.name).GetComponent<Target>().Delate());
                }
            }
        }
    }

    public void Reset()
    {
        TimeHitTargets.Clear();
        CountShots = 0;
        CountTargets = 0;
    }

}
