using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Check this box to lock the door")]
    [SerializeField]
    private bool isLocked;

    [Tooltip("The text displayed if the door is locked")]
    [SerializeField]
    private string lockedDisplayText = "Locked Door";

    [Tooltip("Plays when the player interacts with a locked door without owning the key")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("Plays when the player opens the door")]
    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    private Animator animator;
    private bool isOpen = false;
    

    /// <summary>
    /// Using a constructor her to initialize displayText in the editor
    /// </summary>
    
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractiveWith()
    {
        if (!isOpen)
        {
            if (!isLocked)
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
            }

            // If the door is locked set audio to play this sound
            else
            {
                audioSource.clip = lockedAudioClip;
            }

            // This plays the sound effect
            base.InteractiveWith(); 
        }
    }
}
