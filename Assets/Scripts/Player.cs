using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gmObject;

    private GameManager gmScript;
    private Vector3 direction;
    private float gravity = -9.8f;
    private float jumpForce = 4f;

    private void Start()
    {
        gmScript = gmObject.GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    void Update()
    {
        if(transform.position.y < -5)
        {
            gmScript.GameOver();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * jumpForce;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            gmScript.GameOver();
        }

        if (collision.tag == "Scoring")
        {
            gmScript.IncreaseScore();
        }
    }

}
