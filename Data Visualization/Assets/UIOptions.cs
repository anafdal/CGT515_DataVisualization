using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    public static int choice = 1;
    public static int method = 0;
    public GameObject state0;
    public GameObject state1;
    public GameObject state2;

    public GameObject Animation;
    public GameObject NoAnimation;
    public GameObject main;

    public ColumnAnimation1 data1;
    public ColumnAnimation2 data2;

    public static int color=1;
    

    public void Pick(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public void PickData1()//Total cases per state
    {
        method = 0;//don't show animation
        choice = 1;
    }

    public void PickData2()//Death rate per state
    {
        method = 0;//don't show animation
        choice = 2;
    }

    public void PickData3()//Currently active cases per state
    {
        method = 0;//don't show animation
        choice = 3;
    }

    public void PickData4()//Recovered cases per state
    {
        method = 0;//don't show animation
        choice = 4;
    }

    public void PickData5()//Total tests per state
    {
        method = 0;//don't show animation
        choice = 5;
    }

    public void Pickmethod1()//animation for total cases
    {
        
        Debug.Log("Picked one");

        //reset
        foreach (Transform child in state0.transform)
        {
            child.transform.localScale = Vector3.one;
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
        }
        /*foreach(Transform child in state2.transform)
        {
            child.transform.localScale = new Vector3(child.localScale.x, 1, child.localScale.z);
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
        }*/


       
            method = 1;
           // data1.enabled = true;
           // data2.enabled = false;
            choice = 0;//only show animation
        

    }
    public void Pickmethod2()//animation for total deaths
    {
        Debug.Log("Picked two");

        //reset
        foreach (Transform child in state0.transform)
        {
           
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
            child.transform.localScale = Vector3.one;
        }
      /*  foreach (Transform child in state1.transform)
        {
            child.transform.localScale = new Vector3(child.localScale.x,1,child.localScale.z);
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
        }*/


        
            method = 2;
       // data1.enabled = false;
        //data2.enabled = true;
        choice = 0;//only show animation
        
    }

    public void PickTabAnim()
    {
        main.SetActive(false);
        Animation.SetActive(true);

    }

    public void PickTabNoANIm()
    {
        main.SetActive(false);
        NoAnimation.SetActive(true);

    }

    public void GoBack()
    {

        main.SetActive(true);

        NoAnimation.SetActive(false);
        Animation.SetActive(false);
    }

    public void PickMean()
    {
        color = 1;
    }

    public void PickMedian()
    {
        color = 2;
    }


  
}
