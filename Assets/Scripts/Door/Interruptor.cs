using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Interruptor : MonoBehaviour, IInteraction
{

    #region Public Fields



    #endregion


    #region Private Fields
    [SerializeField]
    private bool activated = false;
    public delegate void DelegateEnterZone();
    public event DelegateEnterZone OnEnterZone;
    public delegate void DelegateExitZone();
    public event DelegateEnterZone OnExitZone;

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

    public void Activate()
    {
        activated = true;
    }

    public void Desactivate()
    {
        activated = false;
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
        if (isActiveAndEnabled)
        {
            Activate();
            OnEnterZone?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isActiveAndEnabled)
        {
            Desactivate();
            OnExitZone?.Invoke();
        }
    }

    public void Interaction()
    {
        if (isActiveAndEnabled)
        {
            SetActivated();
            OnEnterZone?.Invoke();
        }
    }
}
