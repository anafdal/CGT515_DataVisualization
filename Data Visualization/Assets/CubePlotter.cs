using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlotter : MonoBehaviour
{

    public GameObject cube;
    public GameObject PointHolder;
    private GameObject[,] CubeArray = new GameObject[10, 10];
    public int scale = 200;


    public string inputFile;
   

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> dataList;
    private List<string> columnList;

    private List<string> Area = new List<string>();//list of all the states and US territories
    private List<int> Case = new List<int>();//list of all the total cases
    private List<int> Dec = new List<int>();//list of all the death cases
    private List<int> Population = new List<int>();//list of total population per area
    private List<int> Active = new List<int>();//list of active cases currently
    private List<int> Test = new List<int>();//list of testing done
    private List<int> Recovered = new List<int>();//list of people recovered from the virus

    //column names
    private string geoArea;
    private string caseRate;
    private string deathRate;
    private string activeCasesRate;
    private string recovered;
    private string testRate;
    private string population;


    private int colorLimit;


    void Start()
    {
        //create grid of cubes
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y <10; y++)
            {
              
                 
                    CubeArray[x, y] = (GameObject)Instantiate(cube, new Vector3((x*scale) +cube.transform.position.x, (y*scale) + cube.transform.position.y, cube.transform.position.z), transform.rotation);

                    CubeArray[x, y].transform.parent = PointHolder.transform;//become children of Pointholder
               
            }
        }

        //read file
        dataList = CSVReader.Read(inputFile);
        columnList = new List<string>(dataList[1].Keys);

        geoArea = columnList[0];//column
        population = columnList[1];
        caseRate = columnList[2];//column
        deathRate = columnList[3];//column
        activeCasesRate = columnList[4];
        recovered = columnList[5];
        testRate = columnList[6];
      

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

    void Update()
    {
   


        for (var j = 0; j < dataList.Count - 1; j++)
        {
           

              if (Area[j]==UIOptions3.state)
              { 
                Debug.Log(Case[j] + " " + Population[j]);


                if (UIOptions3.choice==1)///cases per population per state
                {
                    float temporary = ((float)Case[j] / (float)Population[j]) * 100;
                    colorLimit = (int)temporary;

                    ColorGrid(colorLimit);

                   // Debug.Log("Case is " + colorLimit);
                }
                else if (UIOptions3.choice == 2)//deaths in all the cases per state
                {

                    float temporary = ((float)Dec[j] / (float)Case[j]) * 100;
                    colorLimit = (int)temporary;


                   // Debug.Log("Death is " + colorLimit);
                    

                    ColorGrid(colorLimit);

                }
                else if (UIOptions3.choice == 3)//continuing cases (not recovered) in all the cases per state
                {

                    float temporary = ((float)Active[j] / (float)Case[j]) * 100;
                    colorLimit = (int)temporary;

                   // Debug.Log("Active is " + colorLimit);

                    ColorGrid(colorLimit);
                }
                else if (UIOptions3.choice == 4)//recovered cases from allc cases in state
                {

                    float temporary = ((float)Recovered[j] / (float)Case[j]) * 100;
                    colorLimit = (int)temporary;

                    //Debug.Log("Recovered is " + colorLimit);

                    ColorGrid(colorLimit);
                }
                else if (UIOptions3.choice == 5)//tested cases
                {

                    float temporary = ((float)Test[j] / (float)Population[j]) * 100;
                    colorLimit = (int)temporary;

                    //Debug.Log("Recovered is " + colorLimit);

                    ColorGrid(colorLimit);
                }


            }

        }


    }


    public void ColorGrid(int color)
    {
        int i = 0;

        foreach (Transform cube in PointHolder.transform)
        {

                if (i <= color && color!=0)
                {
                    cube.GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    cube.GetComponent<Renderer>().material.color = Color.green;
                }

                i++;
       
        }
    }

}
