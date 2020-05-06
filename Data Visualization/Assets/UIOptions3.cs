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
    

    public void Start()
    {

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
    }

    public void GetState()
    {
        state = inputField.GetComponent<Text>().text;
        Debug.Log(state);
    }
}
