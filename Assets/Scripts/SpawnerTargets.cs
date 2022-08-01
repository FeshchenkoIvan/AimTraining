using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerTargets : MonoBehaviour
{
    private float time = 60;
    [SerializeField] GameObject _TargetPref;
    public bool timer=false;
    public bool menu = false;
    public GameObject MenuPanel;
    public Text Timer;

    // Start is called before the first frame update
    void Start()
    {
        //MenuPanel.SetActive(false);
        Timer= GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            menu = !menu;
            if (!menu)
            {
                //GameObject.Find("Player").GetComponent<PlayerController>().SetSensitivity(MenuPanel.GetComponent<Menu>().SensMouse);
                GameObject.Find("Player").GetComponent<PlayerController>().sensitivy=MenuPanel.GetComponent<Menu>().SensMouse;
                Debug.Log("Чувствительность:" + MenuPanel.GetComponent<Menu>().SensMouse);
            }
            UnityEngine.Cursor.visible = menu;
            MenuPanel.SetActive(menu);
            timer = false;
            Timer.text = "60.00";
            GameObject.Find("Player").GetComponent<PlayerController>().Reset();
        }
            
        if (!menu)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                timer = true;
                time = 60;
                GameObject.Find("Player").GetComponent<PlayerController>().Reset();
            }

            if (timer)
            {
                if (!GameObject.FindGameObjectWithTag("Target"))
                {
                    CreateTarget();
                }
                time -= Time.deltaTime;
                Timer.text = time.ToString();
                //Debug.Log("Время: " + time);
                if (time <= 0)
                {
                    Timer.text = "0.000";
                    timer = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Result();
                }
            }
        }
    }

    private void CreateTarget()
    {
        Instantiate(_TargetPref, new Vector3(Random.Range(-7.6f,7.6f), Random.Range(0.4f, 5.6f), 20), Quaternion.Euler(-90,0,0));
        //bomb.Init(_explosionTime);
    }
}
