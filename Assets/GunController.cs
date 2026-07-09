using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public GameObject bullet;

    public float speed = 0.01f;
    public float jumpForce = 350.0f;

    public float normalSpeed = 0.01f;
    public float powerUpSpeed = 0.03f;
    public float powerUpTime = 5.0f;

    public TextMeshProUGUI speedUpText;

    Counter counter;

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.z <= -5)
            {
                transform.Translate(0, 0, speed);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.z >= -9)
            {
                transform.Translate(0, 0, -speed);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -9.5f)
            {
                transform.Translate(-speed, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 9.5f)
            {
                transform.Translate(speed, 0, 0);
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rigidbody.velocity.y == 0)
        {
            rigidbody.AddForce(transform.up * jumpForce);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 bulletPosition = transform.position + new Vector3(0, 0.5f, 1.2f);

            GameObject newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);

            BulletController bulletController = newBullet.GetComponent<BulletController>();

            bulletController.SetCounter(counter);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            PowerUpItem powerUpItem = other.gameObject.GetComponent<PowerUpItem>();

            if (powerUpItem != null)
            {
                powerUpItem.HideAndRespawn();
            }

            StopCoroutine("PowerUp");
            StartCoroutine("PowerUp");
        }
    }

    IEnumerator PowerUp()
    {
        speed = powerUpSpeed;

        if (speedUpText != null)
        {
            speedUpText.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(powerUpTime);

        speed = normalSpeed;

        if (speedUpText != null)
        {
            speedUpText.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        counter = GameObject.Find("GameDirector").GetComponent<Counter>();

        speed = normalSpeed;

        if (speedUpText != null)
        {
            speedUpText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        Move();
        Jump();
        Shoot();
    }
}