using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Weapon data", order = 1)]

public class WeaponData : ScriptableObject
{
    public string type;
    public string name;
    public string carriedAmmo;
    public float damage;
    public float fireRate;
    public float reloadTime;
    public int WeaponArrayIndex;
    public int ammoInAClip;
    public int maxAmmo;
    public int range;
    public int defaultAmountOfAmmo;
}
