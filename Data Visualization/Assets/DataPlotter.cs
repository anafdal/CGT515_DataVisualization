using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataPlotter : MonoBehaviour
{

    // Name of the input file, no extension
    public string inputfile;


    // List for holding data from CSV reader
    private List<Dictionary<string, object>> dataList;

    //list
    private List<int> Case = new List<int>();//list of all the total cases
   

    //column names
    private string geoArea;
    private string caseRate;
    private int[] tempValue;

    public float plotScale = 10;

    // The prefab for the data points that will be instantiated
    public GameObject PointPrefab;
   


    // Object which will contain instantiated prefabs in hiearchy
    public GameObject PointHolder;

    // Use this for initialization
    void Start()
    {
       

            dataList = CSVReader.Read(inputfile);

            // Declare list of strings, fill with keys (column names)
            List<string> columnList = new List<string>(dataList[1].Keys);

            geoArea = columnList[0];//column for states
            caseRate = columnList[1];//column for date
            tempValue = new int[dataList.Count];//temporary array


            for (var j = 1; j < columnList.Count; j++)//through columns for dates
            {
                float z = j;//per date
                caseRate = columnList[j];//column for date
                Case = ChangeDate(caseRate);

                //Loop through Pointlist
                for (var i = 0; i < dataList.Count; i++)//go through row for states
                {
                    float x = i;//per state
                    float y = Case[i];
                    float ydef = (float)0.001 * y;
                    //Debug.Log("Case"+Case[i]);

                    // Instantiate as gameobject variable so that it can be manipulated within loop
                    GameObject dataPoint = Instantiate(
                            PointPrefab,
                            new Vector3(x, ydef, z) * plotScale,
                            Quaternion.identity);

                    // Make child of PointHolder object, to keep points within container in hiearchy
                    dataPoint.transform.parent = PointHolder.transform;

                    // Assigns original values to dataPointName
                    string dataPointName =
                        "Area: "+dataList[i][geoArea] + " Date: "
                        + columnList[j] + " Number: "
                        + dataList[i][caseRate];       

                    // Debug.Log(x + " " + y + " " + z);

                    // Assigns name to the prefab
                    dataPoint.transform.name = dataPointName;

                    // Gets material color and sets it to a new RGB color we define
                    dataPoint.GetComponent<Renderer>().material.color =
                        new Color(x / 10, y / 20, 1.0f, 1.0f);
                }
            }          

    }


   
    public List<int> ChangeDate(string caseRate)
    {
        Case.Clear();
        for (var n = 0; n < dataList.Count; n++)
        {

            tempValue[n] = System.Convert.ToInt32(dataList[n][caseRate]);//add previous values
            Case.Add(tempValue[n]);

        }

        //Debug.Log(temporary.Count);
        return Case;
    }

}
