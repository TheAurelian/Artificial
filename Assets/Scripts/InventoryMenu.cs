using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private FirstPersonController firstPersonController;
    private AudioSource audioSource;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instance that are you are trying to access.  Ensure InventoryMenu script is applied to a gameobject in your scene.");

            return instance;
        }
        private set { instance = value; }
    }

    private bool IsVisible => canvasGroup.alpha > 0;

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu
    /// </summary>
    /// <param name="inventoryObjecToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjecToAdd)
    {
        Instantiate(inventoryMenuItemTogglePrefab);
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        firstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioSource.Play();
        firstPersonController.enabled = true;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Inventory Menu"))
            if (IsVisible)
                HideMenu();
            else
                ShowMenu();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMenu and there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        firstPersonController = FindObjectOfType<FirstPersonController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        HideMenu();
        StartCoroutine(WaitForAudioClip());
    }

    private IEnumerator WaitForAudioClip()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.volume = originalVolume;
    }
}
