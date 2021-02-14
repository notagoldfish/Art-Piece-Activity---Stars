using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSpawn : MonoBehaviour
{

    public float checkTime;

    bool safe;
    bool inCircleNZ;
    bool inSquareNZ;

    Trail trail;

    IEnumerator CheckLocation(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        if (SpeedUp.spedUp == false)
        {
            trail.trail.startColor = new Color(0, 0, 0, 0);
            trail.trail.endColor = new Color(0, 0, 0, 0);
            if (inCircleNZ == true)
            {
                inCircleNZ = false;
                transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-32, 8));
            }

            if (inSquareNZ == true && safe == false)
            {
                inSquareNZ = false;
                transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-32, 8));

            }
            trail.trail.startColor = new Color(trail.starGlimmer.colourR / 255, trail.starGlimmer.colourG / 255, trail.starGlimmer.colourB / 255, Random.Range(100, 200) / 255);
            trail.trail.endColor = new Color(trail.starGlimmer.colourR / 255, trail.starGlimmer.colourG / 255, trail.starGlimmer.colourB / 255, Random.Range(0, 20) / 255);

        }

        safe = false;

        StartCoroutine("CheckLocation", checkTime);

        yield return null;
    }

    private void Start()
    {
        StartCoroutine("CheckLocation", checkTime);
        trail = GetComponent<Trail>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoZoneCircle"))
        {
            inCircleNZ = true;
        }
        if (collision.gameObject.CompareTag("NoZoneSquare"))
        {
            inSquareNZ = true;
        }
        if (collision.gameObject.CompareTag("Backdrop"))
        {
            safe = true;
        }
    }

}
