using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
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
            base.InteractiveWith();
            animator.SetBool("shouldOpen", true);
            displayText = string.Empty;
            isOpen = true;
        }
    }
}
