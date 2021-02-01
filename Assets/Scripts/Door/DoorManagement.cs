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
    private bool openDoor = false;
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

    #endregion


    #region Accessors

    public bool IsOpen()
    {
        return openDoor;
    }

    #endregion


    #region MonoBehaviour Methods

    void Start()
    {
        posInitial = transform.position;
        posDesired = target.position;
    }


    void Update()
    {

    }

    #endregion


    #region Private Methods

    private IEnumerator MoveDoor(Vector2 targetPosition, float duration)
    {
        float time = 0.0f;
        Vector2 startPosition = transform.position;

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
            interruptors[i].SetActivated();
        }
    }
    #endregion


    #region Public Methods

    public void CheckInterruptors()
    {

        if (canMove)
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

            if (nbActivated == interruptors.Count)
            {
                //they are all activated
                StartCoroutine(MoveDoor(posDesired, speed));
                openDoor = true;
            }
            else
            {
                if (openDoor)
                {
                    //the door is open but all interruptors aren't activated so we want to close it
                    StartCoroutine(MoveDoor(posInitial, speed));
                    openDoor = false;
                }

            }
        }

    }


    #endregion

}
