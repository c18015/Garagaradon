using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    float BS = 2f;
    float CarHP = 10;

    public GameCon gameCon;
    public float SpecialSco = 1000f;

    private AudioSource[] sources;
    bool Damage = false;

    Rigidbody body;
    BoxCollider Boxcoll;
    


    // Start is called before the first frame update
    void Start()
    {
        
        body = this.GetComponent<Rigidbody>();
        body.isKinematic = true; //Trueでブロックを固定
        

        //

    }

    // Update is called once per frame
    void Update()
    {



        if (CarHP <= 1)
        {
            body.isKinematic = false;
            Invoke("sizedown", 0.5f);

            if (this.transform.position.y < 3f)
            {
                Invoke("BlockDes", 7f);
            }
        }

        /*if (this.transform.position.y > 60f)
        {
            Destroy(this.gameObject);
            //Debug.Log("到達");
        }*/

    }

    /*public void AddBillDes()
    {
        BillAllDes();
    }*/

    void OnTriggerEnter(Collider collider) //OnCollisionEnter(Collision collision)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            
            float n = Random.Range(1, 30);
            //Debug.Log("Critical Hit");



            CarHP -= 1;
            if (CarHP <= 1)
            {
                Boxcoll.size = new Vector3(BS, BS, BS);

                if (!Damage)
                {
                    Damage = true;
                    //gameCon.PlasScore(SpecialSco);
                }
            }

            
        }
    }

    void BillAllDes()
    {
        body.isKinematic = false;
        Boxcoll.size = new Vector3(3, 3, 3);
        Invoke("sizedown", 0.5f);
        Invoke("BlockDes", 5f);


    }


    void BlockDes()
    {
        body.isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        this.transform.position += Vector3.down * 0.5f * Time.deltaTime;

        if (this.transform.position.y < -2.0f)
        {
            Destroy(this.gameObject);
        }

    }

    //Destroy(this.gameObject, 7f);
    //Debug.Log("iiyo");


    void sizedown()
    {
        Boxcoll.size = new Vector3(1, 1, 1);
    }
}
