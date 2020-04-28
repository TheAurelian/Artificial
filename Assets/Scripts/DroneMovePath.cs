using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovePath : MonoBehaviour
{
    [Tooltip("The speed of the drone")]
    [SerializeField]
    private int movementSpeed;

    private void Start()
    {
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        float time = 1;
        while (time > 0) 
        {
            StartCoroutine(DroneMovement());
            yield return new WaitForSeconds(10);
        }
    }

    IEnumerator DroneMovement()
    {
        float timePassed = 0;
        while (timePassed < 7)
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
            Debug.Log("Drone is moving left");
            timePassed += Time.deltaTime;

            yield return null;
        }
        transform.Rotate(0, 180, 0);
    }
}
