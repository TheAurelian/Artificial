using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : InteractiveObject
{
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
    }

    public override void InteractiveWith()
    {
        // This plays a sound effect
        base.InteractiveWith();
        transform.Rotate(new Vector3(0, 90, 0));
    }
}

