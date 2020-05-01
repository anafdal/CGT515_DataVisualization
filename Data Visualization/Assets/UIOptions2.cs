using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIOptions2 : MonoBehaviour
{
    public GameObject data1;
    public GameObject data2;

    //use scripts instead of objects
    void Start()
    {
        data1.SetActive(true);
        data2.SetActive(false);

    }

    public void PickData1()//Cases per state
    {

        data1.SetActive(true);
        data2.SetActive(false);
    }

    public void PickData2()//Death rate per state
    {

        data1.SetActive(false);
        data2.SetActive(true);
    }

}
