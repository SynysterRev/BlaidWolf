using UnityEngine;
using System.Collections;

public class RegenAoE : MonoBehaviour
{
    //Damage = % of regen
    #region Public Fields



    #endregion


    #region Private Fields
    [SerializeField]
    private DataSkills data = null;
    private bool onAoe = false;
    private float timerInit = 0.0f;
    private float timer = 0.0f;
    private float heal = 0.0f;
    private float regenMana = 0.0f;

    #endregion


    #region Accessors



    #endregion


    #region MonoBehaviour Methods

    void Start()
    {
        timerInit = data.timeBetweenDamage;
        heal = (PlayerManager.Instance.GetHealthMax() * data.power) / 100;
        Debug.Log(heal);
        regenMana = (PlayerManager.Instance.GetManaMax() * data.power) / 100;
        Debug.Log(regenMana);
    }


    void Update()
    {
        if (onAoe)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                timer = timerInit;
                PlayerManager.Instance.Heal(heal);
                PlayerManager.Instance.RegenMana(regenMana);
            }

        }
    }

    #endregion


    #region Private Methods



    #endregion


    #region Public Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onAoe = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onAoe = false;
    }

    #endregion


}
