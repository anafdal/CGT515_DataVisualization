using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Vis1;
    public GameObject Vis2;

    public static string state;
    public GameObject inputField;
    public static int choice;
    

    public void Start()
    {
        choice = 0;
        Vis1.SetActive(true);
        Vis2.SetActive(false);
    }

    public void ChangeVis()
    {
        Vis1.SetActive(false);
        Vis2.SetActive(true);
    }

    public void ChangeBack()
    {
        Vis1.SetActive(true);
        Vis2.SetActive(false);
        choice = 0;
    }

    public void GetState()
    {
        state = inputField.GetComponent<Text>().text;
        Debug.Log(state);
    }

    public void PickChoice1()
    {
        choice = 1;
    }
    public void PickChoice2()
    {
        choice = 2;
    }
    public void PickChoice3()
    {
        choice = 3;
    }
    public void PickChoice4()
    {
        choice = 4;
    }

}
