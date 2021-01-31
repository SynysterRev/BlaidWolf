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


    #endregion


    #region Public Methods

    public void CheckInterruptors()
    {

        if (canMove)
        {
            int nbActivated = 0;
            for (int i = 0; i < interruptors.Count; i++)
            {
                if (interruptors[i].GetActivated())
                {
                    nbActivated++;
                }
            }

            if (nbActivated == interruptors.Count)
            {
                StartCoroutine(MoveDoor(posDesired, speed));
                openDoor = true;
            }
            else
            {
                if (openDoor)
                {
                    StartCoroutine(MoveDoor(posInitial, speed));
                    openDoor = false;
                }

            }
        }
    }

    //pouvoir choisir le type d'interrupteur (dalle, timer, basique, avec item..)
    #endregion

}
