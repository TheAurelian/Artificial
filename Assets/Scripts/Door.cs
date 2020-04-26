using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Assigning a key will lock the door; if the player has the key in their inventory they can open the door")]
    [SerializeField]
    private InventoryObject key;

    [Tooltip("If this is checked the key will be removed from the player's inventory when the door is unlocked")]
    [SerializeField]
    private bool consumesKey;

    [Tooltip("The text displayed if the door is locked")]
    [SerializeField]
    private string lockedDisplayText = "Locked Door";

    [Tooltip("Plays when the player interacts with a locked door without owning the key")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("Plays when the player opens the door")]
    [SerializeField]
    private AudioClip openAudioClip;

    // public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
                toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            else
                toReturn = base.DisplayText;

            return toReturn;
        }
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;

    // private int shouldOpenAnimParameter = Animator.StringToHash(nameof(shouldOpenAnimParameter));

    /// <summary>
    /// Using a constructor here to initialize displayText in the editor
    /// </summary>

    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializedIsLocked();
    }

    private void InitializedIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractiveWith()
    {
        if (!isOpen)
        {
            if (isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else // If it's not locked or if it's locked and we have the key
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
            }

            // This plays the sound effect
            base.InteractiveWith(); 
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.InventoryObjects.Remove(key);
    }
}
