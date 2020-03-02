using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls the Innteractive's interactwith method
/// </summary>

public class InteractiveWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectLookatInteractive detectLookedAtInteractive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive.LookAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            detectLookedAtInteractive.LookAtInteractive.InteractiveWith();
        }
    }
}