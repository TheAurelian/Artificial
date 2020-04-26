using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Remove this simple version and add to correct script so image can be only displayed if text isn't blank

/// <summary>
/// This UI text displays the image underline beneath the text
/// Image souldn't display if there is no text
/// </summary>

public class LookedAtInteractiveDisplayImage : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    public Image displayImage;

    private void Awake()
    {
        UpdateDisplayImage();
    }

    private void UpdateDisplayImage()
    {
        if (lookedAtInteractive != null)
        {
            displayImage.enabled = true;
        }

        else
        {
            displayImage.enabled = false;
        }

    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Refrence to the new IInteractive the player is looking at</param>

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayImage();
    }

    #region Event aubscription / unsubscription
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