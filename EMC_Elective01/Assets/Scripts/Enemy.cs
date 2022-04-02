using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D RB;
    public float speed= 50f;
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
    }

    public void SetTrajectory(Vector2 direction)
    {
        RB.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Bullet")
       {
            Destroy(this.gameObject);
       }
       if (collision.gameObject.tag == "Player")
       {
            Destroy(this.gameObject);
       }
       if (collision.gameObject.tag == "Wall")
       {
           Destroy(this.gameObject);
       }
    }
}
