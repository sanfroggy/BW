using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Sockets;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public string MoveDir = "";
    private Animator pAni;
    private GameObject legs;
    private Rigidbody RB;
    public float speed = 0;

    void Start() {
        pAni = gameObject.GetComponent<Animator>();
        legs = gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        RB = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            MoveDir = "";
            pAni.SetBool("Moving", false);
            RB.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            if (!Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
            {
                MoveDir = "Forwards";
                pAni.SetBool("Moving", true);
                RB.velocity = new Vector3(-speed, 0, 0);
            }
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (!Input.GetKey("s") && !Input.GetKey("w") && !Input.GetKey("d"))
            {
                MoveDir = "Left";
                pAni.SetBool("Moving", true);
                RB.velocity = new Vector3(0, 0, -speed);
            }
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d")) 
            {
                MoveDir = "Backwards";
                pAni.SetBool("Moving", true);
                RB.velocity = new Vector3(speed, 0, 0);
            }
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (!Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("w"))
            {
                MoveDir = "Right";
                pAni.SetBool("Moving", true);
                RB.velocity = new Vector3(0, 0, speed);
            }
        } 
    }
            // Update is called once per frame
    void LateUpdate() {
        //if (Input.GetKeyDown("w") || Input.GetKey("up")) {
        //if (Input.GetKey("s") && Input.GetKey("d") && Input.GetKey("a")) {
        if (MoveDir == "Forwards")
        {
            legs.transform.Rotate(new Vector3((float)-0.675, 0, (float)4.518), Space.Self);
        }
        if (MoveDir == "Left")
        {
            legs.transform.Rotate(new Vector3((float)-11.886, 90, (float)-6.863), Space.Self);
        }
        if (MoveDir == "Backwards")
        {
            legs.transform.Rotate(new Vector3((float)-0.557, 180, (float)-17.942), Space.Self);
        } 
        if (MoveDir == "Right") { 
            legs.transform.Rotate(new Vector3((float)10.568, 270, (float)-6.629), Space.Self);
        } 
    }
}
