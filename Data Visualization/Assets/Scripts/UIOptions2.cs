using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions2 : MonoBehaviour
{
    

   public GameObject one;
   public GameObject two;

    //use scripts instead of objects
    void Start()
    {
        one.SetActive(true);
        two.SetActive(false);

        
    }

    public void PickData1()//Cases per state
    {
       one.SetActive(true);
       two.SetActive(false);
    }

    public void PickData2()//Death rate per state
    {
        one.SetActive(false);
        two.SetActive(true);
      
    }

}
