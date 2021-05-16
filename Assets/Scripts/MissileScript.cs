using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // reset position
    private Vector2 StartPoint;
    private float startTime;
    public float timeToRespawnFrom = 10;
    public float timeToRespawnTo = 20;
    private float timeToRespawn;

    // movement
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(1, 0);

    // Use this for initialization
    void Start()
    {
        // reset position
        StartPoint = this.transform.position;
        startTime = Time.time;
        timeToRespawn = NextFloat(timeToRespawnFrom, timeToRespawnTo);
    }


    // Update is called once per frame
    void Update()
    {
        // reset position
        if (Time.time - startTime > timeToRespawn)
        {
            this.transform.position = StartPoint;
            startTime = Time.time;
            timeToRespawn = NextFloat(timeToRespawnFrom, timeToRespawnTo);
        }

        // movement
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
