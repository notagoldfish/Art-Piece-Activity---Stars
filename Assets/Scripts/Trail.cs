using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public TrailRenderer trail;
    public StarGlimmer starGlimmer;

    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        starGlimmer = GetComponent<StarGlimmer>();
    }

    private void Update()
    {
        if (starGlimmer.chosenColour == true)
        {
            trail.startColor = new Color(starGlimmer.colourR / 255, starGlimmer.colourG / 255, starGlimmer.colourB / 255, Random.Range(100, 200) / 255);
            trail.endColor = new Color(starGlimmer.colourR / 255, starGlimmer.colourG / 255, starGlimmer.colourB / 255, Random.Range(0, 20) / 255);
            trail.startWidth = Random.Range(0.005f, Random.Range(0.01f, 0.09f));
            starGlimmer.chosenColour = false;
        }
    }

}
