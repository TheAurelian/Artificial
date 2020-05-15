using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StoryObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text that displays in the UI when the player looks at this object in the game world")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    [Tooltip("Story information goes here")]
    [TextArea(3, 6)]
    [SerializeField]
    private string story;

    public FirstPersonController firstPersonController;
    public GameObject storyCanvas;

    public virtual string DisplayText => displayText;

    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractiveWith()
    {
        if (audioSource != null)
            audioSource.Play();
        Debug.Log($"Player just interacted with {gameObject.name}.");
        ShowMenu();
    }

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    private void ShowMenu()
    {
        storyCanvas.gameObject.SetActive(true);
        firstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideMenu()
    {
        storyCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstPersonController.enabled = true;
    }
}

