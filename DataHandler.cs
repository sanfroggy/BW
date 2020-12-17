using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public EnemyData data;
    public int hp;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        hp = data.health;
        speed = data.moveSpeed;
    }
}
