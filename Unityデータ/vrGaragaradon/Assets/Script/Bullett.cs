using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullett : MonoBehaviour {　　//弾丸のScript

    Rigidbody Bullet;
    public float speed = 3000;
    public GameObject effect;
    

    //スピード3000の物を出現させる

    void Start()
    {
        Bullet = this.GetComponent<Rigidbody>();
        Bullet.AddForce(transform.forward * speed);
        Destroy(this.gameObject, 5f);//5秒後に弾丸消滅
    }

    

    void OnCollisionEnter()//オブジェクトに当たるとエフェクト出して弾丸消滅
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
