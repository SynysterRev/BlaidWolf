using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    #region Public Fields
    #endregion

    #region Private Fields
    private const float Min  = 0.0f;
    private float health     = 100.0f;
    private float healthMax  = 100.0f;
    private float mana       = 100.0f;
    private float manaMax    = 100.0f;
    private float adrenaline = 100.0f;
    private float adrenalineMax = 100.0f;
    private bool  isDead     = false;
    #endregion

    #region Accessors
    public float GetHealth() => health;

    public float GetHealthMax() => healthMax;

    public float GetMana() => mana;

    public float GetManaMax() => manaMax;

    public float GetAdrenaline() => adrenaline;

    public float GetAdrenalineMax() => adrenalineMax;

    #endregion

    #region Public Methods

    //Health management
    public void LooseHealth(float damage)
    {
        health = Mathf.Clamp(value: health - damage, min: Min, max: healthMax);
        if (health <= Min)
        {
            Death();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > healthMax)
            health = healthMax;
    }

    public void Death()
    {
        isDead = true;
    }


    //Mana management

    public void LooseMana (float mana)
    {
        this.mana = Mathf.Clamp(value: this.mana - mana, min: Min, max: manaMax);
    }

    public bool EnoughtMana (float mana)
    {
        if (this.mana >= mana)
            return true;
        else
            return false;
    }

    public void RegenMana(float mana)
    {
        this.mana += mana;
        if (this.mana > manaMax)
            this.mana = manaMax;
    }

    //Adrenaline management
    public void ConsumAdrenaline ()
    {
        if (adrenaline == adrenalineMax)
        {
            adrenaline = Min;
        }
    }

    public void RegenAdrenaline (float adrenaline)
    {
        this.adrenaline += adrenaline;
        if (this.adrenaline > adrenalineMax)
            this.adrenaline = adrenalineMax;
    }

    //Others

    public void Resurrect()
    {
        health = healthMax;
        mana = manaMax;
    }
    #endregion

    #region Private Methods
    #endregion


}
