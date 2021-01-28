using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}
public class PlayerController : MonoBehaviour
{
    #region Private Attributes
    [SerializeField]
    private float speed = 5.0f;
    private Rigidbody2D rb = null;
    private Animator anim = null;
    private Vector2 lastDirection = Vector2.zero;
    private Direction lastDir = Direction.Down;
    private string currentState = "";
    //private 

    //private const
    #endregion

    #region Monobehavior methods
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Private methods
    //change state for animation
    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }
    #endregion
    #region Public methods
    public void Move(InputAction.CallbackContext context)
    {
        //get direction of input
        Vector2 dir = context.ReadValue<Vector2>();

        //prevent walking in diagonal
        //use the last direction pressed
        if (lastDirection != dir && dir != Vector2.zero)
        {
            if (Mathf.Abs(dir.x) != 1.0f && Mathf.Abs(dir.x - lastDirection.x) < 0.5f)
            {
                dir.x = 0.0f;
                dir.y = dir.y > 0.0f ? 1.0f : -1.0f;
            }
            else if (Mathf.Abs(dir.y) != 1.0f && Mathf.Abs(dir.y - lastDirection.y) < 0.5f)
            {
                dir.y = 0.0f;
                dir.x = dir.x > 0.0f ? 1.0f : -1.0f;
            }
        }

        //walking
        if (dir.x == 1.0f)
        {
            //move right
            lastDir = Direction.Right;
        }
        else if (dir.x == -1.0f)
        {
            //move left
            lastDir = Direction.Left;
        }
        else if (dir.y == 1.0f)
        {
            //move up
            lastDir = Direction.Up;
        }
        else if (dir.y == -1.0f)
        {
            //move down
            lastDir = Direction.Down;
        }
        ChangeAnimationState("Walk" + lastDir + "Player");

        //not moving then idle in last direction walk
        if (dir == Vector2.zero)
        {
            ChangeAnimationState("Idle" + lastDir + "Player");
        }

        //move player
        rb.velocity = dir * speed;

        lastDirection = dir;
    }
    #endregion
}
