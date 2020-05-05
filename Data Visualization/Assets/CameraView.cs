using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    Vector2 mouseLook;//keep track of camera movement
    Vector2 smoothV;//smooths down movement of mouse

    public float sensitivity = 10.0f;//mouse sensitivity
    public float smoothing = 2.0f;//how much smoothing you want

    GameObject character;//the main player;cntrol whole bosy of character

   void Start()
    {
        character = this.transform.parent.gameObject;//set character; camera's parent 
    }


    // Update is called once per frame
    void Update()
    {

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));//get axis for the mouse as they come in; mouse delta

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x =  Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);//smooths movement; linear movement
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);//lerp used a lot for smoothing

        mouseLook += smoothV;//add up movements

        transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(-mouseLook.y, -90.0f, 50.0f), Vector3.right);//rotates around y axis and rotates around x axis
        //the minus is for inverted systems
        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);//change in mouse in x; rotate around character up
        //character.transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(mouseLook.x, -70.0f, 70.0f), character.transform.up);


    }

     
}

