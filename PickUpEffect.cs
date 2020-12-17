using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    private AudioSource EffectAS;
    // Start is called before the first frame update
    void Start() {
        EffectAS = GameObject.Find("EffectsManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "PlayerChar")
        {
            EffectAS.Play();
            gameObject.SetActive(false);
        }
    }
}