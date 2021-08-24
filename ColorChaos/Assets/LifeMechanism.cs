using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMechanism : MonoBehaviour
{
    ProjectileSpawner PS;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("GameController").GetComponent<ProjectileSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Circle")
        {
            PS.Lives--;
        }
    }
}
