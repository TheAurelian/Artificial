using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    public void InteractiveWith()
    {
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
