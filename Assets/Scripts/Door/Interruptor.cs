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
    private DoorManagement door = null;
    [SerializeField]
    private float timerInit = 0.0f;
    private float timer = 0.0f;
    private bool timerStarted = false;
    private bool onSlab = false;


    #endregion


    #region Accessors

    public bool GetActivated()
    {
        return activated;
    }

    public void SetActivated()
    {
        activated = !activated;
    }
    #endregion


    #region MonoBehaviour Methods

    void Start()
    {

    }


    void Update()
    {

    }

    #endregion


    #region Private Methods


    #endregion


    #region Public Methods


    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetActivated();
        PreventDoor();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetActivated();
        PreventDoor();
    }

    private void PreventDoor()
    {
        door.CheckInterruptors();
    }

    //interrupteur n'a qu'une porte
    //c'est la porte qui est typée

}
