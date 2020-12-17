using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] rangedWeapons;
    public GameObject[] meleeWeapons;
    public WeaponData pickUp;
    public WeaponData equippedRanged;
    public WeaponData equippedMelee;
    int i;
    // Update is called once per frame
    public void Equip() {
        if (pickUp.type == "Ranged")
        {
            for (i = 0; i < rangedWeapons.Length; i++)
            {
                rangedWeapons[i].SetActive(false);
                rangedWeapons[equippedRanged.WeaponArrayIndex].SetActive(true);
            }
        }
        if (pickUp.type == "Melee")
        {
            for (i = 0; i < meleeWeapons.Length; i++)
            {
                meleeWeapons[i].SetActive(false);
                meleeWeapons[equippedMelee.WeaponArrayIndex].SetActive(true);
            }
        }
    }
}
