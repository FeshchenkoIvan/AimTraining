using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5;
    //private Vector3 _direction;
    private int CountShots = 0;
    private int CountTargets = 0;
    public float sensitivy { get; set; }
    RaycastHit hit;
    private AudioSource _audioShot;
    private AudioSource _audioZvuk;
    public List<float> TimeHitTargets;
    public Text _result;
    public GameObject Menu;
    private PlayerMoveTransform _playerMoveTransform;
    //private Shoting _shoting;

    //private AudioSource _audioShot;
    // Start is called before the first frame update
    void Start()
    {
        //_shoting = new Shoting();
        _playerMoveTransform = new PlayerMoveTransform(transform, _speed);
        sensitivy = 2;
        _result = GameObject.Find("Result").GetComponent<Text>();
        TimeHitTargets = new List<float>();
        _audioZvuk = GameObject.Find("Spawner").GetComponent<AudioSource>();
        //_audioZvuk = Resources.Load<AudioClip>("Audio/zvuk");
        _audioShot = gameObject.GetComponent<AudioSource>();
        UnityEngine.Cursor.visible = false;

        Services.Instance.Test();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Spawner").GetComponent<SpawnerTargets>().menu)
        {
            _playerMoveTransform.Rotation(sensitivy);
            _playerMoveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),Time.deltaTime);

            //_shoting.CheckShot();
            if (Input.GetMouseButtonDown(0))
            {
                _audioShot.Play();
                CountShots++;
                var rayCast2 = Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit, 100f);
                if (rayCast2)
                {
                    Debug.Log("Попал в: " + hit.collider.gameObject.name);
                    if (hit.collider.gameObject.tag == "Target")
                    {
                        //Debug.Log("точка:" + hit.point);
                        _audioZvuk.Play();
                        CountTargets++;
                        TimeHitTargets.Add(GameObject.Find(hit.collider.gameObject.name).GetComponent<Target>().Delate());
                    }
                    if (hit.collider.gameObject.tag == "Head")
                    {
                        _audioZvuk.Play();
                        CountTargets++;
                        hit.collider.GetComponentInParent<EnemyTarget>().Dead=true;
                    }
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (transform.position.z> -10)
                transform.position = new Vector3(0, 0, -60);
            else
                transform.position = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var objectsInRadius in Services.Instance.GetObjectsInRadius(transform.position, 50.0f))
            {
                Debug.Log(objectsInRadius.name);
            }
        }

    }


    public void Result()
    {
        //int TLT_Bonus=GameObject.Find("Canvas").GetComponent<Menu>().TLT_Bonus;
        int TLT_Bonus = Menu.GetComponent<Menu>().TLT_Bonus;
        TimeHitTargets.Sort();
        float sum = 0;
        for (int i = 0; i < TimeHitTargets.Count; i++)
        {
            sum += TimeHitTargets[i];
        }

        _result.text =
            "Очки=" + (TLT_Bonus / (sum / TimeHitTargets.Count)) * CountTargets +
            "\nКоличество мишеней:" + TimeHitTargets.Count +
            "\nЛучшая реакция: " + TimeHitTargets[0] +
            "\nСреднее время реакции: " + sum / TimeHitTargets.Count;

        Reset();
    }
    public void Reset()
    {
        TimeHitTargets.Clear();
        CountShots = 0;
        CountTargets = 0;
    }

}
