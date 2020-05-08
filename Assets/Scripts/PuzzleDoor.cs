using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PuzzleDoor : InteractiveObject
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

    [SerializeField]
    private GameObject puzzlePieceA;

    [SerializeField]
    private GameObject puzzlePieceB;

    [SerializeField]
    private GameObject puzzlePieceC;

    [SerializeField]
    private GameObject puzzlePieceD;

    [SerializeField]
    private GameObject puzzlePieceE;

    [SerializeField]
    private GameObject puzzlePieceF;

    [SerializeField]
    private GameObject puzzlePieceG;

    [SerializeField]
    private GameObject greenLight;

    [SerializeField]
    private GameObject redLight;


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

    public PuzzleDoor()
    {
        displayText = nameof(Door);
    }

    private void Update()
    {
        PuzzleCheck();
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
            if (puzzlePieceA.transform.rotation.eulerAngles.y == 0 || puzzlePieceA.transform.rotation.eulerAngles.y == 180)
            {
                if (puzzlePieceB.transform.rotation.eulerAngles.y == 0)
                {
                    if (puzzlePieceC.transform.rotation.eulerAngles.y == 90 || puzzlePieceC.transform.rotation.eulerAngles.y == -90.00001)
                    {
                        if (puzzlePieceD.transform.rotation.eulerAngles.y == 180)
                        {
                            if (puzzlePieceE.transform.rotation.eulerAngles.y == 0 || puzzlePieceE.transform.rotation.eulerAngles.y == 180)
                            {
                                if (puzzlePieceF.transform.rotation.eulerAngles.y == 0)
                                {
                                    if (puzzlePieceG.transform.rotation.eulerAngles.y == 90 || puzzlePieceG.transform.rotation.eulerAngles.y == -90.00001)
                                    {
                                        Debug.Log("Puzzle correct");

                                        audioSource.clip = openAudioClip;
                                        animator.SetBool("shouldOpen", true);
                                        displayText = string.Empty;
                                        isOpen = true;
                                        UnlockDoor();

                                    }
                                    else
                                    {
                                        audioSource.clip = lockedAudioClip;
                                    }
                                }
                                else
                                {
                                    audioSource.clip = lockedAudioClip;
                                }
                            }
                            else
                            {
                                audioSource.clip = lockedAudioClip;
                            }
                        }
                        else
                        {
                            audioSource.clip = lockedAudioClip;
                        }
                    }
                    else
                    {
                        audioSource.clip = lockedAudioClip;
                    }
                }
                else
                {
                    audioSource.clip = lockedAudioClip;
                }
            }
            else
            {
                audioSource.clip = lockedAudioClip;
            }
            base.InteractiveWith();
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.InventoryObjects.Remove(key);
    }

    private void PuzzleCheck()
    {
        if (puzzlePieceA.transform.rotation.eulerAngles.y == 0 || puzzlePieceA.transform.rotation.eulerAngles.y == 180)
        {
            if (puzzlePieceB.transform.rotation.eulerAngles.y == 0)
            {
                if (puzzlePieceC.transform.rotation.eulerAngles.y == 90 || puzzlePieceC.transform.rotation.eulerAngles.y == -90.00001)
                {
                    if (puzzlePieceD.transform.rotation.eulerAngles.y == 180)
                    {
                        if (puzzlePieceE.transform.rotation.eulerAngles.y == 0 || puzzlePieceE.transform.rotation.eulerAngles.y == 180)
                        {
                            if (puzzlePieceF.transform.rotation.eulerAngles.y == 0)
                            {
                                if (puzzlePieceG.transform.rotation.eulerAngles.y == 90 || puzzlePieceG.transform.rotation.eulerAngles.y == 90.00001)
                                {
                                    redLight.gameObject.SetActive(false);
                                    greenLight.gameObject.SetActive(true);
                                }
                                else
                                {
                                    redLight.gameObject.SetActive(true);
                                    greenLight.gameObject.SetActive(false);
                                }
                            }
                            else
                            {
                                redLight.gameObject.SetActive(true);
                                greenLight.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            redLight.gameObject.SetActive(true);
                            greenLight.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        redLight.gameObject.SetActive(true);
                        greenLight.gameObject.SetActive(false);
                    }
                }
                else
                {
                    redLight.gameObject.SetActive(true);
                    greenLight.gameObject.SetActive(false);
                }
            }
            else
            {
                redLight.gameObject.SetActive(true);
                greenLight.gameObject.SetActive(false);
            }
        }
        else
        {
            redLight.gameObject.SetActive(true);
            greenLight.gameObject.SetActive(false);
        }
    }
}




