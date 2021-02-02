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
    private bool onSlab = false;
    public delegate void DelegateEnterZone(bool onSlab);
    public event DelegateEnterZone OnEnterZone;
    public delegate void DelegateExitZone(bool onSlab);
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

    public bool GetOnSlab()
    {
        return onSlab;
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
            onSlab = true;
            Activate();
            OnEnterZone?.Invoke(onSlab);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isActiveAndEnabled)
        {
            onSlab = false;
            Desactivate();
            OnExitZone?.Invoke(onSlab);
        }

    }
    //02.02.21 => onSlab useless (vu que comme activate) ??
}
