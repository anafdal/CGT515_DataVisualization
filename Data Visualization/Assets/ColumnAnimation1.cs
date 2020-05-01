using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnAnimation1 : MonoBehaviour
{
    public string inputFile;
    public GameObject parent;

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> dataList;
    private List<string> columnList;
    private List<string> Area = new List<string>();//list of all the states and US territories
    private List<int> temporary = new List<int>();

    //column names
    private string geoArea;
    private string tempList;
    private int[] tempValue;
    

    //settings
    public float columnScale = 0.1f;
    public static bool value = true;
    float time = 0.0f;
    float timer=0.0f;

    void Start()
    {
        dataList = CSVReader.Read(inputFile);

      

        columnList = new List<string>(dataList[1].Keys);


        geoArea = columnList[0];//column
        tempValue = new int[dataList.Count];//temporary array
        //tempList = columnList[29];//test
      


        //Loop through dataList
        for (var i = 0; i < dataList.Count; i++)
        {
            
            Area.Add(System.Convert.ToString(dataList[i][geoArea]));

        }
    }


  void Update()
    {
        if (UIOptions.method == 1)//if user selects this animation
        {
            timer = Time.deltaTime;
            time += Time.deltaTime;
            //Debug.Log(time);
            

            if (value == true)
            {
                //put some kind of delay here
                for (var u = 1; u < columnList.Count; u++)
                {

                    tempList = columnList[u];
                    temporary = Add(tempList);

                    Debug.Log("List " + (u));


                }

                value = false;
            }


            if (time < 14.5+timer)//0.5seconds for 29 day
            {
                InvokeRepeating("ChangeColumn", 0.00001f, 0.5f);
                //Debug.Log(time);
            }
            else
            {
                CancelInvoke();
                //temporary.Clear();
            }
        }
        else
        {
            foreach (Transform child in parent.transform)
            {
                child.transform.localScale = new Vector3(child.localScale.x, 1, child.localScale.z);
                child.transform.localPosition = new Vector3(child.transform.localPosition.x, ColumnPlotter.previousPos.y, child.transform.localPosition.z);
            }
        }

    }

    public void ChangeColumn()//the animation part
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
                   
                    //Debug.Log("Y "+y);



                    //how columns are located
                    child.transform.localPosition += new Vector3(0, addY / 2, 0);
                    child.transform.localScale += new Vector3(0, addY, 0);
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
            

            tempValue[n]= System.Convert.ToInt32(dataList[n][tempList]);//add previous values
            temporary.Add(tempValue[n]);

             //temporary.Add(System.Convert.ToInt32(dataList[n][tempList]));
             //Debug.Log(n);
             Debug.Log(Area[n]+" "+tempValue[n]);

        }

       // Debug.Log(temporary.Count);
        return temporary;


    }

}

