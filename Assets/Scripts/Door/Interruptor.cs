using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Interruptor : MonoBehaviour
{

	#region Public Fields



	#endregion


	#region Private Fields
	[SerializeField]
	private bool activated = false;
	[SerializeField]
	private List<DoorManagement> doors = null;
    enum Type { slab, timer, classic, item, openClose };
	[SerializeField]
	private Type type = Type.openClose;
	[SerializeField]
	private float timerInit = 0.0f;
	private float timer = 0.0f;
	private bool timerStarted = false;

	#endregion


	#region Accessors

	public bool GetActivated()
    {
		return activated;
    }

	public void SetActivated()
    {
		if (activated)
        {
			activated = false;
        }
        else
        {
			activated = true;
        }

        for (int i = 0; i < doors.Count; i++)
        {
			doors[i].CheckInterruptors();
		}
    }

	#endregion


	#region MonoBehaviour Methods

	void Start()
	{
		timer = timerInit;
	}


	void Update()
	{
        if (timerStarted)
        {
			timer -= Time.deltaTime;
			Debug.Log(timer);
			if (timer <= 0.0f)
			{
				
				for (int i = 0; i < doors.Count; i++)
				{
                    if (doors[i].IsOpen())
                    {
						this.gameObject.SetActive(false);
					}
                    else
                    {
						timer = timerInit;
						activated = false;
						timerStarted = false;
                    }
				}
			}
		}
	}

	#endregion


	#region Private Methods


	#endregion


	#region Public Methods

	public void Interact(InputAction.CallbackContext context)
	{
		
		if (context.action.phase == InputActionPhase.Started)
		{
			SetActivated();
			switch (type)
            {
                case Type.slab:
                    break;
                case Type.timer:
					timerStarted = true;
                    break;
                case Type.classic:
					this.gameObject.SetActive(false);
					break;
                case Type.item:
                    break;
                case Type.openClose:
                    break;
                default:
                    break;
            }
        }

	}
	#endregion


}
