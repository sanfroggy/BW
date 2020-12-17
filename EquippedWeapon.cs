using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weaponObjects;
    public WeaponData equipped;
    int i;
    // Update is called once per frame
    public void Equip() {
        for (i=0; i < weaponObjects.Length; i++)
        {
            weaponObjects[i].SetActive(false);
        }
        weaponObjects[equipped.WeaponArrayIndex].SetActive(true);
    }
}
