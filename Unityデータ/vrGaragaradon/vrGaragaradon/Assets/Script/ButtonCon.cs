using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCon : MonoBehaviour {  //シーン移動に関するScript

    private AudioSource[] sources;
    public float Number = 0f;
    
    void Start () {
        sources = gameObject.GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            if(Number == 1)
            {
                Invoke("GoMain", 1f);
            }
            
            if(Number == 2)
            {
                Invoke("GoTyuto", 1f);
            }

            if(Number == 3)
            {
                Invoke("GoTitel", 1f);
            }
            sources[0].Play();
            
        }
    }

    void GoMain()
    {
        SceneManager.LoadScene("Main_Scenes");
    }
    void GoTyuto()
    {
        SceneManager.LoadScene("tutorial_Scene");
    }
    void GoTitel()
    {
        SceneManager.LoadScene("Title_Scenes");
    }
}
