using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls the Innteractive's interactwith method
/// </summary>
public class InteractiveWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            lookedAtInteractive.InteractiveWith();
        }
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Refrence to the new IInteractive the player is looking at</param> 
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event subscription / unsubscription
    private void OnEnable()
    {
        DetectLookatInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookatInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}