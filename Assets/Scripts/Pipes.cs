using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    private float speed = 4.2f;
    private GameObject leftEdge;

    private void Start()
    {
        leftEdge = GameObject.FindGameObjectWithTag("LeftEdge");
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= leftEdge.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
