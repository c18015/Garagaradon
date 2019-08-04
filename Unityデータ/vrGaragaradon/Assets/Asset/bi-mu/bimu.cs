using UnityEngine;
using System.Collections;

public class bimu : MonoBehaviour
{

    // bullet prefab
    private Animator anim;
    public AudioClip punchSound;
    public AudioClip punchSound2;

    private void Start()
    {
        GetComponent<Animator>().SetTrigger("C");
        AudioSource.PlayClipAtPoint(punchSound, Camera.main.transform.position);
        Invoke("ka", 1f);
    }

    void Update()
    {

        Destroy(this.gameObject,10f);

    }
    public void ka()
    {
        AudioSource.PlayClipAtPoint(punchSound2, Camera.main.transform.position);
    }
}