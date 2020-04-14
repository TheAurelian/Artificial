using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RotatePuzzle : InteractiveObject
{
    private Animator animator;
    private bool isRotate = false;

    /// <summary>
    /// Using a constructor here to initialize displayText in the editor
    /// </summary>

    public RotatePuzzle()
    {
        displayText = nameof(RotatePuzzle);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractiveWith()
    {
        if (!isRotate)
        {
            // This plays a sound effect
            base.InteractiveWith();
            animator.SetBool("shouldRotate", true);
            isRotate = true;
        }
        
    }

    public void Update()
    {
        animator.SetBool("shouldRotate", false);
        isRotate = false;
    }
}

