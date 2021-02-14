using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour
{

    public bool clicked = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Input.GetMouseButton(0) == false)
        {
            SpeedUp.spedUp = true;
        } else if (Input.GetMouseButtonUp(1))
        {
            SpeedUp.spedUp = false;
        } else if (Input.GetMouseButtonDown(0))
        {
            SpeedUp.spedUp = false;
        }

        clicked = SpeedUp.spedUp;

    }
}
