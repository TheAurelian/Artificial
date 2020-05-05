using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [Tooltip("The speed of the platform")]
    [SerializeField]
    private int movementSpeed;

    [Tooltip("The movement time of the platform")]
    [SerializeField]
    private int movementTime;

    private void Start()
    {
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        float time = 1;
        while (time > 0)
        {
            StartCoroutine(PlatformUp());
            yield return new WaitForSeconds(14);
        }
    }

    IEnumerator PlatformUp()
    {
        Debug.Log("Platform Up");
        float timePassed = 0;
        while (timePassed < movementTime)
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
            timePassed += Time.deltaTime;

            yield return null;
        }
        StartCoroutine(PlatformDown());
    }

    IEnumerator PlatformDown()
    {
        Debug.Log("Platform Down");
        float timePassed = 0;
        while (timePassed < movementTime)
        {
            transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);
            timePassed += Time.deltaTime;

            yield return null;
        }
    }
}
