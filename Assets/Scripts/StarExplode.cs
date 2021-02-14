using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExplode : MonoBehaviour
{

    MouseFollow mouseFollowScript;
    public bool tooClose;
    float randomy;
    float randomx;
    public float randomRange = 1f;
    bool chosenRange = false;
    Vector2 position = new Vector2(0f, 0f);
    Vector2 explosionPosition;
    public float maxExplosionSpeed = 1f;
    float explosionSpeed;
    public float explosionIncrease = 0.2f;
    Rigidbody2D rb;
    bool initiated = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseFollowScript = GetComponent<MouseFollow>();
    }

    private void Update()
    {
        if (tooClose == true)
        {
            if (chosenRange == false)
            {
                randomy = Random.Range(-randomRange, randomRange);
                randomx = Random.Range(-randomRange, randomRange);
                explosionPosition = new Vector2(randomx, randomy);
                position = Vector2.Lerp(transform.position, explosionPosition, explosionSpeed);
                chosenRange = true;
            }
            if (explosionSpeed < maxExplosionSpeed)
            {
                explosionSpeed += explosionIncrease;
            }
        } else if (tooClose == false && explosionSpeed > 0)
        {
            explosionSpeed -= explosionIncrease;
        }
    }

    private void FixedUpdate()
    {
        if (initiated == true)
        {
            rb.MovePosition(position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            tooClose = true;
            initiated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            tooClose = false;
            chosenRange = false;
        }
    }

}
