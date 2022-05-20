using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gmObject;
    public AudioSource jumpSound;

    private GameManager gmScript;
    private Vector3 direction;
    private float gravity = -9.8f;
    private float jumpForce = 4f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private int spriteIndex; 

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gmScript = gmObject.GetComponent<GameManager>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= spriteArray.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = spriteArray[spriteIndex];
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if(transform.position.y < -5)
        {
            gmScript.GameOver();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
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
