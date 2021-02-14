using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStars : MonoBehaviour
{
    [Range(1, 1000)] public int initStarAmount;
    [Range(1, 1000)] public int maxStars;
    public GameObject star;
    public float minTime;
    public float maxTime;
    public int starAmount;

    public bool checkedStarAmount = true;

    public GameObject backdrop;

    IEnumerator SpawnStar(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        
        if (SpeedUp.starAmount < maxStars)
        {
            SpeedUp.starAmount++;
            SpawnStar();
            StartCoroutine("SpawnStar", Random.Range(minTime, maxTime));
        }
        yield return null;
    }

    IEnumerator OneStar(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.

        StartCoroutine("SpawnStar", 0.1);
        StartCoroutine("OneStar", 1);

        yield return null;
    }

    private void OnEnable()
    {
        StartCoroutine("SpawnStar", 0.1);
    }

    private void Start()
    {
        StartCoroutine("SpawnStar", Random.Range(minTime, maxTime));

        for (SpeedUp.starAmount = 0; SpeedUp.starAmount < initStarAmount; SpeedUp.starAmount++)
        {
            SpawnStar();
        }
    }

    private void Update()
    {
        if (checkedStarAmount == false && SpeedUp.starAmount < maxStars)
        {
            StartCoroutine("SpawnStar", Random.Range(minTime, maxTime));
            checkedStarAmount = true;
        } else if (SpeedUp.starAmount >= maxStars)
        {
            checkedStarAmount = false;
        }

        starAmount = SpeedUp.starAmount;

    }

    void SpawnStar()
    {
        Instantiate(star, new Vector3(Random.Range(-20f, 20f), Random.Range(-32f, 8f), 0), Quaternion.identity, backdrop.transform);
    }
}
