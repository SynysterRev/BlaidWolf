using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "new EnemyData", menuName = "Datas/Enemy")]
public class DataEnemy : ScriptableObject
{

	#region Public Fields

	public float health = 100.0f;
	public float healthMax = 100.0f;

	#endregion


	#region Private Fields

	private const float Min = 0.0f;
	private bool isDead     = false;

	#endregion


	#region Accessors


	#endregion


	#region Private Methods



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

	public void Death()
	{
		isDead = true;
	}
	#endregion


}
