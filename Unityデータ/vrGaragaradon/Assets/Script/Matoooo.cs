using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matoooo : MonoBehaviour {

    public GameObject EndText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        EndText.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EndText.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
