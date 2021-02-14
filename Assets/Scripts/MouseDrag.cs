using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 mousePosition;
    public float moveSpeed = 100f;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
    private CircleCollider2D collider;
    private Transform transform;
    float cursorSize = 0.01f;
    public float maxCursorSize = 1f;
    private bool clicked = false;
    public float cursorChangeSpeed = 0.01f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        transform.localScale = new Vector3(cursorSize, cursorSize, cursorSize);
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }

        if (cursorSize <= 0.01f)
        {
            collider.enabled = false;
        } else if (cursorSize > 0.01f)
        {
            collider.enabled = true;
        }

        if (clicked == false && cursorSize > 0.01f)
        {
            cursorSize -= cursorChangeSpeed;
        }
        if (clicked == true && cursorSize < maxCursorSize)
        {
            cursorSize += cursorChangeSpeed;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
