using UnityEngine;
using System.Collections;

public class DashSkill : MonoBehaviour
{

    #region Public Fields
    public delegate void DelegateDash();
    public event DelegateDash OnEndDash;


    #endregion


    #region Private Fields
    [SerializeField]
    private DataSkills dataDash = null;
    private float currentDistance = 0.0f;
    private float cooldown = 0.0f;
    private bool isDashing = false;
    private Vector2 lastPos = Vector2.zero;
    private Vector2 direction = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb = null;
    #endregion


    #region Accessors



    #endregion


    #region MonoBehaviour Methods

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (cooldown > 0.0f)
        {
            cooldown = Mathf.Clamp(cooldown - Time.deltaTime, 0.0f, 1000.0f);
        }
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            if (rb)
            {
                if (CanMove())
                {
                    velocity = direction * dataDash.speed;
                    currentDistance += Vector2.Distance(lastPos, transform.position);
                    if (currentDistance >= dataDash.range)
                    {
                        StopDash();
                        return;
                    }
                    rb.velocity = velocity;
                    lastPos = transform.position;
                }
                else
                {
                    StopDash();
                }
            }
        }
    }

    #endregion


    #region Private Methods
    private bool CanMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.7f);
        if (hit.collider != null)
        {
            return false;
        }
        return true;
    }

    private void StopDash()
    {
        isDashing = false;
        currentDistance = 0.0f;
        rb.velocity = Vector2.zero;
        OnEndDash?.Invoke();
    }

    #endregion


    #region Public Methods
    //return true when player can dash
    public bool Dash(Vector2 direction, ref DataPlayer dataPlayer)
    {
        if (cooldown > 0.0f)
            return false;
        if (PlayerManager.Instance.EnoughtMana(dataDash.manaCost))
        {
            if (!isDashing)
                isDashing = true;
            else return false;
            PlayerManager.Instance.LooseMana(dataDash.manaCost);
            this.direction = direction.normalized;
            cooldown = dataDash.cooldown;
            lastPos = transform.position;
        }
        else
        {
            return false;
        }
        return true;
    }

    #endregion


}
