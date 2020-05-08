using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ColumnAnimation2 : MonoBehaviour
{
    public string inputFile;
    public GameObject parent;
    public Text other;
    public Text days;

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> dataList;
    private List<string> columnList;
    private List<string> Area = new List<string>();//list of all the states and US territories
    private List<int> temporary = new List<int>();


    //column names
    private string geoArea;
    private string tempList;



    //settings
    public float columnScale = 0.1f;
    private bool value = true;

    void Start()
    {
        dataList = CSVReader.Read(inputFile);
        days.text = "Time";
        


        columnList = new List<string>(dataList[1].Keys);


        geoArea = columnList[0];//column

        //tempList = columnList[29];//test



        //Loop through dataList
        for (var i = 0; i < dataList.Count; i++)
        {

            Area.Add(System.Convert.ToString(dataList[i][geoArea]));

        }
    }


    void Update()
    {


        if (UIOptions.method == 2)//if user selects this animation
        {
            other.enabled = false;
            days.enabled = true;

            parent.SetActive(true);

            if (value == true)
            {

                StartCoroutine(RateCoroutine());
            }

        }
        else
        {
            foreach (Transform child in parent.transform)
            {
                child.transform.localScale = new Vector3(child.localScale.x, 1, child.localScale.z);
                child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
             
            }

            parent.SetActive(false);
            value = true;
        }

    }



    IEnumerator RateCoroutine()//wait for ... seconds before car becomes active
    {

        //put some kind of delay here
        for (var u = 1; u < columnList.Count; u++)
        {

            tempList = columnList[u];
            temporary = Add(tempList);
            days.text = "Day " + u;

            yield return new WaitForSeconds((float)0.3);
            ChangeColumn(temporary);
        }

        value = false;
        
    }


    public void ChangeColumn(List<int> temporary)//the animation part
    {

        for (var i = 0; i < dataList.Count; i++)
        {

            foreach (Transform child in parent.transform)
            {
                if (child.name == Area[i])
                {


                    //statistics
                    int y = temporary[i];
                    float addY = y * columnScale;

                   /* if (child.name == Area[54])
                    {
                        Debug.Log(Area[i] + " " + temporary[i]);
                    }*/



                    //how columns are located
                    child.transform.localPosition = new Vector3(child.localPosition.x, addY / 2, child.localPosition.z);
                    child.transform.localScale = new Vector3(71, addY, 71);
                    child.GetComponent<Renderer>().material.color = Color.red;


                    /* if (child.name == "Alabama") {
                         Debug.Log(child.transform.localScale);
                     }*/

                }


            }
        }

    }

    public List<int> Add(string tempList)
    {
        temporary.Clear();
        for (var n = 0; n < dataList.Count; n++)
        {

            temporary.Add(System.Convert.ToInt32(dataList[n][tempList]));

            //temporary.Add(System.Convert.ToInt32(dataList[n][tempList]));
            //Debug.Log(n);

        }

        // Debug.Log(temporary.Count);
        return temporary;

    }



}
