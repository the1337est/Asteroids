using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {


    public float TurnSpeed;
    public float Acceleration;

    public float MaxSpeed;

    Rigidbody2D rb;
    
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * TurnSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * TurnSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity += new Vector2(transform.up.x, transform.up.y) * Time.deltaTime * Acceleration;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity += new Vector2(-transform.up.x, -transform.up.y) * Time.deltaTime * Acceleration;
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);

        if (transform.position.x < -6.9f)
        {
            transform.position = new Vector3(6.9f, transform.position.y);
        }

        if (transform.position.x > 6.9f)
        {
            transform.position = new Vector3(-6.9f, transform.position.y);
        }

        if (transform.position.y > 5.5f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f);
        }

        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(transform.position.x, 5.5f);
        }

    }
}
