using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    private int dmg;
    private EnemyData ED;
    // Start is called before the first frame update
    void Start()
    {
        EquippedWeapon EW = GameObject.Find("WreckerBot 2.0").GetComponent<EquippedWeapon>();
        dmg = EW.equippedMelee.damage;
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<DataHandler>().hp -= dmg;
        }
    }
}
