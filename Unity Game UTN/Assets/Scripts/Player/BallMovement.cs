using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float speed = 0.3f;
    public MapMovementSystem mapScript;
    public Vector3 movement;

    private Transform ballT;
    private Rigidbody ballRB;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        ballT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float velocity = speed + mapScript.speed;
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveVertical, 0.0f, -moveHorizontal + 2f * mapScript.speed);

        ballRB.MovePosition(ballT.position + movement * velocity);
    }

    // Problema de movimiento
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        float velocity = speed + mapScript.speed;
    //        float moveHorizontal = Input.GetAxisRaw("Horizontal");
    //        float moveVertical = Input.GetAxisRaw("Vertical");

    //        movement = new Vector3(moveVertical, 0.0f, -moveHorizontal + 2f * mapScript.speed * wd);

    //        ballRB.MovePosition(-(ballT.position + movement * velocity));
    //    }
    //}
}
