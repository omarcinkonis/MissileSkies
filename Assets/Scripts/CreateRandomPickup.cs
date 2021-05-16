using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateRandomPickup : MonoBehaviour
{
    public GameObject pickup;
    public float xMin = -8.5f;
    public float xMax = 8.5f;
    public float yMin = -4.5f;
    public float yMax = 4.5f;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(NextFloat(xMin, xMax), NextFloat(yMin, yMax), 0);
        pickup.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup.activeSelf == false)
        {
            position = new Vector3(NextFloat(xMin, xMax), NextFloat(yMin, yMax), 0);
            pickup.transform.position = position;
            pickup.SetActive(true);
        }
    }

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
