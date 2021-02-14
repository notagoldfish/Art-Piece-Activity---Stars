using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float minDelete = 15f;
    public float maxDelete = 45f;
    float deleteTime;
    StarGlimmer starGlimmer;
    bool deleting = false;
    SpriteRenderer sprite;
    float transparency;
    TrailRenderer trail;

    private void Start()
    {
        starGlimmer = GetComponent<StarGlimmer>();
        sprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        deleteTime = Random.Range(minDelete, maxDelete);
        StartCoroutine("Delete", deleteTime);
    }

    IEnumerator Delete(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        transparency = starGlimmer.currentTrans;
        starGlimmer.enabled = false;
        deleting = true;
        yield return null;
    }

    private void Update()
    {
        if (deleting == true)
        {
            sprite.color = new Color(1, 1, 1, transparency / 255);
            transparency -= 1f;

            trail.time = 0.5f * transparency / 255f;

            if (transparency <= 0f)
            {
                SpeedUp.starAmount--;
                Destroy(gameObject);
            }
        }
    }

}
