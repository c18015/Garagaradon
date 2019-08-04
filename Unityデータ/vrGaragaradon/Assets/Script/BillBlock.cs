using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBlock : MonoBehaviour {  //ビルのHPを管理していたScript、今はもう使ってない、再利用検討中

    public float BillHP = 10f;
    public BlockBreak BB;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (BillHP == 0)
        {
            //BB.AddBillDes();
        }
    }

    public void AddBillDame(float Damage)
    {
        BillHP -= Damage;

        if (BillHP >= 0)
        {
            //BB.AddBillDes();
            Debug.Log("hit");
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            BillHP -= 1f;
        }
    }*/
    /*void Billinsta(){
        Instantiate(BillPref, new Vector3(-1f, 0f, 14f), Quaternion.identity);
        Destroy(this.gameObject);
    }*/
}
