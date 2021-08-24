using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;
    private SpriteRenderer SR;
    private ProjectileSpawner PS;
    private bool IsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Pos2.position;
        SR = GetComponent<SpriteRenderer>();
        PS = GameObject.FindGameObjectWithTag("GameController").GetComponent<ProjectileSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == Pos1.position)
        {
            SR.color = Color.red;
        }
        else if(transform.position == Pos2.position)
        {
            SR.color = Color.green;
        }
        else if (transform.position == Pos3.position)
        {
            SR.color = Color.blue;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            PS.Speed = PS.Speed - Random.Range(2.5f, 11f);
            PS.Score++;
            Destroy(collision.gameObject);
        }
    }

    #region InputActions
    public void OnRed(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            transform.position = Pos1.position;
        }
    }

    public void OnGreen(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            transform.position = Pos2.position;
        }
    }

    public void OnBlue(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            transform.position = Pos3.position;
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (!IsPaused && ctx.phase == InputActionPhase.Performed)
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
        else if (IsPaused && ctx.phase == InputActionPhase.Performed)
        {
            Time.timeScale = 1;
            IsPaused = false;
        }
    }

    public void OnQuit(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Application.Quit();
        }
    }
    #endregion
}
