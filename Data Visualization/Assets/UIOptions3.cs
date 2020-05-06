using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Vis1;
    public GameObject Vis2;

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
}
