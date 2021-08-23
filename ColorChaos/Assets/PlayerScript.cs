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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Pos2.position;
        SR = GetComponent<SpriteRenderer>();
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
    #endregion
}
