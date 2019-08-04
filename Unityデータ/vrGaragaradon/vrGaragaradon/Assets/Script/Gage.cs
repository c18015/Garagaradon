using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    public Image UIobj;

    public float speed = 0.05f;

    public float bulletspeed = 0.05f;

    public GameObject DeathBrow;

    public Transform muzzle;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            UIobj.fillAmount += speed;
        }
    }

    public void gage()
    {
       if (UIobj.fillAmount >= 1f && Input.GetKeyDown("z"))
        {
            GameObject bullets = Instantiate(DeathBrow) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * bulletspeed;

            bullets.GetComponent<Rigidbody>().AddForce(force);

            bullets.transform.position = muzzle.position;

            UIobj.fillAmount = 0;
           
        }
    }
    }