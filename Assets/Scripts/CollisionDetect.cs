using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [Tooltip("Teleport location goes here")]
    [SerializeField]
    private Transform Destination;

    [Tooltip("Detection canvas goes here")]
    [SerializeField]
    private GameObject detectedCanvas;

    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("Collider detected");
        if (collider.gameObject.name == "hologram_LOD0")
        {
            // Debug.Log("Detected by drone");
            transform.position = Destination.transform.position;
            detectedCanvas.gameObject.SetActive(true);
            GetComponent<CharacterController>().enabled = false;
        }
    }

    private void LateUpdate()
    {
        if (GetComponent<CharacterController>().enabled == false)
        {
            Debug.Log("Player controller turned back on");
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
