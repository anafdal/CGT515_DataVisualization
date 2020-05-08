using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{

    public static string data;

   void Start()
    {
        data = "Click For Data";
        
    }
    private void OnMouseDown()
    {

        //Debug.Log(this.name);
     

         data = this.name;
            
    }
    private void OnMouseUp()
    {

        //Debug.Log(this.name);


        data = "Click For Data";

    }


}
