using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Sockets;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    private bool hitsWall = false;
    private GameObject tips;
    public string moveDirWhenHitting;
    public string moveDir = "";
    private Animator pAni;
    private GameObject legs;
    private Rigidbody RB;
    public float speed = 0;

    void Start() {
        pAni = gameObject.GetComponent<Animator>();
        legs = gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        RB = gameObject.GetComponent<Rigidbody>();
        tips = GameObject.Find("TipText");
    }

    void Update()
    {
        if (!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d") || tips.activeInHierarchy == true)
        {
            moveDir = "";
            pAni.SetBool("Moving", false);
            pAni.SetBool("Idle", true);
            RB.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            if (!Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d") && !pAni.GetBool("Hitting") && tips.activeInHierarchy == false)
            {
                moveDir = "Forwards";
                pAni.SetBool("Moving", true);
                pAni.SetBool("Idle", false);
                if (hitsWall == true && moveDir == moveDirWhenHitting) {
                    RB.velocity = new Vector3(0, 0, 0);
                } else {
                    RB.velocity = new Vector3(-speed, 0, 0);
                }
            }
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (!Input.GetKey("s") && !Input.GetKey("w") && !Input.GetKey("d") && !pAni.GetBool("Hitting") && tips.activeInHierarchy == false)
            {
                moveDir = "Left";
                pAni.SetBool("Moving", true);
                pAni.SetBool("Idle", false);
                if (hitsWall == true && moveDir == moveDirWhenHitting) {
                    RB.velocity = new Vector3(0, 0, 0);
                } else {
                    RB.velocity = new Vector3(0, 0, -speed);
                }
            }
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d") && !pAni.GetBool("Hitting") && tips.activeInHierarchy == false) 
            {
                moveDir = "Backwards";
                pAni.SetBool("Moving", true);
                pAni.SetBool("Idle", false);
                if (hitsWall == true && moveDir == moveDirWhenHitting) {
                    RB.velocity = new Vector3(0, 0, 0);
                } else {
                    RB.velocity = new Vector3(speed, 0, 0);
                }
            }
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (!Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("w") && !pAni.GetBool("Hitting") && tips.activeInHierarchy == false)
            {
                moveDir = "Right";
                pAni.SetBool("Moving", true);
                pAni.SetBool("Idle", false);
                if (hitsWall == true && moveDir == moveDirWhenHitting) {
                    RB.velocity = new Vector3(0, 0, 0);
                } else {
                    RB.velocity = new Vector3(0, 0, speed);
                }
            }
        } 
    }
            // Update is called once per frame
    void LateUpdate() {
        //if (Input.GetKeyDown("w") || Input.GetKey("up")) {
        //if (Input.GetKey("s") && Input.GetKey("d") && Input.GetKey("a")) {
        if (moveDir == "Forwards")
        {
            legs.transform.Rotate(new Vector3(-0.675f, 0f, 4.518f), Space.Self);
        }
        if (moveDir == "Left")
        {
            legs.transform.Rotate(new Vector3(-11.886f, 90f, -6.863f), Space.Self);
        }
        if (moveDir == "Backwards")
        {
            legs.transform.Rotate(new Vector3(-0.557f, 180f, -17.942f), Space.Self);
        } 
        if (moveDir == "Right") { 
            legs.transform.Rotate(new Vector3(10.568f, 270f, -6.629f), Space.Self);
        } 
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Unpassable" || col.gameObject.tag == "Enemy") {
            moveDirWhenHitting = moveDir;
            hitsWall = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Unpassable" || col.gameObject.tag == "Enemy") {
            hitsWall = false;
        }
    }
}
