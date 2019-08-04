using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDes : MonoBehaviour {　//エフェクトを消す
    
    private AudioSource[] sources;
    public float EffectdesTime = 2f;

    
    void Start () {
        Destroy(this.gameObject, EffectdesTime);
        sources = gameObject.GetComponents<AudioSource>();

        
        float n = Random.Range(1, 3);
        if(n == 1)
        {
            sources[0].Play();
        }
        else
        {
            sources[1].Play();
        }
    }
	
	// Update is called once per frame
	void Update () {

        
    }
}
