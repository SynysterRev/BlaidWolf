using UnityEngine;
using System.Collections;

public class LavaAoE : MonoBehaviour
{

    #region Public Fields



    #endregion


    #region Private Fields
    [SerializeField]
    private DataSkills dataLava = null;
    private bool onAoe = false;
    private float timerInit = 0.0f;
    private float timer = 0.0f;
    private float damage = 0.0f;

    #endregion


    #region Accessors



    #endregion


    #region MonoBehaviour Methods

    void Start()
    {
        timerInit = dataLava.timeBetweenDamage;
        damage = (PlayerManager.Instance.GetHealthMax() * dataLava.power) / 100;
    }


    void Update()
    {
        if (onAoe)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                timer = timerInit;
                PlayerManager.Instance.TakeDamage(damage);
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
