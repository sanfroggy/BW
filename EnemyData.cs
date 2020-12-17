using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Enemy data", order = 2)]

public class EnemyData : ScriptableObject
{
    public int health;
    public int meleeDamage;
    public int rangedDamage;
    public int moveSpeed;
}
