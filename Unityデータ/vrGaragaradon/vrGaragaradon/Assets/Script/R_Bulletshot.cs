using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Bulletshot : MonoBehaviour {//右手のチャージショット銃のスクリプト

    public Image UIobj;　　　　　　　　　　//--必殺ワザゲージの画像
    public float speed = 0.01f;　　　　　　//--必殺ワザゲージが貯まるスピード
    public GameObject DeathBrow;　　　　　 //--必殺技のオブジェクト
    public Transform muzzle;　　　　　　　 //--発射地点の位置
    public GameObject BulletPref;　　　　　//--チャージショットの弾のオブジェクト
    private AudioSource[] sources;　　　　 //--SE
    bool ChargeShot = false;　　　　　　　 //
    public float Charge = 0;

    void Start ()
    {
        sources = gameObject.GetComponents<AudioSource>();
    }

    void Update()
    {

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || Input.GetKey(KeyCode.Z))
        {
            float T1 = 0 +Time.deltaTime;
            Charge += T1;
            //BulletShot();

        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetKeyDown(KeyCode.Z))
        {
            sources[1].Play();
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) || Input.GetKeyUp(KeyCode.Z))
        {
            sources[1].Stop();

            if (Charge >= 0.5)
            {
                BulletShot();
                UIobj.fillAmount += speed;
                Charge = 0;
            }
        }

        /*
        if (Input.GetKey(KeyCode.M))
        {
            BulletShot();
            UIobj.fillAmount += speed;
        }*/

        /*
        else if (UIobj.fillAmount >= 1f && Input.GetKeyDown("x"))
        {


            GameObject bullets = Instantiate(DeathBrow) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * bulletspeed;

            bullets.GetComponent<Rigidbody>().AddForce(force);

            bullets.transform.position = muzzle.position;

            UIobj.fillAmount = 0;

        }*/
    }
    // OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)

    void BulletShot()
    {
        sources[0].Play();

        Instantiate(
            BulletPref,
            this.transform.position,
            this.transform.rotation
        //Quaternion.Euler(missleRot)
        );

       

    }
    /*
    public void gage()//デバッグ用
    {
        if (UIobj.fillAmount >= 1f && Input.GetKeyDown(KeyCode.X))
        {


            GameObject bullets = Instantiate(DeathBrow) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * bulletspeed;

            bullets.GetComponent<Rigidbody>().AddForce(force);

            bullets.transform.position = muzzle.position;

            UIobj.fillAmount = 0;
            //

        }
    }*/
}
