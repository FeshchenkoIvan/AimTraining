using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    int CheckTLTDropdown=0;
    public GameObject Target;
    public int TLT_Bonus;
    private Text TLTinfo;
    public float SensMouse;
    private Text SensValue;

    // Start is called before the first frame update
    void Start()
    {
        SensValue=transform.GetChild(1).GetComponent<Text>();
        SensValue.text = Convert.ToString(transform.GetChild(4).GetComponent<Slider>().value);
        SensMouse = transform.GetChild(4).GetComponent<Slider>().value;
        TLTinfo = GameObject.Find("TLT").GetComponent<Text>();
        CheckTLTDropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        TLT_Bonus = BonusTLT(CheckTLTDropdown);
        TLTinfo.text = "Время жизни мишени="+ GameObject.Find("Dropdown").GetComponent<Dropdown>().captionText.text + "сек\nБонус TLT="+ TLT_Bonus;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckTLTDropdown!= GameObject.Find("Dropdown").GetComponent<Dropdown>().value)
        {
            CheckTLTDropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
            Target.GetComponent<Target>().SetTLT(Convert.ToSingle(GameObject.Find("Dropdown").GetComponent<Dropdown>().captionText.text));
            TLT_Bonus = BonusTLT(CheckTLTDropdown);
            TLTinfo.text = "Время жизни мишени=" + GameObject.Find("Dropdown").GetComponent<Dropdown>().captionText.text + "сек\nБонус TLT=" + TLT_Bonus;
        }
        SensMouse=transform.GetChild(4).GetComponent<Slider>().value;
        SensValue.text = Convert.ToString(SensMouse);
    }

    public int BonusTLT(int value)
    {
        switch (value)
        {
            case 0: return 10;
            case 1: return 9;
            case 2: return 8;
            case 3: return 7;
            case 4: return 6;
            case 5: return 5;
            case 6: return 4;
            case 7: return 3;
            case 8: return 2;
            default: return 0;
        }
    }
}
