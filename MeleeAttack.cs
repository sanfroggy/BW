using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator pAnim;

    void Start()
    {
        pAnim = GameObject.Find("WreckerBot 2.0 (1)").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && pAnim.GetBool("Idle"))
        {
            pAnim.SetBool("Hitting", true);
            pAnim.SetBool("Idle", false);
        } else {
            pAnim.SetBool("Hitting", false);
        }
    }

    public void Reset()
    {
        pAnim.SetBool("Hitting", false);
        pAnim.SetBool("Idle", true);
    }
}
