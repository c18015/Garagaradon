using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour　　//--ビルのブロック一つ一つに貼るScript、壊したときの破片やらなんやら処理
{
    float BS = 2f;　　　　　　　　　　　//--ブロックのサイズの数値-これが大きいほどよく飛ぶ、いや飛びすぎる。
    float BlockHP = 1;　　　　　　　　　//--ブロックのHP

    public GameCon gameCon;　　　　　　 //--GameConスクリプトを取得
    public int PlasScore = 100;　　　　 //--１ブロック壊したときのスコアの数値

    private AudioSource[] sources;　　　//--SE
    public GameObject Effect;           //--爆破エフェクトを入れる箱
    bool Damage = false;　　　　　　　　//--スコアを一度だけ送るために使った関数

    Rigidbody body;　　　　　　　　　　 
    BoxCollider Boxcoll;　　　　　　　　
    Material mat;　　　　　　　　　　　 


    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;　　//--色を変えられるようになる、ダメージを受けると色を変えるため
        body = this.GetComponent<Rigidbody>();
        body.isKinematic = true; 　　　　　　　　　　　　//--Trueでブロックを固定
        Boxcoll = GetComponent<BoxCollider>();


        //

    }

    // Update is called once per frame
    void Update()
    {
        //--ブロックの最大HPを0.6にした。
        if(BlockHP <= 0.6)
        {
            BlockHP = 0.6f;
        }
             


        //--ブロックのHPが最大数を超えると壊れる処理を実行する
        if (BlockHP <= 0.7)
        {
            body.isKinematic = false;　//--ブロックの固定が外れて物理演算できる
            Invoke("sizedown", 0.5f);　//--0.5秒後にブロックのサイズを戻す関数を呼ぶ

            //--壊れた破片がY座標３m内に７秒間いると破片を消す関数を実行
            if (this.transform.position.y < 3f)
            {
                Invoke("BlockDes", 7f);
            }
        }

        /*if (this.transform.position.y > 60f)//--高く飛びすぎた破片を消滅させる
        {
            Destroy(this.gameObject);
            //Debug.Log("到達");
        }*/

    }

    /*public void AddBillDes()//ビルの全ブロックをすべて壊す
    {       
    　　BillAllDes();
    }*/

    //--弾に当たったときのHPの処理
    void OnTriggerEnter(Collider collider) //OnCollisionEnter(Collision collision)
    {
        if (collider.gameObject.tag == "Bullet")//--マシンガンの弾に当たったとき
        {
            BlockHP -= 0.1f;
            ONcoli();
        }
        if(collider.gameObject.tag == "BIMU")//--必殺ワザに当たったとき、一撃必殺である。
        {
            BlockHP -= 1f;
            ONcoli();
        }

        if(collider.gameObject.tag == "Razer")//--チャージショットの弾にあたったとき
        {
            BlockHP -= 0.3f;
            ONcoli();
        }
    }

    //--ブロックのコリジョン(壊れた時の処理)の関数
    void ONcoli()
    {

        float n = Random.Range(1, 30);//--弾が当たると１/３０の確率で煙が上がるエフェクトを出す
        if (n == 25)
        {
            Instantiate(Effect, this.transform.position, Quaternion.identity);
        }
        //Debug.Log("Critical Hit");

        
        if (BlockHP <= 0.6)//--ブロックのHPがゼロになったとき
        {
            //--ブロックのコリジョンのサイズを変え物理演算で飛ばす
            Boxcoll.size = new Vector3(BS, BS, BS);

            if (!Damage)//--壊れたときに一度だけスコアを送る
            {
                Damage = true;
                gameCon.PlasScore(PlasScore);
            }
        }
        //--ダメージを受けるとブロックの色が赤くなっていく
        mat.color = new Color(1, BlockHP, BlockHP, 1f);
    }

    //--ビルの全ブロックをすべて壊す、結局使わなかったやつ
    /*void BillAllDes()
    {
        body.isKinematic = false;
        Boxcoll.size = new Vector3(3, 3, 3);
        Invoke("sizedown", 0.5f);
        Invoke("BlockDes", 5f);

        float n = Random.Range(1, 30);
        if(n == 25)
        {
            Instantiate(Effect, transform.position, Quaternion.identity);
        }

    }*/


    //--旧ブロックが壊れた時の処理
    /*void BlockDes()
    {
        body.isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        this.transform.position += Vector3.down * 0.5f * Time.deltaTime;

        if (this.transform.position.y < -2.0f)
        {
            Destroy(this.gameObject);
        }

    }*/

        //Destroy(this.gameObject, 7f);
        //Debug.Log("iiyo");


    void sizedown()//--ブロックのサイズをもとに戻す
    {

        Boxcoll.size = new Vector3(1, 1, 1);
    }
}

