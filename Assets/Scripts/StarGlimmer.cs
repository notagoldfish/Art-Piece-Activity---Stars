using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGlimmer : MonoBehaviour
{

    SpriteRenderer sprite;
    Transform transform;
    float transReach;
    public float currentTrans;
    float transSpeed = 0.2f;
    public float minTime = 0.1f;
    public float maxTime = 2f;
    public float minSpeed = 0.2f;
    public float maxSpeed = 5f;
    public float colourR;
    public float colourG;
    public float colourB;
    float size;
    float colourChance;
    public bool chosenColour = false;

    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        Glimmer();
        transSpeed = Random.Range(minSpeed, maxSpeed);
        StartCoroutine("Reset", Random.Range(minTime, maxTime));
        yield return null;
    }


    private void Start()
    {
        StartCoroutine("Reset", 1);
        sprite = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();

        colourChance = Random.Range(0, 100);
        if (colourChance < 50)
        {
            colourR = 255;
            colourG = 255;
            colourB = 255;
            chosenColour = true;
        } else if (colourChance > 50 && colourChance < 92)
        {
            colourR = 255;
            colourG = 255;
            colourB = Random.Range(0, 175);
            chosenColour = true;
        } else if (colourChance > 92)
        {
            colourR = Random.Range(0, 255);
            colourG = Random.Range(0, 255);
            colourB = Random.Range(0, 255);
            chosenColour = true;
        }
        size = Random.Range(0.05f, Random.Range(0.1f, 0.45f));
        transform.localScale = new Vector3(size, size, size);
    }

    private void Update()
    {
        if (currentTrans < transReach)
        {
            sprite.color = new Color(colourR / 255, colourG / 255, colourB / 255, currentTrans/255);
            currentTrans += transSpeed;
        }
        else if (currentTrans > transReach)
        {
            sprite.color = new Color(colourR / 255, colourG / 255, colourB / 255, currentTrans/255);
            currentTrans -= transSpeed;
        } else if (currentTrans == transReach)
        {
            Glimmer();
        }
    }

    private void Glimmer()
    {
        transReach = Random.Range(0, 255);
    }

}
