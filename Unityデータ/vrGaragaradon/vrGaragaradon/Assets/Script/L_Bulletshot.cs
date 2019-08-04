using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Bulletshot : MonoBehaviour　　　//--左手の連射銃(マシンガン)のスクリプト
{

    public Image UIobj;　　　　　　　　　　//--必殺ワザゲージの画像
    public float speed = 0.05f;　　　　　　//--必殺ワザゲージが貯まるスピード
    //public float bulletspeed = 0.05f;　　 //--必殺技の速さ--(使わなくなった) 
    public GameObject DeathBrow;　　　　　 //--必殺技のオブジェクト
    public Transform muzzle;　　　　　　　 //--発射地点の位置
    public GameObject BulletPref;　　　　  //--チャージショットの弾のオブジェクト
    private AudioSource[] sources;　　　　 //--SE

    void Start()
    {　　
        sources = gameObject.GetComponents<AudioSource>();  
    }

    void Update()
    {
        //--左のトリガー、キーボードのX(PCデバッグ用)を押している間、弾を発射
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || Input.GetKey(KeyCode.X))
        {
            //Debug.Log("左人差し指トリガーを押した");
            BulletShot();
            UIobj.fillAmount += speed;
        }

        //--トリガーを押したら音をループ再生(音の被り防止で連射音をループ再生)
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) || Input.GetKeyDown(KeyCode.X))
        {
            sources[0].Play();
        }

        //--トリガーを上げると音を止める
        if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) || Input.GetKeyUp(KeyCode.X))
        {
            sources[0].Stop();
        }

        //--必殺ワザゲージが貯まると音でお知らせする
        if (UIobj.fillAmount >= 1f)
        {
            sources[1].Play();
        }

        //--必殺ゲージが最大まで貯まってる+両手のトリガーを引くと必殺ワザを出す
        if (UIobj.fillAmount >= 1f && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || UIobj.fillAmount >= 1f && Input.GetKey(KeyCode.S))
        {
            Instantiate(
            DeathBrow,
            this.transform.position,
            this.transform.rotation);

            //--必殺ワザゲージを0にする
            UIobj.fillAmount = 0;

        }        
    }
    void BulletShot()//--弾を出す処理
    {

        Instantiate(
            BulletPref,
            this.transform.position,
            this.transform.rotation
        //Quaternion.Euler(missleRot)
        );
    }
    /*
    public void gage()
    {
        if (UIobj.fillAmount >= 1f && Input.GetKeyDown("x"))
        {
            GameObject bullets = Instantiate(DeathBrow) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * bulletspeed;

            bullets.GetComponent<Rigidbody>().AddForce(force);

            bullets.transform.position = muzzle.position;

            UIobj.fillAmount = 0;

        }
      }*/
}

