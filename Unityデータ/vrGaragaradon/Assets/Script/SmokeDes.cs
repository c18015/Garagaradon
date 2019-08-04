using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDes : MonoBehaviour {

    public float EffectdesTime = 25f;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, EffectdesTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
