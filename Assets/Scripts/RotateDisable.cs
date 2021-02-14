using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDisable : MonoBehaviour
{
    MouseFollow mouseFollow;
    StarGlimmer starGlimmer;
    Disappear disappear;
    Trail trail;
    CheckForSpawn checkForSpawn;
    NewStars newStars;

    private void Start()
    {
        mouseFollow = GetComponent<MouseFollow>();
        starGlimmer = GetComponent<StarGlimmer>();
        disappear = GetComponent<Disappear>();
        trail = GetComponent<Trail>();
        checkForSpawn = GetComponent<CheckForSpawn>();
        newStars = GetComponent<NewStars>();
    }

    private void Update()
    {
        if (SpeedUp.spedUp == true)
        {
            if (mouseFollow != null)
            {
                mouseFollow.enabled = false;
            }
            if (starGlimmer != null)
            {
                starGlimmer.enabled = false;
            }
            if (disappear != null)
            {
                disappear.enabled = false;
            }
            if (trail != null)
            {
                trail.enabled = false;
            }
            if (checkForSpawn != null)
            {
                checkForSpawn.enabled = false;
            }

            if (newStars != null)
            {
                newStars.enabled = false;
            }
        } else
        {
            if (mouseFollow != null)
            {
                mouseFollow.enabled = true;
            }
            if (starGlimmer != null)
            {
                starGlimmer.enabled = true;
            }
            if (disappear != null)
            {
                disappear.enabled = true;
            }
            if (trail != null)
            {
                trail.enabled = true;
            }
            if (checkForSpawn != null)
            {
                checkForSpawn.enabled = true;
            }

            if (newStars != null)
            {
                newStars.enabled = true;
            }
        }
    }

}
