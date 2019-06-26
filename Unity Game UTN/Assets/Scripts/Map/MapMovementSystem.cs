using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovementSystem : MonoBehaviour
{

    public float speed = 0.3f;

    private Transform objectTransform;
    private Rigidbody objectRigidbody;
    private Vector3 initialPos;

    void Start()
    {
        objectTransform = GetComponent<Transform>();
        objectRigidbody = GetComponent<Rigidbody>();
        initialPos = objectTransform.position;
    }

    void Update()
    {
        objectRigidbody.MovePosition(objectTransform.position + new Vector3(0f, 0f, -1f) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("border"))
        {
            objectTransform.position = initialPos;
        }
    }
}
