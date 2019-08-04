using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathBrows : MonoBehaviour
{
    GameObject UIobj;

    L_Bulletshot script;

    //public GameObject DeathBrow;

    //public Transform muzzle;

    //public float speed = 1000;
    
    void Start()
    {
        UIobj = GameObject.Find("Gage");
        script = UIobj.GetComponent<L_Bulletshot>();
    }

    void Update()
    {
       // script.Gage();
    }
}

