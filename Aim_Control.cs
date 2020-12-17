using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Aim_Control : MonoBehaviour
{
    //private GameObject body;
    private Vector3 mouseCoords;
    private Vector3 newDir;
    private Camera PPC;
    public float speed;
    private float step;
    // Start is called before the first frame update
    void Start()
    {
        step = Time.deltaTime * speed;
        //body = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        PPC = GameObject.Find("Player_Perspective_Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseCoords = PPC.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        //float angle = AngleBetweenPoints(transform.position, mouseCoords);
        //newDir = Vector3.RotateTowards(gameObject.transform.forward, new Vector3(mouseCoords.x, gameObject.transform.rotation.y, mouseCoords.z), step, 0.0f);
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(gameObject.transform.eulerAngles, new Vector3(mouseCoords.x, gameObject.transform.rotation.y, mouseCoords.z), step, 0.0f));
    }

    /*float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }*/
}
