using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovementSystem : MonoBehaviour
{

    public float speed;

    private Transform objectTransform;
    private Vector3 initialPos;

    void Start()
    {
        objectTransform = GetComponent<Transform>();
        initialPos = objectTransform.position;
    }

    void Update()
    {
        objectTransform.Translate(new Vector3(0f, 0f, -1f) * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("border"))
        {
            objectTransform.position = initialPos;
        }
    }
}
