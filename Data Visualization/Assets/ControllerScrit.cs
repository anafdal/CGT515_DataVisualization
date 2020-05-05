using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScrit : MonoBehaviour
{
    private Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.T))
        {
            myAnimator.SetBool("Normal", true);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            myAnimator.SetBool("Normal", false);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            myAnimator.SetBool("Scream", true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            myAnimator.SetBool("Scream", false);
        }
    }
}
