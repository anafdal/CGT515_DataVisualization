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

    public static int color=1;
  
   

    public void Pick(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public void PickData1()//Total cases per state
    {
        state0.SetActive(true);

        //naming
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }


        method = 0;//don't show animation
        choice = 1;
    }

    public void PickData2()//Death rate per state
    {
        //Debug.Log("2");
        state0.SetActive(true);

        //naming
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }


        method = 0;//don't show animation
        choice = 2;
    }

    public void PickData3()//Currently active cases per state
    {
        state0.SetActive(true);
        //naming
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }



        method = 0;//don't show animation
        choice = 3;
    }

    public void PickData4()//Recovered cases per state
    {
        state0.SetActive(true);
        //naming
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }


        method = 0;//don't show animation
        choice = 4;
    }

    public void PickData5()//Total tests per state
    {
        state0.SetActive(true);
        //naming
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }

        method = 0;//don't show animation
        choice = 5;
    }

    public void Pickmethod1()//animation for total cases
    {
        
        //Debug.Log("Picked one");

        //reset
        foreach (Transform child in state0.transform)
        {
            child.transform.localScale = Vector3.one;
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
        }

        state0.SetActive(false);


            method = 1;
            choice = 0;//only show animation      

    }
    public void Pickmethod2()//animation for total deaths
    {
        //Debug.Log("Picked two");

        //reset
        foreach (Transform child in state0.transform)
        {
           
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
            child.transform.localScale = Vector3.one;
        }
     


        state0.SetActive(false);

        method = 2;
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
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }
        color = 1;
    }

    public void PickMedian()
    {
        int index = 0;
        foreach (Transform child in state0.transform)
        {
            child.transform.name = ColumnPlotter.Name[index];
            index++;
        }
        color = 2;
    }


  
}
