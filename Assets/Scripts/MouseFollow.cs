using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    Vector3 mousePosition;
    public float maxMoveSpeed = 0.1f;
    public float speedIncrease = 0.01f;
    public float speedDecrease = 0.001f;
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 randomPosition = new Vector2(0f, 0f);
    Vector2 position = new Vector2(0f, 0f);
    public bool drag = false;
    bool initiated = false;
    float randomy;
    float randomx;
    public float randomRangeFollow = 1f;

    public float randomRangeExplode = 5f;
    bool chosenPosition = false;
    Vector2 randomExplosionPosition;
    bool letsExplode = false;
    bool explodeMoving = false;

    float explosionSpeed = 0f;

    private void Start()
    {
        moveSpeed = 0f;
        rb = GetComponent<Rigidbody2D>();

        randomy = Random.Range(-randomRangeFollow, randomRangeFollow);
        randomx = Random.Range(-randomRangeFollow, randomRangeFollow);
        randomPosition = new Vector2(randomx, randomy);
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (letsExplode == true)
        {
            explodeMoving = true;
        }

        if (drag == true)
        {
            explodeMoving = false;
            position = randomPosition + Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            chosenPosition = false;
        } else if (drag == false && explodeMoving == true)
        {
            if (chosenPosition == false)
            {
                randomExplosionPosition = new Vector2(transform.position.x + Random.Range(-randomRangeExplode, randomRangeExplode), transform.position.y + Random.Range(-randomRangeExplode, randomRangeExplode));
                chosenPosition = true;
            }
            position = Vector2.Lerp(transform.position, randomExplosionPosition, explosionSpeed);
            letsExplode = false;
        }
        

        if (drag == true && moveSpeed < maxMoveSpeed)
        {
            moveSpeed += speedIncrease;
        } else if (drag == false && letsExplode == false)
        {
            moveSpeed = 0;
        }

        if (explodeMoving == true && moveSpeed < maxMoveSpeed)
        {
            explosionSpeed += speedIncrease;
        }
        else if (explodeMoving == false && letsExplode == false)
        {
            explosionSpeed = 0;
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
        if (collision.gameObject.CompareTag("CursorDrag"))
        {
            drag = true;
            initiated = true;
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            letsExplode = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CursorDrag"))
        {
            drag = false;
        }
    }

}
