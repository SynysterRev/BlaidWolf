using UnityEngine;
using System.Collections;
using DG.Util;

public class PlayerManager : Singleton<PlayerManager>
{

	#region Public Fields



	#endregion


	#region Private Fields
	[SerializeField]
	private DataPlayer data = null;
	[SerializeField]
	private HUD hud = null;

	private bool timerStarted = false;
	private float timer = 5.0f;


	#endregion


	#region Accessors
	public float GetHealth() => data.health;

	public float GetHealthMax() => data.healthMax;

	public float GetMana() => data.mana;

	public float GetManaMax() => data.manaMax;

	public float GetAdrenaline() => data.adrenaline;

	public float GetAdrenalineMax() => data.adrenalineMax;

	public bool IsDead() => data.isDead;

	public bool IsInvulnerable() => data.isInvulnerable;

	public void Invulnerable() => data.isInvulnerable = true;

	public void Vulnerable() => data.isInvulnerable = false;

	public float GetInvulnerabilityDuration() => data.invulnerabilityDuration;


	#endregion


	#region MonoBehaviour Methods

	void Start()
	{
		Resurrect();
		Vulnerable();
		hud.SetMaxHealth(data.healthMax);
	}


	void Update()
	{
		if (timerStarted)
		{
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				timerStarted = false;
				Vulnerable();
			}
		}
	}

	#endregion


	#region Private Methods

	#endregion


	#region Public Methods
	public void LoseHealth(float damage)
	{
		if (!data.isInvulnerable && !data.isDead)
		{
			data.health = Mathf.Clamp(value: data.health - damage, min: 0.0f, max: data.healthMax);
			hud.SetHealth(data.health);
			if (data.health <= 0.0f)
			{
				Death();
			}
		}
	}

	public void Heal(float heal)
	{
		data.health += heal;
		if (data.health > data.healthMax)
        {
			data.health = data.healthMax;
		}
		hud.SetHealth(data.health);
	}

	public void Death()
	{
		data.isDead = true;
	}


	//Mana management

	public void LooseMana(float mana)
	{
		data.mana = Mathf.Clamp(value: data.mana - mana, min: 0.0f, max: data.manaMax);
	}

	public bool EnoughtMana(float mana)
	{
		if (data.mana >= mana)
			return true;
		else
			return false;
	}

	public void RegenMana(float mana)
	{
		data.mana += mana;
		if (data.mana > data.manaMax)
			data.mana = data.manaMax;
	}

	//Adrenaline management
	public void ConsumAdrenaline()
	{
		if (data.adrenaline == data.adrenalineMax)
		{
			data.adrenaline = 0.0f;
		}
	}

	public void RegenAdrenaline(float adrenaline)
	{
		data.adrenaline += adrenaline;
		if (data.adrenaline > data.adrenalineMax)
			data.adrenaline = data.adrenalineMax;
	}

	//Others

	public void Resurrect()
	{
		data.health = data.healthMax;
		data.mana = data.manaMax;
		data.isDead = false;
	}

	//Manager
	public void BecomeInvulnerable()
	{
		Invulnerable();
		timer = GetInvulnerabilityDuration();
		timerStarted = true;
		Debug.Log("Health : " + GetHealth());
	}

	public void BecomeVulnerable()
	{
		Vulnerable();
		timerStarted = false;
	}

	public void TakeDamage(float damage)
	{
		if (!IsInvulnerable())
		{
			LoseHealth(damage);
			BecomeInvulnerable();
		}
	}


	#endregion


}
