using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0, 1)] public float speed = 1f;
    float rotation;

    private void Update()
    {
        if (SpeedUp.spedUp == true)
        {
            this.gameObject.transform.Rotate(0f, 0f, rotation/360);
            rotation -= speed;
        }
    }

}
