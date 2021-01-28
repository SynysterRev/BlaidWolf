using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class DoorManagement : MonoBehaviour
{

	#region Public Fields



	#endregion


	#region Private Fields

	private bool openDoor = false;

	#endregion


	#region Accessors



	#endregion


	#region MonoBehaviour Methods

	void Start()
	{

	}


	void Update()
	{
        if (openDoor)
        {
			Vector3 move = Vector3.down * 1.0f * Time.deltaTime;
			Vector3 posNextFrame = transform.position + move;

			if (posNextFrame.y > -4.0f)
			{
				transform.Translate(move);
			}
		}
	}

	#endregion


	#region Private Methods




	#endregion


	#region Public Methods

	public void OpenDoor(InputAction.CallbackContext context)
    {
		openDoor = true;
	}

	#endregion

	//Pouvoir changer la position dans l'éditeur
	//Faire un Lerp 
}
