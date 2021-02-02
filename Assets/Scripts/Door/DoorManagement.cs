using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.UI;

public class DoorManagement : MonoBehaviour
{

    #region Public Fields



    #endregion


    #region Private Fields
    [SerializeField]
    private bool doorOpened = false;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private float speed = 0.0f;
    [SerializeField]
    private List<Interruptor> interruptors = null;
    private Vector2 posDesired = Vector2.zero;
    private Vector2 posInitial = Vector2.zero;
    private bool canMove = true;
    enum Type { slab, timer, openOnce, item, openClose };
    [SerializeField]
    private Type type = Type.openOnce;
    private Coroutine coroutine = null;
    private float distanceMax = 0.0f;

    [SerializeField]
    private float timerInit = 0.0f;
    private float timer = 0.0f;
    private bool timerStarted = false;
    #endregion


    #region Accessors

    public bool IsOpen()
    {
        return doorOpened;
    }

    #endregion


    #region MonoBehaviour Methods

    void Start()
    {
        posInitial = transform.position;
        posDesired = target.position;
        distanceMax = Vector2.Distance(posInitial, posDesired);

        timer = timerInit;

        for (int i = 0; i < interruptors.Count; i++)
        {
            interruptors[i].OnEnterZone += CheckInterruptors;
            interruptors[i].OnExitZone += CheckInterruptors;
        }
    }


    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                timerStarted = false;
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(MoveDoor(posInitial));
            }
        }
    }

    #endregion


    #region Private Methods

    private IEnumerator MoveDoor(Vector2 targetPosition)
    {
        float time = 0.0f;
        Vector2 startPosition = transform.position;

        float distance = Vector2.Distance(startPosition, targetPosition);
        float duration = (distance * speed) / distanceMax;

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            canMove = false;
            yield return null;
        }
        canMove = true;
        transform.position = targetPosition;
    }

    private void DesactivateInterruptors()
    {
        for (int i = 0; i < interruptors.Count; i++)
        {
            if (interruptors[i].GetActivated())
            {
                interruptors[i].Desactivate();
            }
        }
    }

    private void DeleteInterruptors()
    {
        for (int i = 0; i < interruptors.Count; i++)
        {
            interruptors[i].GetComponent<Interruptor>().enabled = false;
        }
    }
    #endregion


    #region Public Methods

    public void CheckInterruptors(bool onSlab)
    {

        //the door isn't in movement
        int nbActivated = 0;
        for (int i = 0; i < interruptors.Count; i++)
        {
            //how many interruptors are activated ?
            if (interruptors[i].GetActivated())
            {
                nbActivated++;
            }
        }

        if (nbActivated == interruptors.Count && onSlab)
        {
            //they are all activated
            DoorOpening();

        }
        else
        {
            if (doorOpened)
            {
                //the door is open but all interruptors aren't activated so we want to close it
                DoorClosing();
            }

        }

    }

    public void DoorOpening()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        if (type == Type.openClose)
        {

            if (doorOpened)
            {
                coroutine = StartCoroutine(MoveDoor(posInitial));
                doorOpened = false;
            }
            else
            {
                coroutine = StartCoroutine(MoveDoor(posDesired));
                doorOpened = true;
            }
        }
        else
        {
            coroutine = StartCoroutine(MoveDoor(posDesired));
            doorOpened = true;

            if (type == Type.openOnce)
            {
                DeleteInterruptors();
            }

            if (type == Type.timer)
            {
                //reset timer
                timer = timerInit;
                //start timer
                timerStarted = true;
            }
        }

    }

    public void DoorClosing()
    {
        if (type != Type.openClose && type != Type.timer)
        {

            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(MoveDoor(posInitial));
            doorOpened = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reset timer
        timer = timerInit;
        //can pass the door only once
        DesactivateInterruptors();
        //stop timer
        timerStarted = false;
        //put the door open
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(MoveDoor(posDesired));
    }
    #endregion
    //openOnce = The door can only be open once.
    //slab     = While their is something in the collider of the interruptor the door stay open. If this something left, the door will close etc.
    //openClose = If something pass on the collider of the interruptor, the door will open. If it's pass again, the door will close etc.
    //timer = When the interruptor is activated, the door opens. At the same time, a timer is started. If at the end of the timer something don't pass the door, it's will close it.
}
