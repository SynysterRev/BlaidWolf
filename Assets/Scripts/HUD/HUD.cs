using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

	#region Public Fields
	public Slider slider; 


	#endregion


	#region MonoBehaviour Methods

	void Start()
	{

	}


	void Update()
	{

	}

	#endregion


	#region Public Methods
	public void SetHealth(float health)
    {
		slider.value = health;
    }

	public void SetMaxHealth(float health)
    {
		slider.maxValue = health;
		slider.value = health;
    }

	#endregion


}
