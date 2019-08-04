using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCon : MonoBehaviour {

    public Text Now;
    public Text High;

    // Use this for initialization
    void Start ()
    {
		Now.text = "あなたのスコア:" + PlayerPrefs.GetInt("NowScore") ;
        High.text = "過去最高スコア" + PlayerPrefs.GetInt("HighScore") ;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

    }
}
