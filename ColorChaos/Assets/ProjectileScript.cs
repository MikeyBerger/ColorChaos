using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody2D RB;
    public float Speed;
    private SpriteRenderer SR;
    private ProjectileSpawner PS;
    private int Score;
    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        PS = GameObject.FindGameObjectWithTag("GameController").GetComponent<ProjectileSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(0, PS.Speed) * Time.deltaTime;
        //transform.Translate(0, PS.Speed * Time.deltaTime, 0);
        Score = PS.Score;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SR.enabled = false;
            //Score++;
            PS.Score++;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SR.enabled = false;
            //Score++;
            PS.Score++;
            PS.Speed = PS.Speed - Random.Range(0.5f, 2.5f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }


}
