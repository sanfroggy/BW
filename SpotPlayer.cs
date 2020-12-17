using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class SpotPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float spotRange;
    public float chaseRange;
    public float attackRange;
    public bool chasing = false;
    public bool returning = false;
    private Vector3 startPos;
    private GameObject player;
    private Animator selfAnim;
    private float ms;

    void Start()
    {
        startPos = gameObject.transform.position;
        player = GameObject.Find("WreckerBot 2.0 (1)");
        selfAnim = gameObject.GetComponent<Animator>();
        DataHandler DH = gameObject.GetComponent<DataHandler>();
        ms = DH.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= spotRange &&
            Vector3.Distance(player.transform.position, gameObject.transform.position) > attackRange &&
            Vector3.Distance(gameObject.transform.position, startPos) <= chaseRange &&
            returning == false) {
            chasing = true;
        }
        if (Vector3.Distance(gameObject.transform.position, startPos) > chaseRange)
        {
            chasing = false;
            returning = true;
        }
        if (chasing == true)
        {
            selfAnim.SetBool("Moving", true);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position,
                (ms * Time.deltaTime));
        } 
        if (returning == true) {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startPos, (ms * Time.deltaTime));
        }
        if (gameObject.transform.position == startPos)
        {
            returning = false;
        }
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= attackRange) {
            returning = false;
            chasing = false;
            selfAnim.SetBool("Moving", false);
            selfAnim.SetBool("Attacking", true);
        } else {
            selfAnim.SetBool("Attacking", false);
        }
    }
}
