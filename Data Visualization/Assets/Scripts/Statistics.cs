using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    //find maximum value from list
    public static int FindMaxValue(string columnName, List<Dictionary<string, object>> dataList)
    {
        //set initial value to first value
        int maxValue = System.Convert.ToInt32(dataList[0][columnName]);

        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < dataList.Count - 1; i++)//I dont want last columnt to be counted
        {
            if (maxValue < System.Convert.ToInt32(dataList[i][columnName]))
                maxValue = System.Convert.ToInt32(dataList[i][columnName]);
        }


        //Debug.Log("Max: "+maxValue);
        return maxValue;

    }

    
    //find minimum value from list
    public static int FindMinValue(string columnName, List<Dictionary<string, object>> dataList)
    {

        int minValue = System.Convert.ToInt32(dataList[0][columnName]);

        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < dataList.Count - 1; i++)//I dont want last columnt to be counted
        {
            if (System.Convert.ToInt32(dataList[i][columnName]) < minValue)
                minValue = System.Convert.ToInt32(dataList[i][columnName]);
        }
        //Debug.Log("Min: "+minValue);
        return minValue;
    }

    //normalize value
    public static float normalizeValue(int minValue, int maxValue, int actualValue)
    {
        float normalValue = ((float)actualValue - minValue) / (maxValue - minValue);

        //Debug.Log("Actual: "+normalValue);
        return normalValue;
    }


    //find mean
    public static float findMean(string columnName, List<Dictionary<string, object>> dataList )
    {

        int totalValue = 0;

        for (var i = 0; i < dataList.Count - 1; i++)//I dont want last columnt to be counted
        {
            int value = System.Convert.ToInt32(dataList[i][columnName]);
            totalValue += value;
        }

        float mean = (float)totalValue / (dataList.Count - 1);

        //Debug.Log("Mean "+mean);
        return mean;

    }

    //find median
    public static float findMedian(List<int> dataList)//need to sort list first
    {
        float median = 0;
        int value1 = 0;
        int value2 = 0;
        List<int> temporary = new List<int>();

        for (var i = 0; i < dataList.Count-1; i++)
        {

            temporary.Add(dataList[i]);
        }

            //Debug.Log(temporary.Count);//55
            temporary.Sort();

        if ((temporary.Count) % 2 == 0)//if value is even
        {
            int place1 = (temporary.Count) / 2;
            int place2 = ((temporary.Count) + 2) / 2;

            for (var i = 0; i < temporary.Count; i++)//I dont want last columnt to be counted
            {
                if (place1-1 == i)
                {
                    value1 =temporary[i];
                }
                else if (place2-1 == i)
                {
                    value2 =temporary[i];
                }
            }

            median = ((float)(value1 + value2)) / 2;

        }
        else//if value is odd
        {
            int place = ((temporary.Count) + 1) / 2;

            for (var i = 0; i < temporary.Count; i++)//I dont want last columnt to be counted
            {
                if (place-1 == i)
                {
                    median = temporary[i];
                }

            }


        }

        //Debug.Log("Median " + median);
        return median;

    }

   
    //find 25% quantile
   public static float findLowerQuartile(float Median, List<int> dataList)//find lower quartile
      {
          float lowerQuart = 0;
          int value1 = 0;
          int value2 = 0;
          List<int> lowerNum = new List<int>();
          List<int> temporary = new List<int>();

        for (var i = 0; i < dataList.Count - 1; i++)
        {

            temporary.Add(dataList[i]);
        }
        temporary.Sort();

        //find range
        for (var i = 0; i < temporary.Count; i++)
          { 
              if (Median >= temporary[i])
              {
                  lowerNum.Add(temporary[i]);
              }

          }

        //Debug.Log(lowerNum.Count);//28

          //find lower quartile
          if ((lowerNum.Count) % 2 == 0)//if value is even
          {
              int place1 = (lowerNum.Count) / 2;
              int place2 = ((lowerNum.Count) + 2) / 2;

              for (var j = 0; j < lowerNum.Count; j++)
              {
                  if (place1-1 == j)
                  {
                      value1 = lowerNum[j];
                  }
                  else if (place2-1 == j)
                  {
                      value2 = lowerNum[j];
                  }
              }

              lowerQuart = ((float)(value1 + value2)) / 2;

          }
          else//if value is odd
          {
              int place = ((lowerNum.Count) + 1) / 2;

              for (var j = 0; j < lowerNum.Count; j++)
              {
                  if (place-1 == j)
                  {
                      lowerQuart = lowerNum[j];
                  }

              }


          }

          //Debug.Log("First Quartile " + lowerQuart);
          return lowerQuart;

      }


    //find 75% quantile
    public static float findHigherQuartile(float Median, List<int> dataList)//find lower quartile
    {
        float higherQuart = 0;
        int value1 = 0;
        int value2 = 0;
        List<int> higherNum = new List<int>();
        List<int> temporary = new List<int>();

        for (var i = 0; i < dataList.Count - 1; i++)
        {

            temporary.Add(dataList[i]);
        }
        temporary.Sort();

        //find range
        for (var i = 0; i < temporary.Count; i++)
        {
            if (Median <= temporary[i])
            {
                higherNum.Add(temporary[i]);
            }

        }

        //Debug.Log(higherNum.Count);//28

        //find lower quartile
        if ((higherNum.Count) % 2 == 0)//if value is even
        {
            int place1 = (higherNum.Count) / 2;
            int place2 = ((higherNum.Count) + 2) / 2;

            for (var j = 0; j < higherNum.Count; j++)
            {
                if (place1 - 1 == j)
                {
                    value1 = higherNum[j];
                }
                else if (place2 - 1 == j)
                {
                    value2 = higherNum[j];
                }
            }

            higherQuart = ((float)(value1 + value2)) / 2;

        }
        else//if value is odd
        {
            int place = ((higherNum.Count) + 1) / 2;

            for (var j = 0; j < higherNum.Count; j++)
            {
                if (place - 1 == j)
                {
                    higherQuart = higherNum[j];
                }

            }


        }

        //Debug.Log("Third Quartile " + higherQuart);
        return higherQuart;

    }



}
