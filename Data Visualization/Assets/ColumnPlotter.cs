using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColumnPlotter : MonoBehaviour
{/// <summary>
/// Code modified from
/// </summary>
    public string inputFile;
    public GameObject parent;

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> dataList;
    private List<string> columnList;
     
    private List<string> Area = new List<string>();//list of all the states and US territories
    private List<int> Case= new List<int>();//list of all the total cases
    private List<int> Dec= new List<int>();//list of all the death cases
    private List<int> Population = new List<int>();//list of total population per area
    private List<int> Active = new List<int>();//list of active cases currently
    private List<int> Test= new List<int>();//list of testing done
    private List<int> Recovered = new List<int>();//list of people recovered from the virus

    //column names
    private string geoArea;
    private string caseRate;
    private string deathRate;
    private string activeCasesRate;
    private string recovered;
    private string testRate;
    private string population;

    //settings
    public float columnScale = 10000.0f;
    private float y=0;
    private float addY=0;
    private float mean=0;
    public static Vector3 previousSize;
    public static Vector3 previousPos;
    private float median = 0;
    private float lowquart = 0;
    private float highquart = 0;
    

    void Start()
    {
        dataList = CSVReader.Read(inputFile);

        previousSize = parent.transform.GetChild(0).transform.localScale;//get previous y size
        previousPos = parent.transform.GetChild(0).transform.localPosition;//get previous y position

        columnList = new List<string>(dataList[1].Keys);

        // Print number of keys to test
        //Debug.Log("There are " + columnList.Count + " columns in CSV");
      /*  foreach (string key in columnList)
        {
            //Debug.Log("Column name is " + key);

        }*/


        geoArea = columnList[0];//column
        population = columnList[1];
        caseRate = columnList[2];//column
        deathRate = columnList[3];//column
        activeCasesRate = columnList[4];
        recovered = columnList[5];
        testRate = columnList[6];
        //Debug.Log(columnList[0]);

        //Loop through dataList
        for (var i = 0; i < dataList.Count; i++)//take the usa out from here dumbass
        {
            // Get value in poinList at ith "row", in "column" Name
            Area.Add(System.Convert.ToString(dataList[i][geoArea]));
            Case.Add(System.Convert.ToInt32(dataList[i][caseRate]));
            Dec.Add(System.Convert.ToInt32(dataList[i][deathRate]));
            Population.Add(System.Convert.ToInt32(dataList[i][population]));
            Active.Add(System.Convert.ToInt32(dataList[i][activeCasesRate]));
            Test.Add(System.Convert.ToInt32(dataList[i][testRate]));
            Recovered.Add(System.Convert.ToInt32(dataList[i][recovered]));


            //Debug.Log(Area[i]+ " " + Case[i] + " " + Dec[i]+" "+Population[i]+" "+Active[i]+" "+Test[i]+" "+Recovered[i]);

         }

    }



    // Update is called once per frame
    void Update()
    {

 
        for (var i = 0; i < dataList.Count-1; i++)
        {
            foreach (Transform child in parent.transform)
            {
           
                if (child.name == Area[i])
                {
                    if (UIOptions.choice==1)//Total Cases
                    {
                        child.transform.localScale = previousSize;//reset
                        child.transform.localPosition =new Vector3(child.transform.localPosition.x, previousPos.y, child.transform.localPosition.z);

                        //statistics
                        y = Statistics.normalizeValue(Statistics.FindMinValue(caseRate,dataList), Statistics.FindMaxValue(caseRate,dataList), Case[i]);
                        addY = y * columnScale;
                        mean = Statistics.findMean(caseRate,dataList);
                        median = Statistics.findMedian(Case);
                        lowquart = Statistics.findLowerQuartile(median, Case);
                        highquart = Statistics.findHigherQuartile(median, Case);

                        //how columns are located
                        child.transform.localPosition+= new Vector3(0, addY/2, 0);
                        child.transform.localScale += new Vector3(0, addY, 0);

                       
                        if (UIOptions.color == 2)
                        { //ChangeColor(lowquart, highquart, mean, Case);

                            if (Case[i] < lowquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.green;
                            }
                            else if (Case[i] > highquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;

                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.magenta;
                        }
                        else if (UIOptions.color == 1)
                        {
                            //color columns based on mean
                            if (Case[i] > mean)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;
                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.green;

                        }
                    }
                    else if (UIOptions.choice == 2)//Death Rate
                    {
                        child.transform.localScale = previousSize;//reset
                        child.transform.localPosition = new Vector3(child.transform.localPosition.x, previousPos.y, child.transform.localPosition.z);

                        //statistics
                        y = Statistics.normalizeValue(Statistics.FindMinValue(deathRate,dataList), Statistics.FindMaxValue(deathRate,dataList), Dec[i]);
                        addY = y * columnScale;
                        mean = Statistics.findMean(deathRate,dataList);
                        median = Statistics.findMedian(Dec);
                        lowquart = Statistics.findLowerQuartile(median, Dec);
                        highquart = Statistics.findHigherQuartile(median, Dec);

                        //how columns are located
                        child.transform.localPosition += new Vector3(0, addY / 2, 0);
                        child.transform.localScale += new Vector3(0, addY, 0);

                        //ChangeColor(lowquart, highquart, mean, Case);
                        if (UIOptions.color == 2)
                        { //ChangeColor(lowquart, highquart, mean, Case);

                            if (Dec[i] < lowquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.green;
                            }
                            else if (Dec[i] > highquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;

                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.magenta;
                        }
                        else if (UIOptions.color == 1)
                        {
                            //color columns based on mean
                            if (Dec[i] > mean)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;
                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.green;

                        }
                    }
                    else if (UIOptions.choice == 3)//Active Cases
                    {
                        child.transform.localScale = previousSize;//reset
                        child.transform.localPosition = new Vector3(child.transform.localPosition.x, previousPos.y, child.transform.localPosition.z);

                        y = Statistics.normalizeValue(Statistics.FindMinValue(activeCasesRate, dataList), Statistics.FindMaxValue(activeCasesRate, dataList), Dec[i]);
                        addY = y * columnScale;
                        mean = Statistics.findMean(activeCasesRate, dataList);

                        //how columns are located
                        child.transform.localPosition += new Vector3(0, addY / 2, 0);
                        child.transform.localScale += new Vector3(0, addY, 0);

                        //color columns based on mean
                        if (UIOptions.color == 2)
                        { //ChangeColor(lowquart, highquart, mean, Case);

                            if (Active[i] < lowquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.green;
                            }
                            else if (Active[i] > highquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;

                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.magenta;
                        }
                        else if (UIOptions.color == 1)
                        {
                            //color columns based on mean
                            if (Active[i] > mean)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;
                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.green;

                        }
                    }
                    else if (UIOptions.choice == 4)//Recovered
                    {
                        child.transform.localScale = previousSize;//reset
                        child.transform.localPosition = new Vector3(child.transform.localPosition.x, previousPos.y, child.transform.localPosition.z);

                        //statistics
                        y = Statistics.normalizeValue(Statistics.FindMinValue(recovered, dataList), Statistics.FindMaxValue(recovered, dataList), Dec[i]);
                        addY = y * columnScale;
                        mean = Statistics.findMean(recovered, dataList);

                        //how columns are located
                        child.transform.localPosition += new Vector3(0, addY / 2, 0);
                        child.transform.localScale += new Vector3(0, addY, 0);

                        //color columns based on mean
                        if (UIOptions.color == 2)
                        { //ChangeColor(lowquart, highquart, mean, Case);

                            if (Recovered[i] < lowquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.green;
                            }
                            else if (Recovered[i] > highquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;

                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.magenta;
                        }
                        else if (UIOptions.color == 1)
                        {
                            //color columns based on mean
                            if (Recovered[i] > mean)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;
                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.green;

                        }
                    }
                    else if (UIOptions.choice == 5)//Tested
                    {
                        child.transform.localScale = previousSize;//reset
                        child.transform.localPosition = new Vector3(child.transform.localPosition.x, previousPos.y, child.transform.localPosition.z);

                        //statistics
                        y = Statistics.normalizeValue(Statistics.FindMinValue(testRate, dataList), Statistics.FindMaxValue(testRate, dataList), Dec[i]);
                        addY = y * columnScale;
                        mean = Statistics.findMean(testRate, dataList);

                        //how columns are located
                        child.transform.localPosition += new Vector3(0, addY / 2, 0);
                        child.transform.localScale += new Vector3(0, addY, 0);

                        //color columns based on mean
                        if (UIOptions.color == 2)
                        { //ChangeColor(lowquart, highquart, mean, Case);

                            if (Test[i] < lowquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.green;
                            }
                            else if (Test[i] > highquart)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;

                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.magenta;
                        }
                        else if (UIOptions.color == 1)
                        {
                            //color columns based on mean
                            if (Test[i] > mean)
                            {
                                child.GetComponent<Renderer>().material.color = Color.red;
                            }
                            else
                                child.GetComponent<Renderer>().material.color = Color.green;

                        }
                    }
                   
                   
                }
            
            }

        }

    }

    private void ChangeColor(float lowquart,float highquart, float mean, List<int> column)
    {
        for (var i = 0; i < dataList.Count; i++)
        {
            foreach (Transform child in parent.transform)
                //color columns based on mean
                if (Input.GetKeyDown("9"))
                {
                    if (column[i] > mean)
                    {
                        child.GetComponent<Renderer>().material.color = Color.red;
                    }
                    else
                        child.GetComponent<Renderer>().material.color = Color.green;
                }
                else if (Input.GetKeyDown("8"))
                {
                    if (column[i] < lowquart)
                    {
                        child.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else if (column[i] > highquart)
                    {
                        child.GetComponent<Renderer>().material.color = Color.red;

                    }
                    else
                        child.GetComponent<Renderer>().material.color = Color.yellow;
                }
        }
    }

}



