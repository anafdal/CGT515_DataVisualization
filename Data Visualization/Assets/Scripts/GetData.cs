﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{

    public static string data;

   void Start()
    {
        data = "Welcome!";
        
    }
    private void OnMouseDown()
    {

        //Debug.Log(this.name);
     

         data = this.name;
        
      
    }



}