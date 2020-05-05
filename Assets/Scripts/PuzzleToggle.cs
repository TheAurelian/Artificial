using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleToggle : InteractiveObject
{
    [Tooltip("The GameObject to toggle")]
    [SerializeField]
    private GameObject objectToToggle;

    [Tooltip("The reverse GameObject to toggle")]
    [SerializeField]
    private GameObject objectBToToggle;

    [Tooltip("Can the player interact with this more than once")]
    [SerializeField]
    private bool isReusable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this item.
    /// </summary>

    public override void InteractiveWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractiveWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            objectBToToggle.SetActive(!objectBToToggle.activeSelf);
            hasBeenUsed = true;

            if (!isReusable) displayText = string.Empty;
        }
    }
}
