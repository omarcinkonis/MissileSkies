using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text score;
    public static int count;

    public float speed, acceleration, rotationControl;
    float moveX = 1, moveY;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        score.text = "Score: " + count.ToString();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveY = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * moveX * acceleration;
        rb.AddForce(Vel);

        float dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(acceleration > 0)
        {
            if(dir < 0)
            {
                rb.rotation += moveY * rotationControl * rb.velocity.magnitude / speed;
            }
            else
            {
                rb.rotation -= moveY * rotationControl * rb.velocity.magnitude / speed;
            }
        }

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if(rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Crash"))
        {
            //SceneManager.LoadScene("Menu");
            SceneManager.LoadScene("GameOver");
        }

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            score.text = "Score: " + count.ToString();
        }
    }
}
