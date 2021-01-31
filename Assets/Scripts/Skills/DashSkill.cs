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


    void Update()
    {
        if (cooldown > 0.0f)
        {
            cooldown = Mathf.Clamp(cooldown - Time.deltaTime, 0.0f, 1000.0f);
        }
        if (isDashing)
        {
            if (rb)
            {
                if (currentDistance >= dataDash.range)
                {
                    isDashing = false;
                    currentDistance = 0.0f;
                    rb.velocity = Vector2.zero;
                    OnEndDash?.Invoke();
                    return;
                }
                velocity = direction * dataDash.speed;
                rb.velocity = velocity;
                currentDistance += velocity.magnitude;
            }
        }
    }

    #endregion


    #region Private Methods



    #endregion


    #region Public Methods
    //return true when player can dash
    public bool Dash(Vector2 direction, ref DataPlayer dataPlayer)
    {

        if (cooldown > 0.0f)
            return false;
        if (dataPlayer.EnoughtMana(dataDash.manaCost))
        {
            if (!isDashing)
                isDashing = true;
            else return false;
            dataPlayer.LooseMana(dataDash.manaCost);
            this.direction = direction.normalized;
            cooldown = dataDash.cooldown;
        }
        else
        {
            return false;
        }
        return true;
    }


    #endregion


}
