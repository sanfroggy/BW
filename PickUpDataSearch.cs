using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDataSearch : MonoBehaviour
{
    public WeaponData WD;
    // Start is called before the first frame update
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerChar")
        {
            EquippedWeapon EW = col.gameObject.GetComponent<EquippedWeapon>();
            EW.equipped = WD;
            EW.Equip();
        }
    }
}
