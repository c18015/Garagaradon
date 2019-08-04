using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCon : MonoBehaviour {　　//名前の通り　スコアとかの管理させる予定


    

    public Text LT_Text;//LimitTimeのテキスト
    public Text SC_Text;

    public GameObject EndText;
    public float LimitTime = 300f;

    public int Score = 0;
    bool SetTime = false;



    // Use this for initialization
    void Start () {
        EndText.SetActive(false);


    }



    // Update is called once per frame
    void Update()
    {
        

        float T1 = 0 + Time.deltaTime;
        LimitTime -= T1;
        

        

        LT_Text.text = "残り " + LimitTime.ToString("F0") + "秒";
        SC_Text.text = "スコア:" + Score;

        

        if (LimitTime <= 0)
        {
            
            EndText.SetActive(true);
            LimitTime += 0 + Time.deltaTime;
            
            PlayerPrefs.SetInt("NowScore",Score);

            if (PlayerPrefs.GetInt("HighScore") < Score)
            {
                PlayerPrefs.SetInt("HighScore",Score);
            }

            Invoke("GoToScore", 1.0f);

        }
    }

    void GoToScore()
    {
        SceneManager.LoadScene("End_Scenes");

    }

    public void PlasScore(int PSC)
    {
        Score += PSC;
    }



}
