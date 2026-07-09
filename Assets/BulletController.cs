using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float speed = 25.0f;

    // 命中音
    public AudioClip hitSE;

    Counter counter;

    public void SetCounter(Counter c)
    {
        this.counter = c;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            // 命中音を再生
            AudioSource.PlayClipAtPoint(hitSE, collision.transform.position);

            if (counter != null)
            {
                counter.hitCount++;
                Debug.Log(counter.hitCount + " Hit");
            }
        }

        Invoke("destroyBullet", 1);
    }

    private void destroyBullet()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0, 0, speed);
    }

    void Update()
    {

    }
}