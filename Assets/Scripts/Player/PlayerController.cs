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
    private DataPlayer dataPlayer = null;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private DashSkill dash = null;
    private Rigidbody2D rb = null;
    private Animator anim = null;
    private Vector2 dir = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;
    private Direction lastDir = Direction.Down;
    private string currentState = "";

    private bool isMoving = false;
    private bool hasStop = false;
    private bool isRepulsed = false;
    private int nbFrameRepulsed = 4;
    //Skills var
    private bool isDashing = false;
    //private 

    //private const
    #endregion

    #region Monobehavior methods
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dataPlayer = new DataPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveCharacter();
        if (isRepulsed)
        {
            nbFrameRepulsed--;
            if (nbFrameRepulsed == 0)
            {
                isRepulsed = false;
                rb.velocity = dir * speed;
            }
        }
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

    private void EndDashing()
    {
        isDashing = false;
    }

    private void MoveCharacter()
    {
        if (isDashing || isRepulsed) return;
        //prevent walking in diagonal
        //use the last direction pressed
        if (isMoving)
        {
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

            //move player
            rb.velocity = dir * speed;

            if (dir != Vector2.zero)
            {
                lastDirection = dir;
            }
        }
        else if (!isMoving && !hasStop)
        {
            hasStop = true;
            rb.velocity = dir * speed;
            //not moving then idle in last direction walk
            if (dir == Vector2.zero)
            {
                ChangeAnimationState("Idle" + lastDir + "Player");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDashing)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                isRepulsed = true;
                nbFrameRepulsed = 4;
                rb.AddForce(-lastDirection * 25.0f, ForceMode2D.Impulse);
            }
        }
        else
        {

        }
    }
    #endregion

    #region Public methods
    public void Move(InputAction.CallbackContext context)
    {
        //get direction of input
        dir = context.ReadValue<Vector2>();
        if (context.action.phase == InputActionPhase.Started)
        {
            isMoving = true;
            hasStop = false;
        }
        else if (context.action.phase == InputActionPhase.Canceled)
        {
            isMoving = false;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            if (dash.Dash(lastDirection, ref dataPlayer))
            {
                if (!isDashing)
                {
                    isDashing = true;
                    dash.OnEndDash += EndDashing;
                }
            }
        }
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, 0.7f);
            if (hit.collider != null)
            {
                IInteraction interact = hit.collider.GetComponent<IInteraction>();
                if(interact != null)
                {
                    interact.Interaction();
                }
            }
        }
    }
    #endregion
}
